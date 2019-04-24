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
        private readonly UserManager<ApplicationUser> _userManager;

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

            //var userid = _userManager.GetUserId(HttpContext.User);

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

        #region Dashboard
        public IActionResult Feed(int employeeId, string buttonClicked, bool priority, string error)
        {
            EmployeesFeedViewModel model = new EmployeesFeedViewModel();

            if (buttonClicked == null)
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
            //error
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

        public IActionResult FinishOrPass(int employeeId, int taskId)
        {
            EmployeesFinishOrPassViewModel model = new EmployeesFinishOrPassViewModel();
            model.LoadData(_unitOfWork, employeeId, taskId);

            return View(model);
        }

        [HttpPost]
        public IActionResult FinishOrPass(EmployeesFinishOrPassViewModel model)
        {
            model.LoadData(_unitOfWork, model.Employee.Id, model.Task.Id);

            if (!CheckButtons(_unitOfWork, model.Employee.Id, model.Task.Id, model))
            {
                return NotFound();
            }

            if ((model.Finish == "Finish" && model.FinishConfirmed == true) || (model.Pass == "Pass" && model.PassConfirmed==true))
            {
                return RedirectToAction(nameof(Feed), new { employeeId = model.Employee.Id });
            }
            else
            {
                return View(model);
            }
        }

        #region Methods
        //Nachvollziehen die Dashboarddisplay löschen oder wert setzen und nicht mehr anzeigen lassen?
        //Wenn picked wieder false ist zeigt es den employeetasl wieder bei allen anderen zugeordneten an, fallse der 
        //Task enum verändert wurde, nochmal gründlich überdenken, bedingungen in der persistance ansehen und entity checken
        //Passedto den empfänger speichern und in der persistence auf null abfragen? wenn was drin steht nicht mehr im eigenen feed anzeigen(geht nicht ganz)
        //Die Frage ist ob bei einem pass auch bei allen vorher zugeteilten Employees der Task angezeigt werden soll,
        //mit packed true könnte in wieder der zugeteilte sehen dann muss aber auch der Taskstatus geändert werden
        //Werte die gesetzt werden sollten checken wenn der Datensatz nicht gelöscht werden soll
        //create new dispalay if fixedtask wird benutzt
        //enum mit weitergereicht machen
        //delete employeetask wieder in update ändern da es wenn man einfach weiter oben auch den passto auf nulls setzt auch
        //bei mehrmaligem herumreichen immer wieder angezeigt wird
        public bool CheckButtons(IUnitOfWork uow, int employeeId, int taskId, EmployeesFinishOrPassViewModel model)
        {
            if (model.Pass != null)
            {
                if (model.PassConfirmed == true)
                {
                    if (model.RecipientEmployee != null)
                    {
                        DashboardDisplay dashboardDisplay = _unitOfWork.DashboardDisplays.GetByEmployeeIdAndTaskId(employeeId, taskId);
                        DeleteDashBoardTask(dashboardDisplay);

                        EmployeeTask employeeTask = _unitOfWork.EmployeeTasks.GetByEmployeeIdAndTaskId(employeeId, taskId);
                        DeleteEmployeeTask(employeeTask);

                        EmployeeTask recipientEmployeeTask = GenerateEmployeetask(model.RecipientEmployee.Id, taskId);
                        recipientEmployeeTask.Picked = false;
                        CreateEmployeeTask(recipientEmployeeTask);

                        //Zwischenschritt einbauen im ENUM
                        employeeTask.Task.Status = Core.Enum.TaskStatusType.Open;
                        UpdateTask(employeeTask.Task);

                        //Nur wenn fixed Task true ist
                        //DashboardDisplay recipientDashboardDisplay = GenerateDashboardTask(recipientEmployeeTask);
                        //CreateDashboardDisplay(recipientDashboardDisplay);
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

                    model.Task.Status = Core.Enum.TaskStatusType.Completed;
                    model.Task.Enddate = DateTime.Now;
                    UpdateTask(model.Task);
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

        private bool DeleteEmployeeTask(EmployeeTask employeeTask)
        {
            try
            {
                _unitOfWork.EmployeeTasks.Delete(employeeTask);
                _unitOfWork.Save();
                return true;
            }
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(valResult.MemberNames.First(), valResult.ErrorMessage);
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
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(valResult.MemberNames.First(), valResult.ErrorMessage);
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

        //public bool IsNullOrEmpty(string check)
        //{
        //    return check != null || check.Trim() != "";
        //}
    }
}