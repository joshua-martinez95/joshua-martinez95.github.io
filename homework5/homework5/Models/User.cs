using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace homework5.Models
{
    /// <summary>
    /// the class for entries
    /// </summary>
    public class User
    {
        /// <summary>
        /// The key ID for each entry
        /// </summary>
        [Key]
        public int ID { get; set; }

        /// <summary>
        /// How the First name will/should look like
        /// </summary>
        [Required, Display(Name = "First Name")]
        [StringLength(20)]
        public string FirstName { get; set; }

        /// <summary>
        /// how Last name will/should look like
        /// </summary>
        [Required, Display(Name = "Last Name")]
        public string LastName { get; set; }

        /// <summary>
        /// how phone number will/should look like with certain pattern
        /// </summary>
        [Required, DataType(DataType.PhoneNumber), RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Please format to 999-999-9999"), Display(Name = "Phone Number")]
        public string PhoneNum { get; set; }

        /// <summary>
        /// Unit number in integer
        /// </summary>
        [Required, Display(Name = "Unit number")]
        public int AptNumber { get; set; }

        /// <summary>
        /// Name of building
        /// </summary>
        [Required, Display(Name = "Name of building")]
        public string AptName { get; set; }

        /// <summary>
        /// Comment field
        /// </summary>
        [Required, Display(Name = "In detail, describe reason for invoice.")]
        public string Comment { get; set; }

        /// <summary>
        /// check box
        /// </summary>
        [Required, Display(Name = "Please confirm permission to share this.")]
        public bool CheckBox { get; set; }

        /// <summary>
        /// get date and time of submission
        /// </summary>
        private DateTime timeDate = DateTime.Now;
        [Required, Display(Name = "Time Requested")]
        public DateTime TimeRequest
        {
            get { return timeDate; }
            set { timeDate = value; }
        }
    }
}