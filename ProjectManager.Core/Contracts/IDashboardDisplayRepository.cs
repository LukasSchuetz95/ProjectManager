﻿using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Contracts
{
    public interface IDashboardDisplayRepository
    {
        void Update(DashboardDisplay dashboardDisplay);
        void Add(DashboardDisplay feedDisplay);
        void Delete(DashboardDisplay feedDisplay);
        List<DashboardDisplay> GetByEmployeeId(int employeeId);
        DashboardDisplay GetByEmployeeIdAndTaskId(int taskId, int employeeId);
        DashboardDisplay GetByEmployeeIdAndAppointmentId(int employeeId, int appointmentId);
    }
}
