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
            try
            {
                press.count = method.Count();
            }
            catch (Exception ex)
            {
                return View("Error",new HandleErrorInfo(ex,"Index","Index"));
            }
            return View(press);
        }

        /// <summary>
        /// Save click count
        /// </summary>
        /// <returns>number of affected rows from database table</returns>
        [HttpPost]
        public ActionResult Insert()
        {
            try
            {
               method.Insert(increment);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Index", "Index"));   
            }
            return View();
        }

    }
}