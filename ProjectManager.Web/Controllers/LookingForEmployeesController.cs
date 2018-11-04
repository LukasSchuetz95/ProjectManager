using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Controllers
{
    public class LookingForEmployeesController : Controller
    {
        IUnitOfWork _unitOfWork;

        public LookingForEmployeesController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public IActionResult LookingFor()
        {
            LookingForEmployeeModel model = new LookingForEmployeeModel();
            model.Employees = _unitOfWork.Employees.GetAll();
            return View(model);
        }
    }
}