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

        public DateTime Date { get; set; }

        [Required]
        [StringLength(120)]
        public string Input { get; set; }

        [Required]
        [StringLength(16)]
        public string IP { get; set; }

        [Required]
        [StringLength(25)]
        public string BrowserAG { get; set; }
    }
}
