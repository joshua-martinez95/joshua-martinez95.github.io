using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using worldWideImport.DAL;
using worldWideImport.Models;
using worldWideImport.Models.ViewModels;
using System.Data.Entity;
using System.Diagnostics;

namespace worldWideImport.Controllers
{
    public class HomeController : Controller
    {

        UserContext db = new UserContext();

        /// <summary>
        /// 
        /// This will display the first page on start up
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// This will get the search string and try to find any matches and display them.
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            /// But search Result in ViewBag
            ViewBag.result = searchString;

                /// Make a list of people that fit the search string
                /// Using sql dot notation
                List<PersonVM> listPeople = db.People.Select(p => new PersonVM
                {
                    FullName = p.FullName,
                    PreferredName = p.PreferredName,
                }).Where(per => per.FullName.Contains(searchString)).ToList();
            ///If there is atleast one search result
            /// turn on toggle to display search results
            if(listPeople.Count > 0)
            {
                ViewBag.toggle = 1;
                ViewBag.result = "Search results for \"" + searchString + "\"";
            }
            ///else, show this messages
            else
            {
                ViewBag.result = "Sorry, no results have been made!";
                return View(listPeople);
            }

            return View(listPeople);

        }

        /// <summary>
        /// This is the default page for Details
        /// Probably shouldn't be used
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Details()
        {

            return View();
        }
        /// <summary>
        /// This is the actual details page. Uses the full name to find the person
        /// </summary>
        /// <param name="fName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Details(String fName)
        {
            if (fName == null || fName == "")
            {
                /// If an error, redirect to Index page
                return (RedirectToAction("Index"));
            }
            
            /// Make the first part. the information of the person. 
            /// Using SQL dot notation
            List<PersonVM> result = db.People.Select(p => new PersonVM
            {
                FullName = p.FullName,
                PreferredName = p.PreferredName,
                PhoneNumber = p.PhoneNumber,
                FaxNumber = p.FaxNumber,
                EmailAddress = p.EmailAddress,
                ValidFrom = p.ValidFrom
            }).Where(per => per.FullName.Contains(fName)).ToList();

            //Used for the Customer Company Details
            var CustomerCoDetails = db.People
                                    .Where(p => p.FullName == fName)
                                    .Include("PrimaryContactPersonID")
                                    .SelectMany(p => p.Customers2).ToList();

            /// if they are a customer
            if(CustomerCoDetails.Count > 0) {

                //Details on the Purcased Items.
                var ItemDetails = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
                                    .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                    .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                    .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10).ToList();

                //A list of salespeople and the top 10 items sold to the customer
                var SalesP = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
                                             .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                             .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                             .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10)
                                             .Include("InvoiceID").Select(x => x.Invoice).Include("SalespersonID").Select(x => x.Person4)
                                             .ToList();
                
                /// Details on the Purchased Items
                List<PurchasedItem> Top10Items = new List<PurchasedItem>();

                //Intializes a list of PurchasedItem classes with details for the top 10 items bought by customer
                for (int i = 0; i < 10; i++)
                {
                    /// add each line of information for the top 10
                    Top10Items.Add(new PurchasedItem
                    {
                        StockItemID = ItemDetails.ElementAt(i).StockItemID,
                        ItemDescription = ItemDetails.ElementAt(i).Description,
                        LineProfit = ItemDetails.ElementAt(i).LineProfit,
                        SalesPerson = SalesP.ElementAt(i).FullName
                    });
                }

                ///Make a "list" of the singular customer information
                List <PersonVM> Customers = new List<PersonVM>
                {
                    new PersonVM{
                    ///The basic details for a person
                    FullName = result.First().FullName,
                    PreferredName = result.First().PreferredName,
                    PhoneNumber = result.First().PhoneNumber,
                    FaxNumber = result.First().FaxNumber,
                    EmailAddress = result.First().EmailAddress,
                    ValidFrom = result.First().ValidFrom,
                    ///The details for a customer's company
                    CompanyName = CustomerCoDetails.First().CustomerName,
                    CompanyPhone = CustomerCoDetails.First().PhoneNumber,
                    CompanyFax = CustomerCoDetails.First().FaxNumber,
                    CompanyWebsite = CustomerCoDetails.First().WebsiteURL,
                    CompanyValidFrom = CustomerCoDetails.First().ValidFrom,
                    /// The purchase history of that customer. Including Total orders, GrossSales and Gross profit.
                    Orders = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
                               .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders).Count(),

                    GrossSales = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
                                   .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                   .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices)
                                   .Include("InvoiceID").SelectMany(x => x.InvoiceLines).Sum(x => x.ExtendedPrice),

                    GrossProfit = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
                                   .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                   .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices)
                                   .Include("InvoiceID").SelectMany(x => x.InvoiceLines).Sum(x => x.LineProfit),
                    ///Details for the items purchased. Top 10 most profitable
                    ItemPurchaseList = Top10Items
                    }
                };
                ViewBag.MoreInfo = true;
                return View(Customers);
            }

            else {
                return View(result);
            }
        }
    }
}