using ProductManagementWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementWeb.Controllers
{
    [Authorize(Roles ="Admin,User")]
    //[Authorize]
    public class PanelController : Controller
    {
        // GET: Panel
        //[AllowAnonymous]
        public ActionResult Index()
        {
          
            
            return View();
        }
    }
}