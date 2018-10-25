using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework5.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {/// uc = user collection
                uc.Users.Add(user);
                return RedirectToAction("AllUsers");
            }
            return View();
        }
}

///When making controller to view users, pass model. Ex: reutrn View(model)