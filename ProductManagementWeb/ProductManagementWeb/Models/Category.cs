using ProductManagementWeb.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWeb.Models
{
    public class Category:CommonProperty
    {
        public List<Product> Products { get; set; }
    }
}