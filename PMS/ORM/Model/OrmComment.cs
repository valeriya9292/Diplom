using System;

namespace ORM.Model
{
    public class OrmComment
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }

        public virtual OrmTask Task { get; set; }
        public virtual OrmUser User { get; set; }
    }
}
