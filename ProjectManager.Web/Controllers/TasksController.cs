﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectManager.Core.Contracts;
using ProjectManager.Web.Models.ViewModel;

namespace ProjectManager.Web.Controllers
{
    public class TasksController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public TasksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        public IActionResult List()
        {
            TasksListViewModel model = new TasksListViewModel();
            model.LoadData(_unitOfWork);
            return View(model);

            //return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int taskId)
        {
            TasksEditViewModel model = new TasksEditViewModel();
            model.LoadData(_unitOfWork, taskId);
            return View(model);
        }

        public IActionResult Details(int taskId)
        {
            TasksDetailsViewModel model = new TasksDetailsViewModel();
            model.LoadData(_unitOfWork, taskId);
            return View(model);
        }
    }
}