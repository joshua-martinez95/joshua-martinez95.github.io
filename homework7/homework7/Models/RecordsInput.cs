namespace homework7.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RecordsInput
    {

        public int ID { get; set; }

        /// <summary>
        /// for date and time
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// for the input strings
        /// </summary>
        [Required]
        [StringLength(120)]
        public string Input { get; set; }

        /// <summary>
        /// the ip of the user
        /// </summary>
        [Required]
        [StringLength(16)]
        public string IP { get; set; }

        /// <summary>
        /// the broswer agent
        /// </summary>
        [Required]
        [StringLength(25)]
        public string BrowserAG { get; set; }
    }
}
