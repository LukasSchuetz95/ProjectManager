using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IEmployeeProjectRepository
    {
        List<EmployeeProject> GetAll();
        List<EmployeeProject> GetAllByProjectId(int projectId);
        void Add(EmployeeProject model);
        EmployeeProject GetByProjectId(int id);
        List<EmployeeProject> GetProjectsByEmployeeId(int employeeId);
        List<Employee> GetAllNotPartOfProject(int projectId);
        EmployeeProject GetById(int empProId);
        void Delete(EmployeeProject model);
        void Update(EmployeeProject employeeProject);
        EmployeeProject GetProjectManagerByProjectId(int projectId);
        EmployeeProject GetByEmployeeIdAndProjectId(int id1, int id2);
        void SetAllProjectManagersToFalse(int id);
        List<EmployeeProject> GetEmplyoeesInProjectByEmployeeName(string filterEmployeeName, int projectId);
        List<Employee> GetEmplyoeesNotInProjectByEmployeeName(string filterEmployeeName, int projectId);
    }
}
