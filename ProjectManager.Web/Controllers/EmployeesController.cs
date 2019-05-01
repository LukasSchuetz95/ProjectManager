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
        private UserManager<ApplicationUser> _userManager;
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        #endregion

        #region Constructor

        public EmployeesController(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        #endregion

        #region List

        public IActionResult List()
        {
            EmployeesListViewModel model = new EmployeesListViewModel();
            model.LoadData(_unitOfWork);

            return View(model);
        }

        [HttpPost]
        public IActionResult List(EmployeesListViewModel model)
        {
            if (model.LastnameFilter != null)
            {
                model.LoadListData(_unitOfWork, 1);
            }
            else if (model.FirstnameFilter != null)
            {
                model.LoadListData(_unitOfWork, 2);
            }
            else if (model.JobFilter != null)
            {
                model.LoadListData(_unitOfWork, 3);
            }
            else if (model.DepartmentFilter != null)
            {
                model.LoadListData(_unitOfWork, 4);
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

            var userid = _userManager.GetUserId(HttpContext.User);

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
                return RedirectToAction(nameof(Profil), new
                {
                    employeeId = model.Employee.Id
                });
            }
            else
            {
                model.Error = true;
                model.LoadEditProfilData(_unitOfWork, model.Employee.Id);
                return View(model);
            }
        }
        #endregion

        #region Dashboard
        public async Task<ActionResult> Feed(int employeeId, string buttonClicked, bool priority, string error)
        {
            EmployeesFeedViewModel model = new EmployeesFeedViewModel();
            var user = await GetCurrentUserAsync();

            var EmployeeId = (int)user?.EmployeeId;

            if(employeeId == 0)
            {
                model.LoadDashboardData(EmployeeId, _unitOfWork);
            }
            else if (buttonClicked == null)
            {
                model.LoadDashboardData(employeeId, _unitOfWork);
            }
            else
            {
                model.Employee = _unitOfWork.Employees.GetById(employeeId);
                model.ButtonClicked = buttonClicked;
                GetFilteredList(model, priority);
            }

            if(error!=null)
            HandleOccuredError(model, error);           

            if (model == null)
                return NotFound();

            return View(model);
        }

        [HttpPost]
        public IActionResult Feed(EmployeesFeedViewModel model)
        {
            if (model.ProjectFilter != null)
            {
                model.LoadProjectDashboardData(model.Employee.Id, _unitOfWork, "All", IsPriorityButtonClicked(model.PriorityFilter));
            }
            else if (model.Assigned != null)
            {
                model.LoadDashboardData(model.Employee.Id, _unitOfWork);
            }
            else if (model.GeneralFilter != null)
            {
                model.LoadProjectDashboardData(model.Employee.Id, _unitOfWork, "General", IsPriorityButtonClicked(model.PriorityFilter));
            }
            else if (model.PriorityFilter != null)
            {
                GetFilteredList(model, IsPriorityButtonClicked(model.PriorityFilter));
            }
            else if (model.Search != null)
            {
                GetFilteredList(model, IsPriorityButtonClicked(model.PriorityFilter));            
            }
            else
            {
                return NotFound();
            }

            return View(model);
        }

        public IActionResult DeleteAppointment(int employeeId, int appointmentId, string buttonClicked, string priorityButton)
        {
            DashboardDisplay dashboardDisplay = _unitOfWork.DashboardDisplays.GetByEmployeeIdAndAppointmentId(employeeId, appointmentId);

            this.DeleteDashBoardTask(dashboardDisplay);
            _unitOfWork.Save();

            return RedirectToAction(nameof(Feed), new { employeeId = employeeId,
                                                        buttonClicked = buttonClicked,
                                                        priority = IsPriorityButtonClicked(priorityButton) });
        }

        public IActionResult AddTask(int employeeId ,int taskId , string buttonClicked, string priorityButton)
        { 
            return RedirectToAction(nameof(Feed), new { employeeId = employeeId,
                                                        buttonClicked = buttonClicked,
                                                        priority = IsPriorityButtonClicked(priorityButton),
                                                        error = CheckIfEmployeeTaskExists(employeeId, taskId)});
        }

        #region Feed : Methods

        public void GetFilteredList(EmployeesFeedViewModel model, bool priority)
        {
            if (model.ButtonClicked == "Project")
            {
                model.LoadProjectDashboardData(model.Employee.Id, _unitOfWork, "All", priority);
            }
            else if (model.ButtonClicked == "Assigned")
            {
                model.LoadDashboardData(model.Employee.Id, _unitOfWork);
            }
            else if (model.ButtonClicked == "General")
            {
                model.LoadProjectDashboardData(model.Employee.Id, _unitOfWork, "General", priority);
            }
        }

        public string CheckIfEmployeeTaskExists(int employeeId, int taskId)
        {
            string errorMessage=null;
            EmployeeTask employeeTask = new EmployeeTask();
            employeeTask = _unitOfWork.EmployeeTasks.GetByEmployeeIdAndTaskId(employeeId, taskId);

            if (employeeTask == null)
            {
                employeeTask = GenerateEmployeetask(employeeId, taskId);               

                if (CreateEmployeeTask(employeeTask))
                {
                    if (!SetUpForDashboardDisplay(employeeTask))
                    {
                        errorMessage = "Error during the creation of the DashboardDisplay!";
                    }                  
                }
                else
                {
                    errorMessage = "Error during the creation of the EmployeeTask!";
                }
            }
            else
            {
                employeeTask.Picked = true;

                if (UpdateEmployeeTask(employeeTask))
                {
                    if (!SetUpForDashboardDisplay(employeeTask))
                    {
                        errorMessage = "Error during the creation of the DashboardDisplay!";
                    }
                }
                else
                {
                    errorMessage = "Error during the update of the EmployeeTask!";
                }
            }

            return errorMessage;
        }       

        private bool IsPriorityButtonClicked(string priority)
        {
            return priority != null;
        }

        private void HandleOccuredError(EmployeesFeedViewModel model, string error)
        {
            model.Error = true;
            model.Errormessage = error;
        }
        #endregion

        #endregion

        #region FinishOrPass

        public IActionResult FinishOrPass(int employeeId, int taskId, string buttonClicked, bool priority)
        {
            EmployeesFinishOrPassViewModel model = new EmployeesFinishOrPassViewModel();
            model.LoadData(_unitOfWork, employeeId, taskId);
            model.ButtonClicked=buttonClicked;
            model.Priority = priority;
            return View(model);
        }

        [HttpPost]
        public IActionResult FinishOrPass(EmployeesFinishOrPassViewModel model)
        { 
            if (!CheckButtons(_unitOfWork, model.Employee.Id, model.Task.Id, model))
            {
                return NotFound();
            }

            if ((model.Finish == "Finish" && model.FinishConfirmed == true) || (model.Pass == "Pass" && model.PassConfirmed==true))
            {
                return RedirectToAction(nameof(Feed), new
                {
                    employeeId = model.Employee.Id,
                    buttonClicked = model.ButtonClicked,
                    priority = model.Priority
                });
            }
            else
            {
                return View(model);
            }
        }

        #region Methods

        public bool CheckButtons(IUnitOfWork uow, int employeeId, int taskId, EmployeesFinishOrPassViewModel model)
        {
            Task editTask = model.Task; EmployeeTask employeeTask = _unitOfWork.EmployeeTasks.GetByEmployeeIdAndTaskId(employeeId, taskId);

            if (model.Pass != null)
            {
                if (model.PassConfirmed == true)
                {
                    if (model.RecipientEmployee != null)
                    {
                        model.RecipientEmployee = _unitOfWork.Employees.GetById(model.RecipientEmployee.Id);

                        DashboardDisplay dashboardDisplay = _unitOfWork.DashboardDisplays.GetByEmployeeIdAndTaskId(employeeId, taskId);
                        DeleteDashBoardTask(dashboardDisplay);

                        employeeTask.PassedTask = model.RecipientEmployee;
                        UpdateEmployeeTask(employeeTask);

                        EmployeeTask recipientEmployeeTask = _unitOfWork.EmployeeTasks.GetByEmployeeIdAndTaskId(model.RecipientEmployee.Id, taskId);

                        if (model.FixedTask == false)
                        {
                            if (recipientEmployeeTask == null)
                            {
                                recipientEmployeeTask = GenerateEmployeetask(model.RecipientEmployee.Id, taskId);
                                recipientEmployeeTask.Picked = false;
                                CreateEmployeeTask(recipientEmployeeTask);
                            }
                            else
                            {
                                recipientEmployeeTask.Picked = false;
                                UpdateEmployeeTask(recipientEmployeeTask);                             
                            }

                            recipientEmployeeTask.Task.Status = Core.Enum.TaskStatusType.Open;                           
                        }
                        else
                        {
                            if (recipientEmployeeTask == null)
                            {
                                recipientEmployeeTask = GenerateEmployeetask(model.RecipientEmployee.Id, taskId);
                                recipientEmployeeTask.Picked = true;
                                CreateEmployeeTask(recipientEmployeeTask);
                            }
                            else
                            {
                                recipientEmployeeTask.Picked = true;
                                UpdateEmployeeTask(recipientEmployeeTask);                                
                            }

                            DashboardDisplay recipientDashboardDisplay = GenerateDashboardTask(recipientEmployeeTask);
                            CreateDashboardDisplay(recipientDashboardDisplay);
                        }

                        recipientEmployeeTask.Task.Information =  model.Task.Information;
                        recipientEmployeeTask.Task.Priority = model.Task.Priority;
                        recipientEmployeeTask.Task.ValuedTime = model.Task.ValuedTime;
                        UpdateTask(recipientEmployeeTask.Task);
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    model.PassClicked = true;
                    model.LoadSelectList(uow, employeeId, taskId);
                }
            }
            else if (model.Finish != null)
            {
                if (model.FinishConfirmed == true)
                {
                    DashboardDisplay dashboardDisplay = _unitOfWork.DashboardDisplays.GetByEmployeeIdAndTaskId(employeeId, taskId);
                    DeleteDashBoardTask(dashboardDisplay);

                    employeeTask.Task.Status = Core.Enum.TaskStatusType.Completed;
                    employeeTask.Task.Enddate = DateTime.Now;
                    UpdateTask(employeeTask.Task);
                }
                else
                {
                    model.FinishClicked = true;
                }
            }

            return true;
        }

        #endregion

        #endregion

        #region Update, Add and Delete

        private bool UpdateEmployeeTask(EmployeeTask employeeTask)
        {
            try
            {
                _unitOfWork.EmployeeTasks.Update(employeeTask);
                _unitOfWork.Save();
                return true;
            }
            catch (ValidationException ex)
            {                
                return false;
            }
        }

        private bool CreateEmployeeTask(EmployeeTask employeeTask)
        {
            try
            {
                _unitOfWork.EmployeeTasks.Add(employeeTask);
                _unitOfWork.Save();
                return true;

            }
            catch (ValidationException ex)
            {
                return false;
            }
        }

        private bool UpdateTask(Task task)
        {
            try
            {
                _unitOfWork.Tasks.Update(task);
                _unitOfWork.Save();
                return true;
            }
            catch (ValidationException ex)
            {
                return false;
            }
        }

        public bool CreateDashboardDisplay(DashboardDisplay dashboardDisplay)
        {
            try
            {
                _unitOfWork.DashboardDisplays.Add(dashboardDisplay);
                _unitOfWork.Save();
                return true;
            }
            catch (ValidationException ex)
            {
                return false;
            }
        }

        private void DeleteDashBoardTask(DashboardDisplay dashboardDisplay)
        {
            try
            {
                _unitOfWork.DashboardDisplays.Delete(dashboardDisplay);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
            }
        }

        private bool SetUpForDashboardDisplay(EmployeeTask employeeTask)
        {
            DashboardDisplay dashboardDisplay = GenerateDashboardTask(employeeTask);
       
            if (CreateDashboardDisplay(dashboardDisplay))
            {
                employeeTask.Task.Status = Core.Enum.TaskStatusType.Processing;

                return UpdateTask(employeeTask.Task);
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Generate

        private DashboardDisplay GenerateDashboardTask(EmployeeTask employeeTask)
        {
            DashboardDisplay dashboardTask = new DashboardDisplay();
            string endDate;

            if (employeeTask.Task.Deadline == null)
            {
                endDate = " open end";
            }
            else
            {
                endDate = " End: " + ((DateTime)(employeeTask.Task.Deadline)).ToString("d");
            }

            dashboardTask.Name = employeeTask.Task.TaskName;
            dashboardTask.Startdatum = DateTime.Now;
            dashboardTask.SpecificInformation = "Priority: " + Convert.ToString(employeeTask.Task.Priority);
            dashboardTask.Duration = "Start: " + (dashboardTask.Startdatum).ToString("d") + endDate;
            dashboardTask.Employee = employeeTask.Employee;
            dashboardTask.EmployeeId = employeeTask.Employee.Id;
            dashboardTask.TaskId = employeeTask.Task.Id;

            return dashboardTask;
        }

        private EmployeeTask GenerateEmployeetask(int employeeId, int taskId)
        {
            EmployeeTask employeeTask = new EmployeeTask();
            employeeTask.Employee = _unitOfWork.Employees.GetById(employeeId);
            employeeTask.Task = _unitOfWork.Tasks.GetById(taskId);
            employeeTask.TaskId = taskId;
            employeeTask.EmployeeId = employeeId;
            employeeTask.Picked = true;

            return employeeTask;
        }

        #endregion
    }
}