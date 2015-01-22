using BLL.DomainModel.Enums;

namespace Web.Models.DTO
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Duration { get; set; }
        public string Name { get; set; }
        public decimal Progress { get; set; }
        public string StartDate { get; set; }
        public ProjectStatus Status { get; set; }

        public ProjectDto(BLL.DomainModel.Entities.Project project)
        {
            Id = project.Id;
            Description = project.Description;
            Duration = project.Duration;
            Name = project.Name;
            Progress = project.Progress;
            StartDate = project.StartDate.HasValue ? project.StartDate.Value.ToString("MM/dd/yyyy") : string.Empty;
            Status = project.Status;
        }
    }
}
