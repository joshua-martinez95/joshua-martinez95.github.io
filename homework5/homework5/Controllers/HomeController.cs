using homework5.Models;
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


//        [HttpPost]
//        public ActionResult Create(OurUsers_withDB user)
//        {
   ///         if (ModelState.IsValid)
   ///         {
  ////              uc = user collection
  ///              uc.Users.Add(user);
  ///              return RedirectToAction("AllUsers");
 ///           }
//            return View();
///        }
    }

}

///When making controller to view users, pass model. Ex: reutrn View(model)