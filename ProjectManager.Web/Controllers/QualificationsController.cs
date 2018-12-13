using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using ProjectManager.Web.Models.ViewModel;

namespace ProjectManager.Web.Controllers
{
    public class QualificationsController : Controller
    {
        IUnitOfWork _unitOfWork;

        public QualificationsController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }

        public IActionResult List()
        {
            QualificationsListViewModel model = new QualificationsListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);
        }

        [HttpPost]
        public IActionResult List(QualificationsListViewModel model)
        {
            model.Qualifications = _unitOfWork.Qualifications.GetQualificationByName(model.FilterProjectName);
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Qualification model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _unitOfWork.Qualifications.Add(model);
                    _unitOfWork.Save();
                    return RedirectToAction("List");
                }
                catch (ValidationException validationException)
                {
                    ValidationResult valResult = validationException.ValidationResult;
                    ModelState.AddModelError(nameof(model) + "." + valResult.MemberNames.First(), valResult.ErrorMessage);
                }
            }

            return View(model);
        }

        public IActionResult Edit(int qualId)
        {
            Qualification model = new Qualification();
            model = _unitOfWork.Qualifications.GetById(qualId);

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Qualification model)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Qualifications.Update(model);
                _unitOfWork.Save();
                return RedirectToAction(nameof(List));
            }

            return View(model);
        }

        public IActionResult Delete(int qualId)
        {
            Qualification model = _unitOfWork.Qualifications.GetById(qualId);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteConfirm(int qualId)
        {
            Qualification model = _unitOfWork.Qualifications.GetById(qualId);

            if (model == null)
            {
                return NotFound();
            }

            _unitOfWork.Qualifications.Delete(model);
            _unitOfWork.Save();
            return RedirectToAction(nameof(List));
        }
    }
}