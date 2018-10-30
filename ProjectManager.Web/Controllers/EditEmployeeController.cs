using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Web.Controllers
{
    public class EditEmployeeController : Controller
    {
        public IActionResult Edit()
        {
            return View();
        }
    }
}