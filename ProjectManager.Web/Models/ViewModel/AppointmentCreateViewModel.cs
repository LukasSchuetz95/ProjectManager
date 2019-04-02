using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ProjectManager.Web.Models.ViewModel
{
    public class AppointmentCreateViewModel
    {
        public Appointment Appointment { get; set; }
        public SelectList Employees { get; set; }

        public void LoadData(IUnitOfWork unitOfWork)
        {
            List<Employee> employees = unitOfWork.Employees.GetAll();

            Employees = new SelectList(employees, nameof(Employee.Id), nameof(Employee));
           
        }
    }
}
