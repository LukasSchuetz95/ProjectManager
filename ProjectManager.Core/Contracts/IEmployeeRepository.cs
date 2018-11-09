using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeByLastname(string filter=null);
        List<Employee> GetEmployeeByFirstname(string filter=null);
        List<Employee> GetEmployeeByJob(string filterJob);
        List<Employee> GetAll();
    }
}
