using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace crud1.Models
{
    public class Cs:DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Catagory> catagory { get; set; }
    }
}