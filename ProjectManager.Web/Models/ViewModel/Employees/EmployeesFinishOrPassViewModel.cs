using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel.Employees
{
    public class EmployeesFinishOrPassViewModel
    {
        #region Properties

        public Core.Entities.Task Task { get; set; }
        public Employee Employee { get; set; }
        public Employee RecipientEmployee { get; set; }

        public SelectList EmployeeSelectList { get; set; }

        public string Finish { get; set; }
        public string Pass { get; set; }
        public string Abbruch { get; set; }

        public bool PassClicked { get; set; }
        public bool FinishClicked { get; set; }
        public bool PassConfirmed { get; set; }
        public bool FinishConfirmed { get; set; }

        public bool FixedTask { get; set; }

        public string ButtonClicked { get; set; }
        public bool Priority { get; set; }

        #endregion

        #region Controller-Methods

        public void LoadData(IUnitOfWork uow, int employeeId, int taskId)
        {
            Task = uow.Tasks.GetById(taskId);

            Employee = uow.Employees.GetById(employeeId);
        }

        public void LoadSelectList(IUnitOfWork uow, int employeeId, int taskId)
        {
            List<Employee> employeeList = uow.Employees.GetEmployeesByProjectAndQualifications(taskId, employeeId, uow);
            EmployeeSelectList = new SelectList(employeeList, nameof(Employee.Id), nameof(Employee.Firstname));
        }

        #endregion

        #region View-Methods

        public string FinishButton()
        {
            if (this.PassClicked)
            {
                return "hidden";
            }
            else
            {
                return "visible";
            }
        }

        public string AbortButton()
        {
            if (this.PassClicked)
            {
                return "visible";
            }
            else
            {
                return "hidden";
            }
        }

        public string FinishButtonDisplay()
        {
            if (this.PassClicked)
            {
                return "none";
            }
            else
            {
                return "";
            }
        }
        #endregion
    }
}
