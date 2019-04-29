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

        public IActionResult Create(int employeeId, string buttonClicked, bool priority)
        {
            AppointmentCreateViewModel model = new AppointmentCreateViewModel();
            model.LoadData(_unitOfWork, employeeId);
            model.ButtonClicked = buttonClicked;
            model.Priority = priority;
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(AppointmentCreateViewModel model)
        {
            string error = null;

            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Appointments.Add(model.Appointment);
                    _unitOfWork.Save();

                    return RedirectToAction("Feed", "Employees", new
                    {
                        employeeId = model.Appointment.EmployeeId,
                        buttonClicked = model.ButtonClicked,
                        priority = model.Priority,
                        error = GenerateDashboardDisplay(model.Appointment, model.Appointment.EmployeeId)
                    });
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }

        public IActionResult Detail(int appointmentId)
        {
            AppointmentDetailViewModel model = new AppointmentDetailViewModel();
            model.LoadData(_unitOfWork, appointmentId);
            return View(model);
        }

        #region Create Methoods

        public string GenerateDashboardDisplay(Appointment appointment, int employeeid)
        {
            DashboardDisplay dashboardDisplay = new DashboardDisplay();

            if (appointment.Startdate.ToString("d") == appointment.Enddate.ToString("d"))
            {
                dashboardDisplay.Duration = (appointment.Startdate).ToString("d");
            }
            else
            {
                dashboardDisplay.Duration = "From " + (appointment.Startdate).ToString("d") + " to " + (appointment.Enddate).ToString("d"); 
            }
          
            dashboardDisplay.Employee = _unitOfWork.Employees.GetById(employeeid);
            dashboardDisplay.EmployeeId = employeeid;
            dashboardDisplay.AppointmentId = appointment.Id;
            dashboardDisplay.Name = appointment.AppoName;
            dashboardDisplay.SpecificInformation = Convert.ToString(appointment.AppoType);
            dashboardDisplay.Startdatum = DateTime.Now;

            if (!CreateDashboardDisplay(dashboardDisplay))
            {
                return "Error during the creation of the DashboardDisplay!";
            }
            else
            {
                return null;
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

        public bool IsNullOrEmpty(string appointment)
        {
            return appointment != null || appointment.Trim() != "";
        }

        #endregion

    }
}