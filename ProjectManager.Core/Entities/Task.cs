﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProjectManager.Core.Entities
{
    public class Task : EntityObject
    {
        public List<EmployeeTask> EmployeeTasks { get; set; }

        public List<EmployeeQualification> EmployeeQualifications { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project Project { get; set; }

        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Aufgabe")]
        public string TaskName { get; set; }

        [Display(Name = "Priorität")]
        public int Priority { get; set; }

        public string Status { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Fixer Task")]
        public bool FixedTask { get; set; }

        public string Information { get; set; }

        [Required(ErrorMessage = "Dieses Feld wird benötigt")]
        [Display(Name = "Von")]
        public DateTime Startdate { get; set; }

        [Display(Name = "Bis")]
        public DateTime Enddate { get; set; }

        [Display(Name = "Geschätzte Zeit")]
        public string ValuedTime { get; set; }

        public DateTime Deadline { get; set; }
    }
}
