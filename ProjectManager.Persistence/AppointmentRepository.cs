using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public AppointmentRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
