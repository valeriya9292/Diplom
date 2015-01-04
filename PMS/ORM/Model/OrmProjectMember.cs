using System;

namespace ORM.Model
{
    public class OrmProjectMember
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }

        public virtual OrmUser User { get; set; }
        public virtual OrmProject Project { get; set; }
    }
}
