using ProductManagementWeb.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWeb.Models
{
    public class Product:CommonProperty
    {
        public int Stock { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}