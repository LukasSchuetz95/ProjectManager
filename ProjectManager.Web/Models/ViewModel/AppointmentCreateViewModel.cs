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
        public Employee Employee { get; set; }

        public void LoadData(IUnitOfWork uow, int employeeId)
        {
            this.Employee = uow.Employees.GetById(employeeId);
        }
    }
}
