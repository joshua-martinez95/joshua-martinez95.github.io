using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using homework7_2.Models;

namespace homework7_2.DAL
{
    public class RecordsInputsContext : DbContext
    {
        public RecordsInputsContext() : base("name=OurRecordsInputs")
        {

        }

        public virtual DbSet<RecordsInput> RecordsInput { get; set; }

    }
}