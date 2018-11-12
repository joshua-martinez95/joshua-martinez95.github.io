namespace homework7.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using homework7.Models;

    public partial class RecordsContext : DbContext
    {
        public RecordsContext()
            : base("name=RecordsContext")
        {
        }

        public virtual DbSet<RecordsInput> RecordsInputs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RecordsInput>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<RecordsInput>()
                .Property(e => e.BrowserAG)
                .IsUnicode(false);
        }
    }
}
