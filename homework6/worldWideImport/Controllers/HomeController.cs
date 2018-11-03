using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using worldWideImport.DAL;
using worldWideImport.Models;
using worldWideImport.Models.ViewModels;

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

                List<PersonVM> listPeople = db.People.Select(p => new PersonVM
                {
                    FullName = p.FullName,
                    PreferredName = p.PreferredName,
                    PhoneNumber = p.PhoneNumber,
                    FaxNumber = p.FaxNumber,
                    EmailAddress = p.EmailAddress,
                    ValidFrom = p.ValidFrom
                }).Where(per => per.FullName.Contains(searchString)).ToList();

            if(listPeople.Count > 0)
            {
                ViewBag.toggle = 1;
                ViewBag.result = "Search results for \"" + searchString + "\"";
            }
            
            else
            {
                ViewBag.result = "Sorry, no results have been made!";
            }
            return View(listPeople);
        }

        [HttpPost]
        public ActionResult Details()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Details(String fName)
        {

            List<PersonVM> result = db.People.Select(p => new PersonVM
            {
                FullName = p.FullName,
                PreferredName = p.PreferredName,
                PhoneNumber = p.PhoneNumber,
                FaxNumber = p.FaxNumber,
                EmailAddress = p.EmailAddress,
                ValidFrom = p.ValidFrom
            }).Where(per => per.FullName.Contains(fName)).ToList();
            return View(result);
        }
    }
}