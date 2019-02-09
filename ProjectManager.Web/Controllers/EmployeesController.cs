using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models;
using ProjectManager.Web.Models.ViewModel;
using ProjectManager.Web.Models.ViewModel.Employees;

namespace ProjectManager.Web.Controllers
{
    public class EmployeesController : Controller
    {
        #region UnitOfWork

        IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork=unitOfWork;
        }

        #endregion

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
            if (model.LastnameFilter != null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByLastname(model.Filter);
                model = SetListFilterFalse(model);
            }
            else if (model.FirstnameFilter != null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByFirstname(model.Filter);
                model = SetListFilterFalse(model);
            }
            else if (model.JobFilter != null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByJob(model.Filter);
                model = SetListFilterFalse(model);
            }
            else if (model.DepartmentFilter != null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByDeparmentName(model.Filter);
                model = SetListFilterFalse(model);
            }
            else
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Profil

        public IActionResult Profil(int employeeId)
        {
            EmployeesProfilViewModel model = new EmployeesProfilViewModel();
            model.LoadProfilData(_unitOfWork, employeeId);
            if (model.Employee == null)
                return NotFound();

            return View(model);
        }



        public IActionResult EditProfil(int employeeId)
        {
            EmployeesEditProfilViewModel model = new EmployeesEditProfilViewModel();
            model.LoadEditProfilData(_unitOfWork, employeeId);
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
                //return RedirectToAction(nameof(Profil), new { employeeId = model.Employee.Id });
                model.Success = true;
            }
            else
            {
                model.LoadEditProfilData(_unitOfWork, model.Employee.Id);
                //return View(model);
                model.Success = false;
            }
            return View(model);
        }
        #endregion

        #region Create

        public IActionResult CreateEmployee()
        {
            return View();
        }

        #endregion

        public IActionResult Feed(int employeeId)
        {
            EmployeesFeedViewModel model = new EmployeesFeedViewModel();

            model.LoadFeedData(employeeId, _unitOfWork);            
            model.LoadWorkTasks();
            

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult AddTo(int taskId, EmployeesFeedViewModel model)
        {
            model.ChoosenTask = _unitOfWork.Tasks.GetById(taskId);

            model.WorkTasks.Add(model.ChoosenTask);

            return View(model);
        }

        [HttpPost]
        public IActionResult Feed(EmployeesFeedViewModel model)
        {
            if (model.ProjectFilter != null)
            {
                model.EmployeeTaskList = _unitOfWork.EmployeeTasks.GetAll();               
                model.LoadWorkTasks();
                
                model = SetFeedFilterFalse(model);
            }
            else if (model.GeneralFilter != null)
            {
                model.EmployeeTaskList = _unitOfWork.EmployeeTasks.GetAll();
                
                    model.LoadWorkTasks();
                
                model = SetFeedFilterFalse(model);
            }
            else if (model.PriorityFilter != null)
            {
                model.EmployeeTaskList = _unitOfWork.EmployeeTasks.GetAll();
                
                    model.LoadWorkTasks();
                
                model = SetFeedFilterFalse(model);
            }
            else
            {
                return NotFound();
            }

            return View(model);
        }

        #region Methods
        private EmployeesListViewModel SetListFilterFalse(EmployeesListViewModel model)
        {
            model.LastnameFilter = null;
            model.FirstnameFilter = null;
            model.JobFilter = null;
            model.DepartmentFilter = null;

            return model;
        }

        private EmployeesFeedViewModel SetFeedFilterFalse(EmployeesFeedViewModel model)
        {
            model.ProjectFilter = null;
            model.PriorityFilter = null;
            model.GeneralFilter = null;

            return model;
        }
        #endregion

    }
}