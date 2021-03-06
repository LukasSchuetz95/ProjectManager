﻿using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Contracts
{
    public interface IEmployeeQualificationRepository
    {
        List<EmployeeQualification> GetAllProjectManagers();
        List<EmployeeQualification> GetQualificationsByEmployeeId(int employeeId);
        List<EmployeeQualification> GetEmployeesByQualifications(int id);
        List<EmployeeQualification> GetAllProjectManagersAndProjectMembers(int projectId);
    }
}
