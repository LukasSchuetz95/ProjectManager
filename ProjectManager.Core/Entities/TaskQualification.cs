using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class TaskQualification : EntityObject
    {
        [ForeignKey(nameof(TaskId))]
        public Task Task { get; set; }

        public int TaskId { get; set; }

        [ForeignKey(nameof(QualificationId))]
        public Qualification Qualification { get; set; }

        public int QualificationId { get; set; }
    }
}
