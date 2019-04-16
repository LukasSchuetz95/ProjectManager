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
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region List

        public IActionResult List()
        {
            EmployeesListViewModel model = new EmployeesListViewModel();
            model.Employees = _unitOfWork.Employees.GetAll();

            model.SwitchOrderLastName = true;
            model.SwitchOrderFirstName = true;
            model.SwitchOrderJob = true;
            model.SwitchOrderDepartment = true;

            return View(model);
        }

        [HttpPost]
        public IActionResult List(EmployeesListViewModel model)
        {
            if (model.LastnameFilter != null)
            {
                SetBackSwitchOrders(1, model);
                model.SwitchOrderLastName = SwitchFilter(model.SwitchOrderLastName);
                model.Employees = _unitOfWork.Employees.GetEmployeeByLastname(model.Filter, model.SwitchOrderLastName);
            }
            else if (model.FirstnameFilter != null)
            {
                SetBackSwitchOrders(2, model);
                model.SwitchOrderFirstName = SwitchFilter(model.SwitchOrderFirstName);
                model.Employees = _unitOfWork.Employees.GetEmployeeByFirstname(model.Filter, model.SwitchOrderFirstName);
            }
            else if (model.JobFilter != null)
            {
                SetBackSwitchOrders(3, model);
                model.SwitchOrderJob = SwitchFilter(model.SwitchOrderJob);
                model.Employees = _unitOfWork.Employees.GetEmployeeByJob(model.Filter, model.SwitchOrderJob);
            }
            else if (model.DepartmentFilter != null)
            {
                SetBackSwitchOrders(4, model);
                model.SwitchOrderDepartment = SwitchFilter(model.SwitchOrderDepartment);
                model.Employees = _unitOfWork.Employees.GetEmployeeByDeparmentName(model.Filter, model.SwitchOrderDepartment);
            }
            else
            {
                return NotFound();
            }

            return View(model);
        }

        private void SetBackSwitchOrders(int Swt, EmployeesListViewModel model)
        {
            if (Swt == 1)
            {
                model.SwitchOrderFirstName = false;
                model.SwitchOrderJob = false;
                model.SwitchOrderDepartment = false;
            }
            else if (Swt == 2)
            {
                model.SwitchOrderLastName = false;
                model.SwitchOrderJob = false;
                model.SwitchOrderDepartment = false;
            }
            else if (Swt == 3)
            {
                model.SwitchOrderFirstName = false;
                model.SwitchOrderLastName = false;
                model.SwitchOrderDepartment = false;
            }
            else if (Swt == 4)
            {
                model.SwitchOrderFirstName = false;
                model.SwitchOrderJob = false;
                model.SwitchOrderLastName = false;
            }
        }

        #region List-methods

        public bool IsNullOrEmpty(string check)
        {
            return check != null || check.Trim() != "";
        }

        private bool SwitchFilter(bool switchOrder)
        {
            if (switchOrder == true)
            {
                switchOrder = false;
            }
            else
            {
                switchOrder = true;
            }

            return switchOrder;
        }

        #endregion

        #endregion

        #region Profil

        public IActionResult Profil(int employeeId)
        {
            EmployeesProfilViewModel model = new EmployeesProfilViewModel();
            model.LoadProfilData(_unitOfWork, employeeId);
            if (model.Employee == null)
                return NotFound();

            //model.Employee.HiringDate = model.Employee.HiringDate.Date;
            //model.Employee.Birthdate = model.Employee.HiringDate.Date;

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
            model.ButtonClicked = "Assigned";

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

                CheckIfEmployeeTaskExists(model.Employee.Id, taskId);

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

        #region Feed : Methods

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

        public bool CheckIfEmployeeTaskExists(int employeeId, int taskId)
        {
            EmployeeTask employeeTask = _unitOfWork.EmployeeTasks.GetByEmployeeIdAndTaskId(employeeId, taskId);

            if (CheckIfEmployeeTaskIsAlreadyExsisting(employeeTask))
            {
                employeeTask = GenerateEmployeetask(employeeId, taskId);
                employeeTask.Picked = true;

                if (CreateEmployeeTask(employeeTask))
                {
                    employeeTask.Task.Status = Core.Enum.TaskStatusType.InArbeit;
                    UpdateTask(employeeTask.Task);

                    DashboardDisplay dashboardDisplay = GenerateDashboardTask(employeeTask);
                    dashboardDisplay = GenerateDashboardTask(employeeTask);
                    CreateDashboardDisplay(dashboardDisplay);
                }

                return false;
            }
            else
            {
                employeeTask.Picked = true;

                if (UpdateEmployeeTask(employeeTask))
                {
                    employeeTask.Task.Status = Core.Enum.TaskStatusType.InArbeit;
                    UpdateTask(employeeTask.Task);

                    DashboardDisplay dashboardDisplay = GenerateDashboardTask(employeeTask);
                    dashboardDisplay = GenerateDashboardTask(employeeTask);
                    CreateDashboardDisplay(dashboardDisplay);

                }

                return false;
            }
        }

        //private static async DeleteErrorMessage()
        //{
        //Wenn die Methode nach dem Laden einige Sekunden await und dann eine bestimmte Aktion ausführt könnte 
        //eine Fehlermeldung verschwinden oder immer wenn eine andere Aktion ausgewählt wird
        //}

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
                        employeeTask.Task.Status = Core.Enum.TaskStatusType.NichtBegonnen;
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
                    dashboardDisplay.Finished = true;
                    DeleteDashBoardTask(dashboardDisplay);

                    model.Task.Status = Core.Enum.TaskStatusType.Erledigt;
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

        public IActionResult DeleteAppointment(int employeeId, int appointmentId)
        {
            DashboardDisplay dashboardDisplay = _unitOfWork.DashboardDisplays.GetByEmployeeIdAndAppointmentId(employeeId, appointmentId);

            this.DeleteDashBoardTask(dashboardDisplay);

            return RedirectToAction(nameof(Feed), new { employeeId = employeeId });
        }

        #region Update, Add and Delete

        private bool UpdateEmployeeTask(EmployeeTask employeeTask)
        {
            try
            {
                _unitOfWork.EmployeeTasks.Update(employeeTask);
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

        private bool CreateEmployeeTask(EmployeeTask employeeTask)
        {
            try
            {
                _unitOfWork.EmployeeTasks.Add(employeeTask);
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

        private void UpdateTask(Task task)
        {
            try
            {
                _unitOfWork.Tasks.Update(task);
                _unitOfWork.Save();
            }
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(valResult.MemberNames.First(), valResult.ErrorMessage);
            }
        }

        public void CreateDashboardDisplay(DashboardDisplay dashboardDisplay)
        {
            try
            {
                _unitOfWork.DashboardDisplays.Add(dashboardDisplay);
                _unitOfWork.Save();
            }
            catch (ValidationException validationException)
            {
                ValidationResult valResult = validationException.ValidationResult;
                ModelState.AddModelError(valResult.MemberNames.First(), valResult.ErrorMessage);
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

        #endregion

        #region Generate

        private DashboardDisplay GenerateDashboardTask(EmployeeTask employeeTask)
        {
            DashboardDisplay dashboardTask = new DashboardDisplay();

            dashboardTask.Name = employeeTask.Task.TaskName;
            dashboardTask.Startdatum = DateTime.Now;
            dashboardTask.SpecificInformation = "Priority: " + Convert.ToString(employeeTask.Task.Priority);
            dashboardTask.Finished = false;
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

            return employeeTask;
        }

        #endregion
    }
}