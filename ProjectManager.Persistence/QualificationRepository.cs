using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public List<Qualification> GetAll()
        {
            return _dbContext.Qualifications.OrderBy(q => q.QualificationName).ToList();
        }
    }
}
