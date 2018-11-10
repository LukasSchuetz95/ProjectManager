﻿using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IEmployeeTaskRepository
    {
        EmployeeTask GetEmployeeTaskByTaskId(int taskId);
        List<EmployeeTask> GetAllStatuses();
        void Add(Task model);

        void update(Task model);
    

    }
}
