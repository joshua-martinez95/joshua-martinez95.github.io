using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace homework5.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required, Display(Name = "First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        //[Required]
        ///public string PhoneNumber { get; set; }

        [Required, DataType(DataType.PhoneNumber), RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please format to 999-999-9999"), Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }

        [Required, Display(Name = "Unit number")]
        public int AptNumber { get; set; }

        [Required, Display(Name = "Name of building")]
        public string AptName { get; set; }

        [Required, Display(Name = "In detail, describe reason for invoice.")]
        public string Comment { get; set; }

        [Required, Display(Name = "Please confirm permission to share this.")]
        public bool CheckBox { get; set; }

        private DateTime timeDate = DateTime.Now;
        [Required, Display(Name = "Time Requested")]
        public DateTime TimeRequest
        {
            get { return timeDate; }
            set { timeDate = value; }
        }
    }
}