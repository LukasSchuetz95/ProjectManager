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

        public void Add(Qualification model)
        {
            _dbContext.Qualification.Add(model);
        }

        public void Delete(Qualification model)
        {
            _dbContext.Qualification.Remove(model);
        }

        public List<Qualification> GetAll()
        {
            return _dbContext.Qualification.OrderBy(q => q.QualificationName).ToList();
        }

        public Qualification GetById(int qualId)
        {
            return _dbContext.Qualification.SingleOrDefault(q => q.Id == qualId);
        }

        public List<Qualification> GetQualificationByName(string filter)
        {
            IQueryable<Qualification> query = _dbContext.Qualification.OrderBy(q => q.QualificationName);

            if (filter == null || filter == "")
            {
                return query.ToList();
            }
            else
            {
                return query.Where(q => q.QualificationName.Contains(filter)).ToList();
            }
        }

        public void Update(Qualification model)
        {
            _dbContext.Qualification.Update(model);
        }
    }
}
