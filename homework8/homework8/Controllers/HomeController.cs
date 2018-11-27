using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using homework8.Models;

namespace homework8.Controllers
{
    public class HomeController : Controller
    {
        private AuctionDBContext db = new AuctionDBContext();

        public ActionResult Index()
        {
            var listBids = db.Bids.OrderByDescending(bid => bid.Timestamp).Take(10).ToList();

            return View(listBids);
        }

        public ActionResult CreateBid()
        {
            ViewBag.Message = "Your contact page.";
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "Name");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBid([Bind(Include = "BidID, ItemID, BuyerID, Price")] Bid newBid)
        {
            newBid.Timestamp = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Bids.Add(newBid);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BuyerID = new SelectList(db.Buyers, "BuyerID", "Name", newBid.BuyerID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "Name", newBid.ItemID);
            return View(newBid);
        }
    }
}