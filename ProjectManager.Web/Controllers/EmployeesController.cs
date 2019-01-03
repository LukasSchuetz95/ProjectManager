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
            _unitOfWork=unitOfWork;
        }

        #region List

        public IActionResult List()
        {
            EmployeesListViewModel model = new EmployeesListViewModel();
            model.Employees = _unitOfWork.Employees.GetEmployeeByLastname();
            return View(model);
        }

        [HttpPost]
        public IActionResult List(EmployeesListViewModel model)
        {
            if (model.FilterFirstname == null && model.FilterJob == null && model.FilterDepartmentName == null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByLastname(model.FilterLastname);
                return View(model);
            }
            else if (model.FilterLastname == null && model.FilterJob == null && model.FilterDepartmentName == null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByFirstname(model.FilterFirstname);
                return View(model);
            }
            else if (model.FilterLastname == null && model.FilterFirstname == null && model.FilterDepartmentName == null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByJob(model.FilterJob);
                return View(model);
            }
            else if (model.FilterLastname == null && model.FilterFirstname == null && model.FilterJob == null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByDeparmentName(model.FilterDepartmentName);
                return View(model);
            }
            else
                return NotFound();
        }

        #endregion

        #region Profil

        public IActionResult Profil(int employeeId)
        {
            EmployeesProfilViewModel model = new EmployeesProfilViewModel();
            model.LoadData(_unitOfWork, employeeId);
            if (model.Employee == null)
                return NotFound();

            return View(model);
        }



        public IActionResult EditProfil(int employeeId)
        {
            EmployeesEditProfilViewModel model = new EmployeesEditProfilViewModel();
            model.LoadData(_unitOfWork, employeeId);
            if (model.Employee == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult EditProfil(EmployeesEditProfilViewModel model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employees.Update(model.Employee);
                _unitOfWork.Save();
                return RedirectToAction("Profil");
            }
            else
            {
                model.LoadData(_unitOfWork, model.Employee.Id);
                return View(model);
            }
        }
        #endregion

        #region Create

        public IActionResult CreateEmployee()
        {
            return View();
        }

        #endregion

        public IActionResult Feed()
        {
            return View();
        }

    }
}