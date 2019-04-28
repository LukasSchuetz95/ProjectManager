using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web.Models.ViewModel
{
    public class DepartmentsViewModel
    {
        #region  List

        #region properties - List

        public List<Department> DepartmentList { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        #endregion
        #region controller-methods - List

        public void LoadListData(IUnitOfWork uow)
        {
            this.DepartmentList = uow.Departments.GetAll();
            UnitOfWork = uow;
        }

        #endregion
        #region model-methods List

        public int CountEmployeesOfThisDepartment(Department department, IUnitOfWork uow)
        {
            return uow.Employees.GetEmployeeByDepartmentId(department.Id).Count;
        }

        #endregion

        #endregion

        #region Details

        #region properties

        public List<Employee> EmployeeList { get; set; }
        public Department Department { get; set; }

        #endregion
        #region controller-methods - Details

        public void LoadDeatilsData(int departmentId, IUnitOfWork uow)
        {
            EmployeeList = uow.Employees.GetEmployeeByDepartmentId(departmentId);
            Department = uow.Departments.GetById(departmentId);
        }

        #endregion

        #endregion

        #region Delete

        #region properties

        public Department AssignDepartment { get; set; }
        public SelectList DepartmentSelectList { get; private set; }
        public string Assign { get; set; }
        public string Change { get; set; }
        public string ChoosenDepartment { get; set; }

        #endregion
        #region controller-methods
        //EmployeeList ist in der region Details\Properties zu finden
        //Department ist in der region Details\Properties zu finden
        public void LoadConfirmDeleteData(int departmentId, IUnitOfWork uow)
        {
            Department = uow.Departments.GetById(departmentId);
            EmployeeList = uow.Employees.GetEmployeeByDepartmentId(Department.Id);

            this.DepartmentList = uow.Departments.GetAllWithoutThisDepartmentId(departmentId);
            this.DepartmentSelectList = new SelectList(this.DepartmentList, nameof(Department.Id), nameof(Department.DeptName));
        }

        #endregion

        #endregion
    }
}
