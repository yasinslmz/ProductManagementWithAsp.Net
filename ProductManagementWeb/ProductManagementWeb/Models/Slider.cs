using ProductManagementWeb.Entity.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductManagementWeb.Models
{
    public class Slider:CommonProperty
    {
        public string Url { get; set; }
        public int Number { get; set; }
        public bool IsButton { get; set; }
        public string ButtonText { get; set; }
        public string ButtonClasses { get; set; }
        public string Title { get; set; }
        public string TitleClasses { get; set; }
        public string ContentText { get; set; }
        public string ContentTextClasses { get; set; }
    }
}