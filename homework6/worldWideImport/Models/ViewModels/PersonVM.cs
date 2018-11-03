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

        public string FullName { get; set; }
        public string PreferredName { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string EmailAddress { get; set; }

        public DateTime ValidFrom { get; set; }
    }
}