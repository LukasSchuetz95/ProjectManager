using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectManager.Persistence
{
    class DashboardDisplayRepository : IDashboardDisplayRepository
    {
        #region DbKontext

        private readonly ApplicationDbContextPersistence _dbContext;

        public DashboardDisplayRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(DashboardDisplay feedDisplay)
        {
            _dbContext.DashboardDisplay.Add(feedDisplay);
        }

        public void Delete(DashboardDisplay feedDisplay)
        {
            _dbContext.DashboardDisplay.Remove(feedDisplay);
        }

        public void Update(DashboardDisplay feedDisplay)
        {
            _dbContext.DashboardDisplay.Update(feedDisplay);
        }

        public List<DashboardDisplay> GetByEmployeeId(int employeeId)
        {
            return _dbContext.DashboardDisplay.Where(p => p.Employee.Id == employeeId).OrderBy(p=>p.Startdatum).ThenBy(p=>p.Name).ToList();
        }

        #endregion
    }
}
