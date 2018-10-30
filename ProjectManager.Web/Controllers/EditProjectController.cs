using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Web.Controllers
{
    public class EditProjectController : Controller
    {
        public IActionResult EditProject()
        {
            return View();
        }
    }
}