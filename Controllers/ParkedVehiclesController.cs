using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage_2;
using Garage_2.Data;
using Garage_2.Models;
using Garage_2.ViewModels;
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
            var vehicles = await _context.ParkedVehicle.ToListAsync();
            return View(nameof(Index), vehicles);
        }

        public async Task<IActionResult> Overview()
        {
            var vehicles = await _context.ParkedVehicle.ToListAsync();

            var model = vehicles.Select(m => new OverviewViewModel
            {
                RegNr = m.RegNr,
                VehicleType = m.VehicleType,
                TimeOfArrival = m.TimeOfArrival,
                TimeInGarage = m.TimeInGarage
            });

            return View(model);
        }

        /*public async Task<IActionResult> Receipt(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var parkedVehicles = await _context.ParkedVehicle.FirstOrDefaultAsync(m => m.Id == id);
            
            if (parkedVehicles == null)
            {
                return NotFound();
            }

            var model = new ReceiptViewModel
            {
                Id = parkedVehicles.Id,
                RegNr = parkedVehicles.RegNr,
                TimeOfArrival = parkedVehicles.TimeOfArrival,
                TimeOfDeparture = DateTime.Now,
            };

            return View(model);
        }*/


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

        public IActionResult Receipt(string regnr, VehicleType vehicleType, int nrOfWheels, string color, string brand, string model, DateTime timeOfArrival, string timeInGarage, int cost)
        {
            //https://localhost:44347/ParkedVehicles/Receipt?regnr=aaa&vehicleType=2&nrOfWheels=3&color=red&brand=ccc&model=ddd&timeOfArrival=2000-01-01
            ViewData["regnr"] = regnr;
            ViewData["vehicleType"] = vehicleType;
            ViewData["nrOfWheels"] = nrOfWheels;
            ViewData["color"] = color;
            ViewData["brand"] = brand;
            ViewData["model"] = model;
            ViewData["timeOfArrival"] = timeOfArrival;
            ViewData["timeInGarage"] = timeInGarage;
            ViewData["cost"] = cost;
            return View();
        }

        public IActionResult AskReceipt(string regnr, VehicleType vehicleType, int nrOfWheels, string color, string brand, string model, DateTime timeOfArrival, string timeInGarage, int cost)
        {
            ViewData["regnr"] = regnr;
            ViewData["vehicleType"] = vehicleType;
            ViewData["nrOfWheels"] = nrOfWheels;
            ViewData["color"] = color;
            ViewData["brand"] = brand;
            ViewData["model"] = model;
            ViewData["timeOfArrival"] = timeOfArrival;
            ViewData["timeInGarage"] = timeInGarage;
            ViewData["cost"] = cost;
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
            var tg = parkedVehicle.TimeInGarage;
            //var tg = DateTime.Now.Subtract(t);

            //kostnad (går att göra bättre sen)
            var timeInGarage = DateTime.Now.Subtract(t);
            //String.Format($"{timeInGarage.Hours:00}:{ timeInGarage.Minutes:00}:{timeInGarage.Seconds:00}");
            int mins = timeInGarage.Hours * 60;
            mins += timeInGarage.Minutes;
            const int minuteFee = 2;
            int cost = mins * minuteFee;


            var routeValues = new RouteValueDictionary  {
                { "regnr", r },
                { "vehicleType", v },
                { "nrOfWheels",n},
                { "color",c},
                { "brand",b},
                { "model",m},
                { "timeOfArrival",t},
                { "timeInGarage", tg },
                { "cost", cost }
                                                        };

            _context.ParkedVehicle.Remove(parkedVehicle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(AskReceipt), routeValues);
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



        public async Task<ParkedVehicle> GetParkedVehicle(int id)
        {
            var parkedVehicle = await _context.ParkedVehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            return parkedVehicle;
        }



        public Dictionary<VehicleType, float> vehicleParkingSize = new Dictionary<VehicleType, float>() {
                                  {VehicleType.Airplane, 3},
                                  {VehicleType.Boat, 3},
                                  {VehicleType.Bus, 2},
                                  {VehicleType.Car, 1},
                                  {VehicleType.Motorcycle, 1/3}
    };

        public const int Garage_ParkingCap = 50;

        public ParkingSpace[] parkingSpaces = new ParkingSpace[Garage_ParkingCap];


        public int? GetNextAvailableSpace(VehicleType vehicleType, int posParkingSpace = 0)
        {
            var parkingSizeVehicle = vehicleParkingSize[vehicleType]; // ?? 1.0;
            for (int i = posParkingSpace; i <= (int)(parkingSpaces.Length - parkingSizeVehicle); i++)
            {
                var freeSpace = true;
                for (int s = 0; s < parkingSizeVehicle; s++)
                {
                    if (parkingSpaces[i + s] != null)
                    {
                        if (parkingSpaces[i + s].Used + parkingSizeVehicle <= 1.0) continue; //(vehicleType===VehicleType.Motorcycle)
                        freeSpace = false;
                    }
                }
                if (freeSpace) return i;
            }
            return null;
        }

        public int GetNrOfAvailableSpace(VehicleType vehicleType)
        {
            int? posParkingSpace = 0;
            var nrOfParkingSpace = 0;
            var parkingSizeVehicle = vehicleParkingSize[vehicleType]; // ?? 1.0;
            while (posParkingSpace != null)
            {
                posParkingSpace = GetNextAvailableSpace(vehicleType, (int)posParkingSpace);
                if (posParkingSpace != null)
                {
                    if (parkingSizeVehicle < 1.0
                        && parkingSpaces[(int)posParkingSpace].Used < 1.0
                        && (1.0 - parkingSpaces[(int)posParkingSpace].Used) >= parkingSizeVehicle)
                    {
                        nrOfParkingSpace += (int)((1.0 - parkingSpaces[(int)posParkingSpace].Used) / parkingSizeVehicle);
                    }
                    else
                        nrOfParkingSpace++;
                }
            }
            return nrOfParkingSpace;
        }


        public void Park(int id, int posParkingSpace = 0, bool unPark = false)
        {
            var parkedVehicle = GetParkedVehicle(id).Result;
            var parkingSizeVehicle = vehicleParkingSize[parkedVehicle.VehicleType]; // ?? 1.0;

            for (int s = 0; s < parkingSizeVehicle; s++)
            {
                parkingSpaces[posParkingSpace + s].ParkedVehicleId = unPark ? null : (int?)((ParkedVehicle)parkedVehicle).Id;
            }
        }

        public void UnPark(int id)
        {
            int? posParkingSpace = null;
            for (int i = 0; i <= parkingSpaces.Length; i++)
            {
                if (parkingSpaces[i].ParkedVehicleId == id)
                {
                    posParkingSpace = i;
                    continue;
                }
            }
            if (posParkingSpace != null) Park(id, (int)posParkingSpace, true);
        }


    }
}
