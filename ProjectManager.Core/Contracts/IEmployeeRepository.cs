using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployeeByLastname(string FilterLastname=null);
        List<Employee> GetEmployeeByFirstname(string filterFirstname=null);
    }
}
