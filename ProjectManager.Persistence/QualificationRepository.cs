using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly ApplicationDbContextPersistence _dbContext;

        public QualificationRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
