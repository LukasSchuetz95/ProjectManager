using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.LookingForEmployeeModel
{
    public class LookingForEmployeeModel
    {
        [Display(Name = "LookingForEmployee")]

        public SelectList Employees { get; set; }

        public void LoadData(IUnitOfWork unitOfWork)
        {
            List<Employee> employees = unitOfWork.Employees.GetAll();
            Devices = new SelectList(devices, nameof(Device.Id), null);
        }
    }
}
