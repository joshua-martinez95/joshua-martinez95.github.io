using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Converter()
        {
            string input = Request.QueryString["miles"];
            string unitMetric = Request.QueryString["units"];
            System.Diagnostics.Debug.WriteLine(unitMetric);
            double result = -1;

            if (input == null)
            {
            }
            else
            {
                double miles = Convert.ToDouble(input);

                switch (unitMetric)
                {
                    case "millimeters":
                        result = result * 1609344;
                        break;
                    case "centimeters":
                        result = result * 160934.4;
                        break;
                    case "meters":
                        result = result * 1609.344;
                        break;
                    case "kilometers":
                        result = result * 1.609344;
                        break;
                    default:
                        result = 0;
                        break;
                }
                ViewBag.statement = input + " miles is equal to " + Convert.ToString(result) + " " + unitMetric;
            }
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}