using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;

namespace ProjectManager.Web.Controllers
{
    public class LookingForEmployeesController : Controller
    {
        IUnitOfWork _unitofwork;

        public LookingForEmployeesController(IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
        }

        public IActionResult LookingFor()
        {
            return View();
        }
    }
}