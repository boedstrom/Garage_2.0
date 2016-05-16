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

            recipt.ParkTimeString = recipt.ParkingTime.ToString(@"dd\.hh\:mm");
            
            Decimal totalCharge = 0;
            
            if (secs > 0)
            {
                mins += 1;
            }

            if (mins > 0)
            {
                hours += 1;
            }

            if (days > 0)
            {
                totalCharge = (days * 24) * recipt.ParkingFee;
            }

            if (hours > 0)
            {
                totalCharge += hours * recipt.ParkingFee;
            }
            
            recipt.TotalParkingFee = Math.Round(totalCharge, 2, MidpointRounding.ToEven);

            return View(recipt);
        }
    }
}
