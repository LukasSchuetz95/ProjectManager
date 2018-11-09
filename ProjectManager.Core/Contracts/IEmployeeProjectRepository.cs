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
    }
}
