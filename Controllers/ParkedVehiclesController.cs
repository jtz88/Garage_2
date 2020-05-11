using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2.Data;
using Garage_2.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Routing;

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

            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkedVehicle == null)
            {
                return NotFound();
            }

            return View(parkedVehicle);
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

        public IActionResult Receipt(string regnr, VehicleType vehicleType, int nrOfWheels, string color, string brand, string model, DateTime timeOfArrival)
        {
            //https://localhost:44347/ParkedVehicles/Receipt?regnr=aaa&vehicleType=2&nrOfWheels=3&color=red&brand=ccc&model=ddd&timeOfArrival=2000-01-01
            ViewData["regnr"] = regnr;
            ViewData["vehicleType"] = vehicleType;
            ViewData["nrOfWheels"] = nrOfWheels;
            ViewData["color"] = color;
            ViewData["brand"] = brand;
            ViewData["model"] = model;
            ViewData["timeOfArrival"] = timeOfArrival;
            return View();
        }
        
        public IActionResult AskReceipt(string regnr, VehicleType vehicleType, int nrOfWheels, string color, string brand, string model, DateTime timeOfArrival)
        {
            ViewData["regnr"] = regnr;
            ViewData["vehicleType"] = vehicleType;
            ViewData["nrOfWheels"] = nrOfWheels;
            ViewData["color"] = color;
            ViewData["brand"] = brand;
            ViewData["model"] = model;
            ViewData["timeOfArrival"] = timeOfArrival;
            return View();
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
                    
            var r = parkedVehicle.RegNr;
            var v = parkedVehicle.VehicleType;
            var n = parkedVehicle.NrOfWheels;
            var c = parkedVehicle.Color;
            var b = parkedVehicle.Brand;
            var m = parkedVehicle.Model;            //whatever
            var t = parkedVehicle.TimeOfArrival;
            var routeValues = new RouteValueDictionary  {
                { "regnr", r },
                { "vehicleType", v },
                { "nrOfWheels",n},
                { "color",c},
                { "brand",b},
                { "model",m},
                { "timeOfArrival",t}
                                                        };

            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AskReceipt),routeValues);
        }

        private bool ParkedVehicleExists(int id)
        {
            return _context.ParkedVehicle.Any(e => e.Id == id);
        }
    }
}
