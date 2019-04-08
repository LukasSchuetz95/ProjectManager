using ProjectManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Contracts
{
    public interface ITaskQualificationRepository
    {
        List<TaskQualification> GetByQualificationId(int qualificationId);
    }
}
