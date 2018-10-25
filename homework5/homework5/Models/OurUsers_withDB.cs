using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace homework5.Models
{
    public class OurUsers_withDB
    {
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int AptNumber { get; set; }

        [Required]
        public string AptName { get; set; }

        [Required]
        public bool checkBox { get; set; }
    }
}