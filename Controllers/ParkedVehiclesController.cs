using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2.Data;
using Garage_2.Models;
using Garage_2.ViewModels;
using Microsoft.Data.SqlClient;

namespace Garage_2.Controllers
{
    public class ParkedVehiclesController : Controller
    {
        private readonly Garage_2Context _context;

        public ParkedVehiclesController(Garage_2Context context)
        {
            _context = context;
        }

        // GET: ParkedVehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.ParkedVehicle.ToListAsync());
        }

        // GET: ParkedVehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ParkedVehicle
            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            
            var model = new ParkedVehiclesDetails
            {
                RegNr= parkedVehicle.RegNr,
                NrOfWheels = parkedVehicle.NrOfWheels,
                Color = parkedVehicle.Color,
                Brand = parkedVehicle.Brand,
                Model = parkedVehicle.Model,
                TimeOfArrival = parkedVehicle.TimeOfArrival,
                TimeInGarage = parkedVehicle.TimeInGarage
            }; 

            return View(model);
        }



        // GET: ParkedVehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkedVehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RegNr,VehicleType,NrOfWheels,Color,Brand,Model,TimeOfArrival")] ParkedVehicle parkedVehicle)
        {
            ViewBag.errMsg = "";
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(parkedVehicle);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException ex)
                {
                    var dbUpdateEx = ex as DbUpdateException;
                    var sqlEx = dbUpdateEx?.InnerException as SqlException;
                    if (sqlEx != null)
                    {
                        //This is a DbUpdateException on a SQL database 
                        const int SqlServerViolationOfUniqueIndex = 2601;
                        const int SqlServerViolationOfUniqueConstraint = 2627;
                        if (sqlEx.Number == SqlServerViolationOfUniqueIndex ||
                         sqlEx.Number == SqlServerViolationOfUniqueConstraint)
                        {
                            ModelState.AddModelError("RegNr", "Reg.nr is not unique");
                        }
                    else 
                        {
                        return BadRequest();
                        }
                    }
                }
            }
            return View(parkedVehicle);
        }
   


        // GET: ParkedVehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }
            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RegNr,VehicleType,NrOfWheels,Color,Brand,Model,TimeOfArrival")] ParkedVehicle parkedVehicle)
        {
            if (id != parkedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkedVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkedVehicleExists(parkedVehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(parkedVehicle);
        }

        // GET: ParkedVehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
        }

        // POST: ParkedVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle.FindAsync(id);
            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Filter(string regNrSearch)
        {
            var model = string.IsNullOrWhiteSpace(regNrSearch) ?
                _context.ParkedVehicle :
                _context.ParkedVehicle.Where(m => m.RegNr.ToLower().Contains(regNrSearch.ToLower()));

            //model = genre == null ?
            //    model :
            //    model.Where(m => m.Genre == (Genre)genre);

            return View(nameof(Index), await model.ToListAsync());
        }

    }
}
