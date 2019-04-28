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
            Employees = uow.Employees.GetAll();
            LoadSelectList(uow);
            SetSwitchesTrue();
        }

        public void LoadListData(IUnitOfWork uow, int order)
        {
            if (order == 1)
            {
                SwitchOrderFirstName = false;
                SwitchOrderJob = false;
                SwitchOrderDepartment = false;

                SwitchOrderLastName = SwitchFilter(SwitchOrderLastName);

                LoadSelectList(uow);
                Employees = uow.Employees.GetEmployeeByLastname(Filter, SwitchOrderLastName);
                GetEmployeesWithMatchingQualification(uow, Qualification);
            }
            else if (order == 2)
            {
                SwitchOrderLastName = false;
                SwitchOrderJob = false;
                SwitchOrderDepartment = false;

                SwitchOrderFirstName = SwitchFilter(SwitchOrderFirstName);

                LoadSelectList(uow);
                Employees = uow.Employees.GetEmployeeByFirstname(Filter, SwitchOrderFirstName);
                GetEmployeesWithMatchingQualification(uow, Qualification);
            }
            else if (order == 3)
            {
                SwitchOrderFirstName = false;
                SwitchOrderLastName = false;
                SwitchOrderDepartment = false;

                SwitchOrderJob = SwitchFilter(SwitchOrderJob);

                LoadSelectList(uow);
                Employees = uow.Employees.GetEmployeeByJob(Filter, SwitchOrderJob);
                GetEmployeesWithMatchingQualification(uow, Qualification);
            }
            else if (order == 4)
            {
                SwitchOrderFirstName = false;
                SwitchOrderJob = false;
                SwitchOrderLastName = false;

                SwitchOrderDepartment = SwitchFilter(SwitchOrderDepartment);

                LoadSelectList(uow);
                Employees = uow.Employees.GetEmployeeByDeparmentName(Filter, SwitchOrderDepartment);
                GetEmployeesWithMatchingQualification(uow, Qualification);
            }
        }

        #endregion

        #region Model-methods
        private void SetSwitchesTrue()
        {
            SwitchOrderLastName = true;
            SwitchOrderFirstName = true;
            SwitchOrderJob = true;
            SwitchOrderDepartment = true;
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
            QualificationList = uow.Qualifications.GetAll();
            QualificationSelectList = new SelectList(QualificationList, nameof(Qualification.Id), nameof(Qualification.QualificationName));
        }

        private void GetEmployeesWithMatchingQualification(IUnitOfWork uow, Qualification qualification)
        {
            if (qualification.Id != 0)
            {
                List<Employee> tempEmployeeList = this.Employees;
                Employees = new List<Employee>();
                List<EmployeeQualification> employeeQualifications = uow.EmployeeQualifications.GetEmployeesByQualifications(qualification.Id);

                foreach (var tEL in tempEmployeeList)
                {
                    foreach (var eQ in employeeQualifications)
                    {
                        if (tEL.Id == eQ.Employee.Id)
                        {
                            Employees.Add(tEL);
                        }
                    }
                }
            }
        }
        #endregion
    }
}
