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


        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchString)
        {
            ViewBag.result = searchString;

                List<PersonVM> listPeople = db.People.Select(p => new PersonVM
                {
                    FullName = p.FullName,
                    PreferredName = p.PreferredName,
                    PhoneNumber = p.PhoneNumber,
                    FaxNumber = p.FaxNumber,
                    EmailAddress = p.EmailAddress,
                    ValidFrom = p.ValidFrom
                }).Where(per => per.FullName.Contains(searchString)).ToList();

            if(listPeople.Count > 0)
            {
                ViewBag.toggle = 1;
                ViewBag.result = "Search results for \"" + searchString + "\"";
            }
            
            else
            {
                ViewBag.result = "Sorry, no results have been made!";
                return View(listPeople);
            }

            return View(listPeople);

        }

        [HttpPost]
        public ActionResult Details()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Details(String fName)
        {
            if (fName == null || fName == "")
            {
                return (RedirectToAction("Index"));
            }
            Debug.WriteLine(fName);
            List<PersonVM> result = db.People.Select(p => new PersonVM
            {
                FullName = p.FullName,
                PreferredName = p.PreferredName,
                PhoneNumber = p.PhoneNumber,
                FaxNumber = p.FaxNumber,
                EmailAddress = p.EmailAddress,
                ValidFrom = p.ValidFrom
            }).Where(per => per.FullName.Contains(fName)).ToList();

            //Customer Company Details. See PersonVM.cs
            var CustomerDetails = db.People
                                    .Where(p => p.FullName == fName)
                                    .Include("PrimaryContactPersonID")
                                    .SelectMany(p => p.Customers2).ToList();


            try {
                //Items Purchased Details See PersonVM.cs. This query navigates through several tables to get the return the 
                var ItemDetails = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
                                    .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                    .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                    .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10).ToList();

                //A list of salesman for the top 10 items sold to the customer.
                var SalesMen = db.People.Where(person => person.FullName.Contains(fName)).Include("PrimaryContactPersonID")
                                             .SelectMany(x => x.Customers2).Include("CustomerID").SelectMany(x => x.Orders)
                                             .Include("OrderID").Include("CustomerID").SelectMany(x => x.Invoices).Include("InvoiceID")
                                             .SelectMany(x => x.InvoiceLines).OrderByDescending(x => x.LineProfit).Take(10)
                                             .Include("InvoiceID").Select(x => x.Invoice).Include("SalespersonID").Select(x => x.Person4)
                                             .ToList();
                //Items Purchased Details see PersonVM.cs

                List<PurchasedItem> Top10Items = new List<PurchasedItem>();

                //Intializes a list of ItemPurchased classes that contains the details for the top 10 items sold to the customer.
                for (int i = 0; i < 10; i++)
                {
                    Top10Items.Add(new PurchasedItem
                    {
                        StockItemID = ItemDetails.ElementAt(i).StockItemID,
                        ItemDescription = ItemDetails.ElementAt(i).Description,
                        LineProfit = ItemDetails.ElementAt(i).LineProfit,
                        SalesPerson = SalesMen.ElementAt(i).FullName
                    });

                }

                List <PersonVM> Customers = new List<PersonVM>
                {
                    new PersonVM{
                    //Default Details See PersonVM.cs. Basic details about the person being searched.
                    FullName = result.First().FullName,
                    PreferredName = result.First().PreferredName,
                    PhoneNumber = result.First().PhoneNumber,
                    FaxNumber = result.First().FaxNumber,
                    EmailAddress = result.First().EmailAddress,
                    ValidFrom = result.First().ValidFrom,
                    //Customer Company Details; See PersonVM.cs. Details about the customer's company.
                    CompanyName = CustomerDetails.First().CustomerName,
                    CompanyPhone = CustomerDetails.First().PhoneNumber,
                    CompanyFax = CustomerDetails.First().FaxNumber,
                    CompanyWebsite = CustomerDetails.First().WebsiteURL,
                    CompanyValidFrom = CustomerDetails.First().ValidFrom,
                    //Purchase History Details; See PersonVM.cs. Total orders, GrossSales and Gross profit for those orders.
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
                    //Items purchased details. A list of details about the top 10 most profitable items sold to the customer. See ItemPurchased.cs
                    PurchaseItemSummary = Top10Items
                    }
                };
/*
                Debug.WriteLine(Customer.FullName);
                Debug.WriteLine(Customer.PreferredName);
                Debug.WriteLine(Customer.PhoneNumber);
                Debug.WriteLine(Customer.FaxNumber);
                Debug.WriteLine(Customer.EmailAddress);
                Debug.WriteLine(Customer.ValidFrom);
                Debug.WriteLine(Customer.CompanyName);
                Debug.WriteLine(Customer.CompanyPhone);
                Debug.WriteLine(Customer.CompanyFax);
                Debug.WriteLine(Customer.CompanyWebsite);
                Debug.WriteLine(Customer.CompanyValidFrom);
                Debug.WriteLine(Customer.Orders);
                Debug.WriteLine(Customer.GrossSales);
                Debug.WriteLine(Customer.GrossProfit);
                for (int x = 0; x < 10; x++)
                {
                    Debug.WriteLine(Customer.PurchaseItemSummary.ElementAt(x).StockItemID);
                    Debug.WriteLine(Customer.PurchaseItemSummary.ElementAt(x).ItemDescription);
                    Debug.WriteLine(Customer.PurchaseItemSummary.ElementAt(x).LineProfit);
                    Debug.WriteLine(Customer.PurchaseItemSummary.ElementAt(x).SalesPerson);

                }
                */
                return View(Customers);
            }

            catch (System.Data.Entity.Core.EntityCommandExecutionException) { }
            return View(result);
        }
    }
}