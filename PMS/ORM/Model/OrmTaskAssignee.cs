using System;

namespace ORM.Model
{
    public class OrmTaskAssignee
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }

        public virtual OrmTask Task { get; set; }
        public virtual OrmUser User { get; set; }
    }
}
