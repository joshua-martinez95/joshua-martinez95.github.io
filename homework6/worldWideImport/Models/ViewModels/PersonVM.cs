﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using worldWideImport.Models;
using worldWideImport.DAL;

namespace worldWideImport.Models.ViewModels
{
    public class PersonVM
    {
        //Default Details
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ValidFrom { get; set; }

        //Customer Company Details information
        public string CompanyName { get; set; }
        public string CompanyPhone { get; set; }
        public string CompanyFax { get; set; }
        public string CompanyWebsite { get; set; }
        public DateTime CompanyValidFrom { get; set; }

        //Purchase History Details information
        public double Orders { get; set; }
        public decimal GrossSales { get; set; }
        public decimal GrossProfit { get; set; }

        //Items Purchased Details information. Seen in PurchasedItem.cs
        public List<PurchasedItem> ItemPurchaseList { get; set; }
    }
}