using System;
using BLL.DomainModel.Entities;
using BLL.DomainModel.Enums;

namespace Web.Models.DTO
{
    public class TaskDto
    {
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public string Name { get; set; }
        public decimal Progress { get; set; }
        public int ProjectId { get; set; }
        public string StartDate { get; set; }
        public ProjectStatus Status { get; set; }

        public TaskDto()
        {
            
        }
        public TaskDto(Task task)
        {
            Id = task.Id;
            CreatorId = task.CreatorId;
            Description = task.Description;
            Duration = task.Duration;
            Name = task.Name;
            Progress = task.Progress;
            ProjectId = task.ProjectId;
            Status = task.Status;
            StartDate = task.StartDate.HasValue ? task.StartDate.Value.ToString("MM/dd/yyyy") : string.Empty;
        }
        public Task ToTask(int creatorId)
        {
            return new Task()
            {
                Id = Id,
                CreatorId = creatorId,
                Description = Description,
                Duration = Duration,
                Name = Name,
                Progress = Progress,
                ProjectId = ProjectId,
                Status = Status,
                StartDate = DateTime.Parse(StartDate)
            };
        }
    }
}
