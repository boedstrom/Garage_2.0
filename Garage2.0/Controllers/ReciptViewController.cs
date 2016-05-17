using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Garage2._0.Models;

namespace Garage2._0.Controllers
{
    public class ReciptViewController : Controller
    {
        // GET: ReciptView
        public ActionResult Index(ReciptViewModel recipt)
        {
            int days = recipt.ParkingTime.Days;
            int hours = recipt.ParkingTime.Hours;
            int mins = recipt.ParkingTime.Minutes;
            int secs = recipt.ParkingTime.Seconds;

            int totalHours = (days * 24) + hours;

            hours = totalHours;
            totalHours += 1;  // always charge for a "started" hour

            Decimal totalCharge = totalHours * recipt.ParkingFee;
            
            recipt.TotalParkingFee = Math.Round(totalCharge, 2, MidpointRounding.ToEven);

            recipt.ParkTimeString = hours.ToString() + "h " + mins.ToString() + "m";

            return View(recipt);
        }
    }
}
