using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
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
            model.LoadListData(_unitOfWork);
            return View(model);
        }

        public IActionResult Details(int departmentId)
        {
            DepartmentsViewModel model = new DepartmentsViewModel();
            model.LoadDeatilsData(departmentId, _unitOfWork);
            return View(model);
        }

        public IActionResult Delete(int departmentId)
        {
            DepartmentsViewModel model = new DepartmentsViewModel();

            if (model.CountEmployeesOfThisDepartment(_unitOfWork.Departments.GetById(departmentId), _unitOfWork) == 0)
            {
                DeleteDepartment(_unitOfWork.Departments.GetById(departmentId));
                return RedirectToAction(nameof(List));
            }
            else
            {
                return RedirectToAction(nameof(ConfirmDelete), new { departmentId = departmentId });
            }
        }

        public IActionResult ConfirmDelete(int departmentId)
        {
            DepartmentsViewModel model = new DepartmentsViewModel();
            model.LoadConfirmDeleteData(departmentId, _unitOfWork);
            return View(model);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(DepartmentsViewModel model)
        {
            model.AssignDepartment = _unitOfWork.Departments.GetById(model.AssignDepartment.Id);
            model.EmployeeList = _unitOfWork.Employees.GetEmployeeByDepartmentId(model.Department.Id);

            foreach (var emp in model.EmployeeList)
            {
                emp.DepartmentId = model.AssignDepartment.Id;
                emp.Department = model.AssignDepartment;

                _unitOfWork.Employees.Update(emp);
                _unitOfWork.Save();
            }

            DeleteDepartment(_unitOfWork.Departments.GetById(model.Department.Id));

            return RedirectToAction(nameof(List));
        }

        private void DeleteDepartment(Department department)
        {
            try
            {
                _unitOfWork.Departments.Delete(department);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {

            }
        }

        public IActionResult Create(string routeString, int routeId)
        {
            CreateDepartmentViewModel model = new CreateDepartmentViewModel();
            model.LoadData(routeString, routeId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateDepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Departments.Add(model.Department);
                    _unitOfWork.Departments.Add(model.Department);
                    _unitOfWork.Save();
                    model.Success = true;
                }
                catch (ValidationException ex)
                {
                    model.Error = true;
                }
            }

            return View(model);
        }
    }
}