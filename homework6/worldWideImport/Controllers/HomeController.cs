using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using worldWideImport.DAL;
using worldWideImport.Models;

namespace worldWideImport.Controllers
{
    public class HomeController : Controller
    {

        UserContext db = new UserContext();


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            ViewBag.result = searchString;

            var test = db.People.Take(10);
            System.Diagnostics.Debug.WriteLine(searchString);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}