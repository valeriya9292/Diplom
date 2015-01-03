using System;
using System.Collections.Generic;
using ORM.Properties.Model.Enums;

namespace ORM.Properties.Model
{
    public class OrmProject
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime? Duration { get; set; }
        public string Name { get; set; }
        public decimal Progress { get; set; }
        public DateTime? StartDate { get; set; }
        public OrmProjectStatus Status { get; set; }

        public virtual ICollection<int> Tasks { get; set; }
    }
}
