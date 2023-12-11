using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ProductManagementWeb.Models;

namespace ProductManagementWeb.Entity
{
    public class DataContext:DbContext
    {
        public DataContext():base("DbConnection") { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Slider> Slider { get; set; }
    }
}