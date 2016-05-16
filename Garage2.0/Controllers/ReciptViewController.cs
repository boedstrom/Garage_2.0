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
            return View(recipt);
        }
    }
}
