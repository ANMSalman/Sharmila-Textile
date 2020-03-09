using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Sharmila_Textile_WebApp.Controllers {
    public class LoginController : Controller {
        public IActionResult Index() { 
            return View();  
        }

        public IActionResult Logout() {
            HttpContext.Session.SetString("loggedIn", "false");
            return RedirectToAction("Index", "Login"); 
        }
    }
}