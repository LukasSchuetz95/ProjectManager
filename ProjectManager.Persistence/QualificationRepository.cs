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

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <returns></returns>
        public List<Qualification> GetAll()
        {
            return _dbContext.Qualification.OrderBy(q => q.QualificationName).ToList();
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="qualId"></param>
        /// <returns></returns>
        public Qualification GetById(int qualId)
        {
            return _dbContext.Qualification.SingleOrDefault(q => q.Id == qualId);
        }

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Lukas Schütz Created
        /// </summary>
        /// <param name="model"></param>
        public void Update(Qualification model)
        {
            _dbContext.Qualification.Update(model);
        }
    }
}
