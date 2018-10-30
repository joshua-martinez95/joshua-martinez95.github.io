using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using homework5.DAL;
using homework5.Models;

namespace homework5.Controllers
{
    public class UsersController : Controller
    {
        private UserContext db = new UserContext();

        /// <summary>
        /// This will list the entires, sorted by Time and date
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            /// returns the table, sorted by time
            return View(db.Users.ToList().OrderBy(item => item.TimeRequest));
        }

        /// <summary>
        /// Display initial Create page
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Once the submission page is pressed, do this action
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,PhoneNum,AptNumber,AptName,Comment,CheckBox,TimeRequest")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
