using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models.ViewModel;

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
            return View(model);
        }  
        
        public IActionResult Create()
        {
            return View();
        }
    }
}