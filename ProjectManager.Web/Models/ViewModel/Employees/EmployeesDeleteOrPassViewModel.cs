using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel.Employees
{
    public class EmployeesDeleteOrPassViewModel
    {
        public Core.Entities.Task Task { get; set; }
        public Employee Employee { get; set; }
        public Employee RecipientEmployee { get; set; }

        public SelectList EmployeeSelectList { get; set; }

        public void LoadData(IUnitOfWork uow, int taskId, int employeeId)
        {
            Task = uow.Tasks.GetById(taskId);

            Employee = uow.Employees.GetById(employeeId);

            List<Employee> employeeList = uow.Employees.GetEmployeesByProjectsAndQualifications(taskId, employeeId, uow);

            //EmployeeSelectList = new SelectList(employeeList, nameof(Employee.Id), nameof(Employee));
        }
    }
}
