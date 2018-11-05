using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll(string Filter=null);
    }
}
