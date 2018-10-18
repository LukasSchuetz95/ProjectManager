using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.Contracts
{
    public interface IEntityObject
    {
        int Id { get; set; }

        byte[] Timestamp { get; set; }
    }
}
