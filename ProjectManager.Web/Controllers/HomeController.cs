using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult LoginScreen()
        {
            return View();
        }
        
        public IActionResult EditEmployee()
        {
            return View();
        }

        public IActionResult Profil()
        {
            return View();
        }

        public IActionResult CreateTask()
        {
            return View();
        }

        public IActionResult Feed()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
