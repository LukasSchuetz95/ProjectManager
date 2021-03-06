﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.Core.Entities
{
    public class EmployeeTask : EntityObject
    {
        [ForeignKey(nameof(EmployeeId))]
        public Employee Employee { get; set; }

        public int EmployeeId { get; set; }

        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; }

        public int TaskId { get; set; }

        public bool Picked { get; set; }

        public Employee PassedTask { get; set; }
    }
}
