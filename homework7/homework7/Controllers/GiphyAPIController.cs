using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;

namespace homework7.Controllers
{
    public class GiphyAPIController : Controller
    {
        // GET: GiphyAPI/RandomNumbers/10
        public JsonResult gif(string word)
        {
            
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIkey"];
            var website = "https://api.giphy.com/v1/stickers/translate?api_key="+apiKey+"&s="+word;
            var request = WebRequest.Create(website);
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();
            string text;
            // JObject.Parse
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }

            Console.WriteLine(text);
            var data = new
            {

                message = word + " is a verb/noun",
                gifVal = text
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}