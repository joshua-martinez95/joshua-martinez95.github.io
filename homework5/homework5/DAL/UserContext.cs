using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using homework5.Models;

namespace homework5.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=OurUsers")
        {

        }
        public virtual DbSet<User> Users { get; set; }
    }
}