using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models;
using ProjectManager.Web.Models.ViewModel;

namespace ProjectManager.Web.Controllers
{
    public class EmployeesController : Controller
    {
        IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Feed()
        {
            return View();
        }

        public IActionResult List()
        {
            EmployeesListViewModel model = new EmployeesListViewModel();
            model.Employees = _unitOfWork.Employees.GetEmployeeByLastname();
            return View(model);
        }

        [HttpPost]
        public IActionResult List(EmployeesListViewModel model)
        {
            if (model.FilterFirstname == null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByLastname(model.FilterLastname);
                return View(model);
            }
            else
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByFirstname(model.FilterFirstname);
                return View(model);
            }

        }
    }
}