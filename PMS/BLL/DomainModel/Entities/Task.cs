using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DomainModel.Enums;

namespace BLL.DomainModel.Entities
{
    public class Task
    {
        public int Id { get; set; }

        public int CreatorId { get; set; }
        public string Description { get; set; }
        public DateTime? Duration { get; set; }
        public string Name { get; set; }
        public decimal Progress { get; set; }
        public int ProjectId { get; set; }
        public DateTime? StartDate { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
