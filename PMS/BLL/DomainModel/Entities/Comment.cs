using System;
namespace BLL.DomainModel.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int TaskId { get; set; }
    }
}
