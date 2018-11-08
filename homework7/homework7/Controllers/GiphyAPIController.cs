using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace homework7.Controllers
{
    public class GiphyAPIController : Controller
    {
        // GET: GiphyAPI/RandomNumbers/10
        public JsonResult RandomNumbers(int? id = 100)
        {
            Random gen = new Random();
            var data = new
            {

            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}