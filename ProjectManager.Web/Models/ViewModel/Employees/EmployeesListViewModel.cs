using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class EmployeesListViewModel
    {

        #region Properties
        public List<Employee> Employees { get; set; }
        [Display(Name = "LookingForEmployee")]

        public Qualification Qualification { get; set; }
        public List<Qualification> QualificationList { get; set; }
        public SelectList QualificationSelectList { get; set; }

        public string Filter { get; set; }
        public string LastnameFilter { get; set; }
        public string FirstnameFilter { get; set; }
        public string JobFilter { get; set; }
        public string DepartmentFilter { get; set; }

        public bool SwitchOrderFirstName { get; set; }
        public bool SwitchOrderLastName { get; set; }
        public bool SwitchOrderJob { get; set; }
        public bool SwitchOrderDepartment { get; set; }

        #endregion

        #region Controller-methods

        public void LoadData(IUnitOfWork uow)
        {
            this.Employees = uow.Employees.GetAll();
            LoadSelectList(uow);
            SetSwitchesTrue();
        }

        public void LoadListData(IUnitOfWork uow, int order)
        {
            if (order == 1)
            {
                this.SwitchOrderFirstName = false;
                this.SwitchOrderJob = false;
                this.SwitchOrderDepartment = false;

                this.SwitchOrderLastName = this.SwitchFilter(this.SwitchOrderLastName);

                LoadSelectList(uow);
                this.Employees = uow.Employees.GetEmployeeByLastname(this.Filter, this.SwitchOrderLastName);
                this.GetEmployeesWithMatchingQualification(uow, this.Qualification);
            }
            else if (order == 2)
            {
                this.SwitchOrderLastName = false;
                this.SwitchOrderJob = false;
                this.SwitchOrderDepartment = false;

                this.SwitchOrderFirstName = this.SwitchFilter(this.SwitchOrderFirstName);

                LoadSelectList(uow);
                this.Employees = uow.Employees.GetEmployeeByFirstname(this.Filter, this.SwitchOrderFirstName);
                this.GetEmployeesWithMatchingQualification(uow, this.Qualification);
            }
            else if (order == 3)
            {
                this.SwitchOrderFirstName = false;
                this.SwitchOrderLastName = false;
                this.SwitchOrderDepartment = false;

                this.SwitchOrderJob = this.SwitchFilter(this.SwitchOrderJob);

                LoadSelectList(uow);
                this.Employees = uow.Employees.GetEmployeeByJob(this.Filter, this.SwitchOrderJob);
                this.GetEmployeesWithMatchingQualification(uow, this.Qualification);
            }
            else if (order == 4)
            {
                this.SwitchOrderFirstName = false;
                this.SwitchOrderJob = false;
                this.SwitchOrderLastName = false;

                this.SwitchOrderDepartment = this.SwitchFilter(this.SwitchOrderDepartment);

                LoadSelectList(uow);
                this.Employees = uow.Employees.GetEmployeeByDeparmentName(this.Filter, this.SwitchOrderDepartment);
                this.GetEmployeesWithMatchingQualification(uow, this.Qualification);
            }
        }

        #endregion

        #region Model-methods
        private void SetSwitchesTrue()
        {
            this.SwitchOrderLastName = true;
            this.SwitchOrderFirstName = true;
            this.SwitchOrderJob = true;
            this.SwitchOrderDepartment = true;
        }

        private bool SwitchFilter(bool switchOrder)
        {
            if (switchOrder)
            {
                return switchOrder = false;
            }
            else
            {
                return switchOrder = true;
            }
        }

        public void LoadSelectList(IUnitOfWork uow)
        {
            this.QualificationList = uow.Qualifications.GetAll();
            this.QualificationSelectList = new SelectList(this.QualificationList, nameof(Qualification.Id), nameof(Qualification.QualificationName));
        }

        private void GetEmployeesWithMatchingQualification(IUnitOfWork uow, Qualification qualification)
        {
            if (qualification.Id != 0)
            {
                List<Employee> tempEmployeeList = this.Employees;
                this.Employees = new List<Employee>();
                List<EmployeeQualification> employeeQualifications = uow.EmployeeQualifications.GetEmployeesByQualifications(qualification.Id);

                foreach (var tEL in tempEmployeeList)
                {
                    foreach (var eQ in employeeQualifications)
                    {
                        if (tEL.Id == eQ.Employee.Id)
                        {
                            this.Employees.Add(tEL);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
