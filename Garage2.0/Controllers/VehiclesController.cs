using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2._0.DataAccessLayer;
using Garage2._0.Models;
using System.Text.RegularExpressions;

namespace Garage2._0.Controllers
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
            reciptView.Type = vehicle.Type;
            reciptView.RegNumber = vehicle.RegNumber;
            reciptView.CheckInTime = vehicle.CheckInTime;
            reciptView.CheckOutTime = DateTime.Now;
            reciptView.ParkingTime = reciptView.CheckOutTime.Subtract(reciptView.CheckInTime);
            reciptView.ParkingFee = 60;

            return RedirectToAction("Index", "ReciptView", reciptView);
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
