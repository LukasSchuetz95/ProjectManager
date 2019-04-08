using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Contracts;
using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Persistence
{
    class FeedDisplayRepository : IFeedDisplayRepository
    {
        #region DbKontext

        private readonly ApplicationDbContextPersistence _dbContext;

        public FeedDisplayRepository(ApplicationDbContextPersistence dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(FeedDisplay feedDisplay)
        {
            _dbContext.FeedDisplayRepository.Add(feedDisplay);
        }

        public void Delete(FeedDisplay feedDisplay)
        {
            _dbContext.FeedDisplayRepository.Remove(feedDisplay);
        }

        public void Update(FeedDisplay feedDisplay)
        {
            _dbContext.FeedDisplayRepository.Update(feedDisplay);
        }

        #endregion
    }
}
