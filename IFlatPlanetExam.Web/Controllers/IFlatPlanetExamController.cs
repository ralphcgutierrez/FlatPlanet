using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using IFlatPlanetExam.Model;
using IFlatPlanetExam.Data;

namespace IFlatPlanetExam.Web.Controllers
{
    public class IFlatPlanetExamController : Controller
    {
        MethodCollection method = new MethodCollection();
        private int increment = 1;

        /// <summary>
        /// Get number the total click count
        /// </summary>
        /// <returns>Total count</returns>
        public ActionResult Index()
        {
            PressViewModel press = new PressViewModel();
            press.count = method.Count();
            return View(press);
        }

        /// <summary>
        /// Save click count
        /// </summary>
        /// <returns>number of affected rows from database table</returns>
        [HttpPost]
        public ActionResult Insert()
        {
            int affectedRow = method.Insert(increment);
            return View();
        }



    }
}