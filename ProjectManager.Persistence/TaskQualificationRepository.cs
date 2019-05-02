using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;

namespace ProjectManager.Persistence
{
    public class TaskQualificationRepository : ITaskQualificationRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public TaskQualificationRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<TaskQualification> GetByQualificationId(int qualificationId)
        {
            return _dbContext.TaskQualification.Include(p => p.Qualification).Include(p => p.Task).
                   Where(p => p.QualificationId == qualificationId).ToList();
        }
        /// <summary>
        /// Created by Thomas Baurnberger
        /// </summary>
        /// <param name="EmployeeQualifications"></param>
        /// <param name="uow"></param>
        /// <returns></returns>
        public List<TaskQualification> GetQualificationsByTaskId(int taskId)
        {
            return _dbContext.TaskQualification.Include(p=>p.Qualification).Include(p=>p.Task).
                   Where(p=>p.Task.Id == taskId).ToList();
        }
    }
}
