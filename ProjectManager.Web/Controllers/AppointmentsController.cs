using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Web.Models;
using ProjectManager.Web.Models.ViewModel;

namespace ProjectManager.Web.Controllers
{
    public class AppointmentsController : Controller
    {

        IUnitOfWork _unitOfWork;

        public AppointmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

 

        public IActionResult Create(int employeeId)
        {
            AppointmentCreateViewModel model = new AppointmentCreateViewModel();
            model.LoadData(_unitOfWork, employeeId);
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AppointmentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Appointments.Add(model.Appointment);
                    _unitOfWork.Save();
                    CreateDashboardDisplay(model.Appointment, model.Appointment.EmployeeId);
                    return RedirectToAction("Feed", "Employees", new { employeeId = model.Appointment.EmployeeId});
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }

        public IActionResult Detail(int appId)
        {
            AppointmentDetailViewModel model = new AppointmentDetailViewModel();
            model.LoadData(_unitOfWork, appId);
            return View(model);
        }

        #region Create Methoods

        public void CreateDashboardDisplay( Appointment appointment, int employeeid)
        {
            DashboardDisplay dashboardDisplay = new DashboardDisplay();
            dashboardDisplay.Employee = _unitOfWork.Employees.GetById(employeeid);
            dashboardDisplay.EmployeeId = employeeid;
            dashboardDisplay.AppointmentId = appointment.Id;
            dashboardDisplay.Finished = false;
            dashboardDisplay.Name = appointment.AppoName;
            dashboardDisplay.SpecificInformation = Convert.ToString(appointment.AppoType);
            dashboardDisplay.Startdatum = DateTime.Now;
            CreateDashboardDisplay(dashboardDisplay);
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

        public bool IsNullOrEmpty(string appointment)
        {
            return appointment != null || appointment.Trim() != "";
        }

        #endregion

    }
}