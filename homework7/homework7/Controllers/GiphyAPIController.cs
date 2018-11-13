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
            // This will get the apiKey from our secret file
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIkey"];
            // this will use our apiKey to send a request to giphy, first making a var called website
            var website = "https://api.giphy.com/v1/stickers/translate?api_key=" + apiKey + "&s=" + word;
            var request = WebRequest.Create(website);
            // request a json object
            request.ContentType = "application/json; charset=utf-8";
            // will save the response in a var
            var response = (HttpWebResponse)request.GetResponse();
            
            string text;
            //  read the response into a string
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
                sr.Close();
            }

            // next two lines will parse the text string to get the embed_url
            string fullData = JObject.Parse(text)["data"].ToString();
            string embed = JObject.Parse(fullData)["embed_url"].ToString();
            Console.WriteLine(response);

            //next two lines get ip address and useragent respectively
            var ip = Request.UserHostAddress;
            var agent = Request.Browser.Type;
            Console.WriteLine(ip + ": " + agent);

            // save all the needed information using model
            var newRecord = new RecordsInput
            {
                Date = DateTime.Now,
                Input = word,
                IP = ip,
                BrowserAG = agent
            };
            // put new record into table
            db.RecordsInputs.Add(newRecord);
            db.SaveChanges();

            // save info as a data for later use in jscript
            var data = new
            {
                thing = ip + ": " + agent,
                urlGifEm = embed
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}