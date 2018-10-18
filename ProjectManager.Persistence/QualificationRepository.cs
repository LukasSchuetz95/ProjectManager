using ProjectManager.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    public class QualificationRepository : IQualificationRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public QualificationRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
