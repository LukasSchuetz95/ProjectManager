using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models.ViewModel;
using ProjectManager.Web.Models.ViewModel.Departments;

namespace ProjectManager.Web.Controllers
{
    public class DepartmentsController : Controller
    { 
        #region unitOfWork
        IUnitOfWork _unitOfWork;

        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public IActionResult List()
        {
            DepartmentsViewModel model = new DepartmentsViewModel();
           model.DepartmentList = _unitOfWork.Departments.GetAll();
            return View(model);
        }

        public IActionResult Details(int departmentId)
        {
            DepartmentsViewModel model = new DepartmentsViewModel();
            model.EmployeeList = _unitOfWork.Employees.GetEmployeeByDepartmentId(departmentId);
            model.Department = _unitOfWork.Departments.GetById(departmentId);
            return View(model);
        }

        public IActionResult Create()
        {
            CreateDepartmentViewModel model = new CreateDepartmentViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Save = true;
                    _unitOfWork.Departments.Add(model.Department);
                    _unitOfWork.Departments.Add(model.Department);
                    _unitOfWork.Save();
                    model.Success = true;
                }
                catch (ValidationException ex)
                {                   
                    model.Success = false;
                }
            }

            return View(model);
        }
    }
}