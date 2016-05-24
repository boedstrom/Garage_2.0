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

        // GET: VehicleViewModels/Create
        public ActionResult Create()
        {
            VehicleViewModel vehicleViewModel = new VehicleViewModel();

            var result = db.VehicleTypes.ToList();
            if (result != null)
            {
                vehicleViewModel.VehicleTypes = new List<VehicleType>();

                foreach (VehicleType r in result)
                {
                    vehicleViewModel.VehicleTypes.Add(r);
                }
                return View(vehicleViewModel);
            }
            return View();
        }

        // POST: VehicleViewModels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RegNumber,Color,Brand,Model,NumOfWheels,CheckInTime")] VehicleViewModel vehicleViewModel)
        {
            //if (ModelState.IsValid)
            //{
            //    db.VehicleViewModels.Add(vehicleViewModel);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(vehicleViewModel);
            return View();
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
