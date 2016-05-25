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

namespace Garage2._0.Models
{
    public class VehicleViewModelsController : Controller
    {
        private VehiclesContext db = new VehiclesContext();

        // GET: VehicleViewModels
        public ActionResult Index()
        {
//            return View(db.VehicleViewModels.ToList());
            return View();
        }

        // GET: VehicleViewModels/Details/5
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

            VehicleViewModel vehicleViewModel = new VehicleViewModel();
            //bool valuesOk = false;

            
            //    vehicleViewModel.Members = new List<Member>();
            //    foreach (Member m in memberResult)
            //    {
            //        vehicleViewModel.Members.Add(m);
            //    }
            //    valuesOk = true;
            //}

            //var typeResult = db.VehicleTypes.ToList();
            //if (typeResult != null)
            //{
            //    vehicleViewModel.VehicleTypes = new List<VehicleType>();

            //    foreach (VehicleType t in typeResult)
            //    {
            //        vehicleViewModel.VehicleTypes.Add(t);
            //    }
            //    valuesOk = true;
            //}
            //if (valuesOk)
            //    return View(vehicleViewModel);
            //else
            //    return View();



            return View(vehicleViewModel);
        }

        // GET: VehicleViewModels/Create
        public ActionResult Create()
        {
            VehicleViewModel vehicleViewModel = new VehicleViewModel();
            bool valuesOk = false;

            var memberResult = db.Members.ToList();
            if (memberResult != null)
            {
                vehicleViewModel.Members = new List<Member>();
                foreach (Member m in memberResult)
                {
                    vehicleViewModel.Members.Add(m);
                }
                valuesOk = true;
            }

            var typeResult = db.VehicleTypes.ToList();
            if (typeResult != null)
            {
                vehicleViewModel.VehicleTypes = new List<VehicleType>();

                foreach (VehicleType t in typeResult)
                {
                    vehicleViewModel.VehicleTypes.Add(t);
                }
                valuesOk = true;
            }
            if (valuesOk)
                return View(vehicleViewModel);
            else
                return View();
        }

        // POST: VehicleViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VehicleViewModel vehicleViewModel)
        {
            Vehicle vehicle = new Vehicle();

            vehicle.RegNumber = vehicleViewModel.RegNumber.ToUpper();
            vehicle.Brand = vehicleViewModel.Brand;
            vehicle.Model = vehicleViewModel.Model;
            vehicle.Color = vehicleViewModel.Color.ToLower();
            vehicle.NumOfWheels = vehicleViewModel.NumOfWheels;
            vehicle.Member = db.Members.Find(vehicleViewModel.MemberId);
            vehicle.VehicleType = db.VehicleTypes.Find(vehicleViewModel.VehicleTypeId);

            db.Vehicles.Add(vehicle);
            db.SaveChanges();
            return RedirectToAction("Index", "Vehicles");
        }

        // GET: VehicleViewModels/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //VehicleViewModel vehicleViewModel = db.VehicleViewModels.Find(id);
            //if (vehicleViewModel == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(vehicleViewModel);
            return View();
        }

        // POST: VehicleViewModels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RegNumber,Color,Brand,Model,NumOfWheels,CheckInTime")] VehicleViewModel vehicleViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicleViewModel);
        }

        // GET: VehicleViewModels/Delete/5
        public ActionResult Delete(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //VehicleViewModel vehicleViewModel = db.VehicleViewModels.Find(id);
            //if (vehicleViewModel == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(vehicleViewModel);
            return View();
        }

        // POST: VehicleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //VehicleViewModel vehicleViewModel = db.VehicleViewModels.Find(id);
            //db.VehicleViewModels.Remove(vehicleViewModel);
            //db.SaveChanges();
            //return RedirectToAction("Index");
            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
