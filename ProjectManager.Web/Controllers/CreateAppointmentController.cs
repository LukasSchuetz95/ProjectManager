using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManager.Web.Controllers
{
    public class CreateAppointmentController : Controller
    {
        public IActionResult CreateAppointment()
        {
            return View();
        }
    }
}