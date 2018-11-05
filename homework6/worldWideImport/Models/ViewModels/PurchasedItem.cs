using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using worldWideImport.Models;
using worldWideImport.DAL;

namespace worldWideImport.Models.ViewModels
{
    public class PurchasedItem
    {
        public int StockItemID { get; set; }
        public string ItemDescription { get; set; }
        public decimal LineProfit { get; set; }
        public string SalesPerson { get; set; }
    }
}