using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Contracts
{
    public interface IFeedDisplayRepository
    {
        void Update(FeedDisplay feedDisplay);
        void Add(FeedDisplay feedDisplay);
        void Delete(FeedDisplay feedDisplay);
    }
}
