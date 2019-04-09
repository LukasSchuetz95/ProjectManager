using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeByLastname(string filter, bool order);
        List<Employee> GetEmployeeByFirstname(string filter, bool order);
        List<Employee> GetEmployeeByJob(string filter, bool order);
        List<Employee> GetEmployeeByDeparmentName(string filter, bool order);
        Employee GetById(int employeeId);
        List<Employee> GetAll();
        List<EmployeeQualification> GetAllProjectManagersAndProjectMembers(int projectId);
        void Update(Employee employee);
        List<Employee> GetEmployeeByDepartmentId(int id);
        void Add(Employee employee);
        List<Employee> GetEmployeesByProjectsAndQualifications(int taskId, int employeeId, IUnitOfWork uow);
        System.Threading.Tasks.Task AddAsync(Employee employee);
    }
}
