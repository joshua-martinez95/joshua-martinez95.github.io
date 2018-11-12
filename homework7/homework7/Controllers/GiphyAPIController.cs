using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using homework7.DAL;
using homework7.Models;

namespace homework7.Controllers
{
    public class GiphyAPIController : Controller
    {
        private RecordsContext db = new RecordsContext();

        // GET: GiphyAPI/RandomNumbers/10
        public JsonResult Gif(string word)
        {

            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIkey"];
            var website = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + word;
            var request = WebRequest.Create(website);
            request.ContentType = "application/json; charset=utf-8";
            var response = (HttpWebResponse)request.GetResponse();
            string text;
            // JObject.Parse
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
                sr.Close();
            }
            string fullData = JObject.Parse(text)["data"].ToString();
            string embed = JObject.Parse(fullData)["embed_url"].ToString();
            Console.WriteLine(response);

            var ip = Request.UserHostAddress;
            var agent = Request.Browser.Type;
            Console.WriteLine(ip + ": " + agent);

            var newRecord = new RecordsInput
            {
                Date = DateTime.Now,
                Input = word,
                IP = ip,
                BrowserAG = agent
            };
            db.RecordsInputs.Add(newRecord);
            db.SaveChanges();

            var data = new
            {
                thing = ip + ": " + agent,
                urlGifEm = embed
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}