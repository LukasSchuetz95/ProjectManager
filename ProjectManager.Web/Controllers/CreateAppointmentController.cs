using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Controllers
{
    public class CreateAppointmentController : Controller
    {

        IUnitOfWork _unitOfWork;

        public CreateAppointmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult CreateAppointment()
        {
            return View();
        }
    }
}