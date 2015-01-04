using System;
using ORM.Model.Enums;

namespace ORM.Model
{
    public class OrmTask
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }
        public string Description { get; set; }
        public DateTime? Duration { get; set; }
        public string Name { get; set; }
        public decimal Progress { get; set; }
        public int ProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public OrmProjectStatus Status { get; set; }

        public virtual OrmProject Project { get; set; }
        public virtual OrmUser User { get; set; }
    }
}
