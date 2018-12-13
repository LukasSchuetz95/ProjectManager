using System;
using System.Collections.Generic;
using System.Text;
using ProjectManager.Core.Entities;

namespace ProjectManager.Core.Contracts
{
    public interface IQualificationRepository
    {
        List<Qualification> GetAll();
        void Add(Qualification model);
        List<Qualification> GetQualificationByName(string filterProjectName);
        Qualification GetById(int qualId);
        void Update(Qualification model);
        void Delete(Qualification model);
    }
}
