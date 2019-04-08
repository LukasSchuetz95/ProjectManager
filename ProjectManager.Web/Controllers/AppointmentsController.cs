using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
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

        public IActionResult Show(AppointmentListViewModel model, int employeeId)
        {
            model.LoadData(_unitOfWork,employeeId);
            return View(model);
        }


        public IActionResult Create()
        {
            AppointmentCreateViewModel model = new AppointmentCreateViewModel();
            model.LoadData(_unitOfWork);
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
                    return RedirectToAction("Show", "Appointments");
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }


    }
}