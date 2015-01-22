using System;
using BLL.DomainModel.Enums;

namespace BLL.DomainModel.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public string Name { get; set; }
        public decimal Progress { get; set; }
        public DateTime? StartDate { get; set; }
        public ProjectStatus Status { get; set; }
    }
}
