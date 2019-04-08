using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Web.Models;
using ProjectManager.Web.Models.ViewModel;
using ProjectManager.Web.Models.ViewModel.Employees;
using Task = ProjectManager.Core.Entities.Task;

namespace ProjectManager.Web.Controllers
{
    public class EmployeesController : Controller
    {

        #region fields

        IUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

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
            }
            else if (model.FirstnameFilter != null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByFirstname(model.Filter);
            }
            else if (model.JobFilter != null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByJob(model.Filter);
            }
            else if (model.DepartmentFilter != null)
            {
                model.Employees = _unitOfWork.Employees.GetEmployeeByDeparmentName(model.Filter);
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
                model.Success = true;
            }
            else
            {
                model.LoadEditProfilData(_unitOfWork, model.Employee.Id);
            }
            return View(model);
        }
        #endregion

        #region Create

        /// <summary>
        /// Created by Lukas Schütz
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateEmployee(EmployeesCreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Employee.DepartmentId = 1;
                    _unitOfWork.Employees.Add(model.Employee);
                    _unitOfWork.Save();
                    return RedirectToAction("List", "Employees");

                    //model.EmployeeProject.Projectmanager = true;
                    //_unitOfWork.Projects.Add(model.EmployeeProject.Project);
                    //_unitOfWork.EmployeeProjects.Add(model.EmployeeProject);
                    //_unitOfWork.Save();
                    //return RedirectToAction("Create", "EmployeeProjects", new { projectId = model.EmployeeProject.ProjectId });
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }

        #endregion

        #region Feed
        public IActionResult Feed(int employeeId)
        {
            EmployeesFeedViewModel model = new EmployeesFeedViewModel();
            model.Employee = _unitOfWork.Employees.GetById(employeeId);
            model.LoadFeedTasks();

            model.LoadFeedData(employeeId, _unitOfWork);

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Feed(EmployeesFeedViewModel model)
        {
            if (model.ProjectFilter != null)
            {
                model.LoadProjectFeedData(model.Employee.Id, _unitOfWork);
            }
            else if (model.Assigned != null)
            {
                model.LoadFeedData(model.Employee.Id, _unitOfWork);
            }
            else if (model.GeneralFilter != null)
            {
                model.LoadGeneralFeedData(model.Employee.Id, _unitOfWork);
            }
            else if (model.PriorityFilter != null)
            {
                GetFilteredList(model, true);
            }
            else if (model.AddTask != null)
            {
                int taskId = Convert.ToInt32(model.AddTask);

                CheckIfEmployeeTaskExists(model.Employee.Id, taskId, model);

                //DeleteErrorMessage();

                GetFilteredList(model, false);
            }
            else if (model.Search != null)
            {
                GetFilteredList(model, false);
            }
            else
            {
                return NotFound();
            }

            return View(model);
        }

        #endregion

        #region Methods

        public void GetFilteredList(EmployeesFeedViewModel model, bool priority)
        {
            if (model.ButtonClicked == "Project")
            {
                model.LoadProjectFeedData(model.Employee.Id, _unitOfWork);

                model = RemoveLowPriorityTasks(model, priority);
            }
            else if (model.ButtonClicked == "Assigned")
            {
                model.LoadFeedData(model.Employee.Id, _unitOfWork);

                model = RemoveLowPriorityTasks(model, priority);
            }
            else if (model.ButtonClicked == "General")
            {
                model.LoadGeneralFeedData(model.Employee.Id, _unitOfWork);

                model = RemoveLowPriorityTasks(model, priority);
            }
        }

        public EmployeesFeedViewModel RemoveLowPriorityTasks(EmployeesFeedViewModel model, bool priority)
        {
            List<Task> checkTasks = new List<Task>();
            checkTasks.AddRange(model.PoolTasks);

            if (priority)
            {
                foreach (var obj in checkTasks)
                {
                    if (obj.Priority != Core.Enum.PriorityType.Hoch)
                    {
                        model.PoolTasks.Remove(obj);
                    }
                }
            }

            return model;
        }

        #region Update and Create

        public bool CheckIfEmployeeTaskExists(int employeeId, int taskId, EmployeesFeedViewModel model)
        {
            EmployeeTask employeeTask = GenerateEmployeetask(employeeId, taskId);

            if (CheckIfEmployeeTaskIsAlreadyExsisting(employeeTask))
            {
                return TryToAddEmployeeTask(employeeTask, model);
            }
            else
            {
                return TryToUpdateEmployeeTask(employeeTask, model);
            }
        }

        private void UpdateTask(EmployeeTask employeeTask)
        {
            Task task = _unitOfWork.Tasks.GetById(employeeTask.Id);
            task.Status = Core.Enum.TaskStatusType.InArbeit;

            try
            {
                _unitOfWork.Tasks.Update(task);
                _unitOfWork.Save();
                UpdateTask(employeeTask);
            }
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(valResult.MemberNames.First(), valResult.ErrorMessage);
            }
        }

        private bool TryToUpdateEmployeeTask(EmployeeTask employeeTask, EmployeesFeedViewModel model)
        {
            employeeTask = _unitOfWork.EmployeeTasks.GetByEmployeeIdAndTaskId(employeeTask.TaskId, employeeTask.EmployeeId);
            employeeTask.InWork = true;
            try
            {
                _unitOfWork.EmployeeTasks.Update(employeeTask);
                _unitOfWork.Save();
                CreateFeedDisplay(model, employeeTask);
                UpdateTask(employeeTask);
                return true;
            }
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(valResult.MemberNames.First(), valResult.ErrorMessage);
                return false;
            }
        }

        private bool TryToAddEmployeeTask(EmployeeTask employeeTask, EmployeesFeedViewModel model)
        {
            try
            {
                _unitOfWork.EmployeeTasks.Add(employeeTask);
                _unitOfWork.Save();
                CreateFeedDisplay(model, employeeTask);
                UpdateTask(employeeTask);
                return true;

            }
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(valResult.MemberNames.First(), valResult.ErrorMessage);
                return false;
            }
        }

        public void CreateFeedDisplay(EmployeesFeedViewModel model, EmployeeTask employeeTask)
        {
            FeedDisplay feedDisplay = new FeedDisplay();
            Task task = _unitOfWork.Tasks.GetById(employeeTask.TaskId);
            //feedDisplay.task = task;
            //feedDisplay.taskId = task.Id;
            //feedDisplay.appointment = null;
            //feedDisplay.appointmentId = 0;

            try
            {
                _unitOfWork.FeedDisplays.Add(feedDisplay);
                _unitOfWork.Save();
            }
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(valResult.MemberNames.First(), valResult.ErrorMessage);
            }
        }

        #region Sonstiges

        private EmployeeTask GenerateEmployeetask(int employeeId, int taskId)
        {
            EmployeeTask employeeTask = new EmployeeTask();
            employeeTask.Employee = _unitOfWork.Employees.GetById(employeeId);
            employeeTask.Task = _unitOfWork.Tasks.GetById(taskId);
            employeeTask.TaskId = taskId;
            employeeTask.EmployeeId = employeeId;
            employeeTask.InWork = true;

            return employeeTask;
        }

        private bool CheckIfEmployeeTaskIsAlreadyExsisting(EmployeeTask employeeTask)
        {
            List<EmployeeTask> employeeTaskList = _unitOfWork.EmployeeTasks.GetAllByEmployeeId(employeeTask.EmployeeId);

            foreach (var eTL in employeeTaskList)
            {
                if (employeeTask.EmployeeId == eTL.EmployeeId && employeeTask.TaskId == eTL.TaskId)
                {
                    return false;
                }
            }

            return true;
        }

        //private static async DeleteErrorMessage()
        //{

        //}

        #endregion

        #endregion

        #endregion

    }
}