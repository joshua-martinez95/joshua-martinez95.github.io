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
        public JsonResult gif(string word)
        {
            var data = new
            {
                message = word
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}