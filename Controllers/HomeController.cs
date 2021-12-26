using ApartmanProjeMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace ApartmanProjeMVC.Controllers
{
    
    public class HomeController : Controller
    {
        ApartmanYonetimEntities baglan = new ApartmanYonetimEntities();
        
        public ActionResult Login()
        {
            
            return View();
        }
        

    }
}