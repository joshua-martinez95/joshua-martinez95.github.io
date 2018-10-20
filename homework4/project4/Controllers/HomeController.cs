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
            //get input form the text box
            string input = Request.QueryString["miles"];
            // get the units from the radio button
            string unitMetric = Request.QueryString["units"];

            // show in debug the infromation
            System.Diagnostics.Debug.WriteLine("The miles: " + input + " The units " + unitMetric);
            double result = 0;

            if (input == null)
            {
            }
            else
            {
                // convert the input string into a double
                result = Convert.ToDouble(input);

                // switch case to do the math
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
                // does the statement that will be printed
                ViewBag.statement = input + " miles is equal to " + Convert.ToString(result) + " " + unitMetric;
            }
            //returns the view
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}