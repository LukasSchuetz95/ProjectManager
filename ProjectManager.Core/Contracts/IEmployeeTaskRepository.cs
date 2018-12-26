using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IEmployeeTaskRepository
    {
        EmployeeTask GetEmployeeTaskByTaskId(int taskId);
        List<EmployeeTask> GetAll();
        void Add(EmployeeTask model);

        void Update(EmployeeTask model);
        EmployeeTask GetByProjectId(int projectId);
        EmployeeTask GetByTaskId(int taskId);
        void Delete(EmployeeTask model);
        EmployeeTask GetById(int empProId);
    }
}
