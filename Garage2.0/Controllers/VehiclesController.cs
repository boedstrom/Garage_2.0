using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2_5.DataAccessLayer;
using Garage2_5.Models;
using System.Text.RegularExpressions;

namespace Garage2_5.Controllers
{
    public class VehiclesController : Controller
    {
        private VehiclesContext db = new VehiclesContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            Vehicle vehicle = new Vehicle();
            return View(vehicle);
//            return View();
        }

        // POST: Vehicles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNumber,Color,Brand,Model,NumOfWheels,CheckInTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (IsValidRegNumber(vehicle.RegNumber))
                {
                    vehicle.RegNumber = vehicle.RegNumber.ToUpper();
                    vehicle.Color = vehicle.Color.ToLower();
                    db.Vehicles.Add(vehicle);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNumber,Color,Brand,Model,NumOfWheels,CheckInTime")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                if (IsValidRegNumber(vehicle.RegNumber))
                {
                    db.Entry(vehicle).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
   
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();

            ReciptViewModel reciptView = new ReciptViewModel();

            reciptView.Id = vehicle.Id;
//            reciptView.Type = vehicle.VehicleId.Name;
            reciptView.RegNumber = vehicle.RegNumber;
            reciptView.CheckInTime = vehicle.CheckInTime;
            reciptView.CheckOutTime = DateTime.Now;
            reciptView.ParkingTime = reciptView.CheckOutTime.Subtract(reciptView.CheckInTime);
            reciptView.ParkingFee = 60;

            return RedirectToAction("Index", "ReciptView", reciptView);
        }

        //GET: Vehicles/CheckOutSearch
        public ActionResult SearchResult(List<Vehicle> vehicles)
        {
            return View(vehicles);
        }

        //GET: Vehicles/CheckOutSearch
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(SearchVehicleModel vehicle)
        {
            //var result = db.Vehicles
            //    .Where(c => ((vehicle.Type != null ? vehicle.Type : c.Type) == c.Type)
            //             && ((vehicle.RegNumber != null ? vehicle.RegNumber : c.RegNumber) == c.RegNumber)
            //             && ((vehicle.Color != null ? vehicle.Color : c.Color) == c.Color)
            //             && ((vehicle.Brand != null ? vehicle.Brand : c.Brand) == c.Brand)
            //             && ((vehicle.Model != null ? vehicle.Model : c.Model) == c.Model)
            //             && ((vehicle.NumOfWheels != null ? vehicle.NumOfWheels : c.NumOfWheels) == c.NumOfWheels)
            //             && ((vehicle.Color != null ? vehicle.Color : c.Color) == c.Color));

            //if (result != null) {
            //    var vehicles = new List<Vehicle>();
            //    foreach (var vehicleMatchingSearchCriteria in result) {
            //        vehicles.Add(vehicleMatchingSearchCriteria);
            //    }
            //    return View("SearchResult", vehicles);
            //}
            return View(vehicle);
        }

        //GET: Vehicles/CheckOutSearch
        public ActionResult SearchTime()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SearchTime(SearchTimeModel interval)
        {
            var result = db.Vehicles
                .Where(c => ((interval.StartTime != null ? interval.StartTime : c.CheckInTime) <= c.CheckInTime)
                         && ((interval.EndTime != null ? interval.EndTime : c.CheckInTime) >= c.CheckInTime));

            if (result != null)
            {
                var vehicles = new List<Vehicle>();
                foreach (var vehicleMatchingSearchCriteria in result)
                {
                    vehicles.Add(vehicleMatchingSearchCriteria);
                }
                return View("SearchResult", vehicles);
            }
            return View(interval);
        }

        //GET: Vehicles/CheckOutSearch
        public ActionResult CheckOutSearch()
        {
            return View();
        }

        //POST: Vehicles/CheckOutSearch
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOutSearch(string regNumber)
        {
            if (regNumber == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vehicle vehicle = db.Vehicles.FirstOrDefault(r => r.RegNumber.StartsWith(regNumber.ToUpper()));

            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return RedirectToAction("Delete", new { vehicle.Id });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
        private static bool IsValidRegNumber(string value)
        {
            string pattern = @"^[a-zA-Z0-9]{1,8}$";
            return Regex.IsMatch(value, pattern);
        }
    }
}
