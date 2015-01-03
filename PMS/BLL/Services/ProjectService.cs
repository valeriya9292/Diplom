using System.Collections.Generic;
using BLL.DomainModel.Entities;
using BLL.Repositories;

namespace BLL.Services
{
    public class ProjectService
    {
        private readonly IProjectRepository repository;

        public ProjectService(IProjectRepository repository)
        {
            this.repository = repository;
        }

        void AddMemberToProject(int projectId, int userId)
        {
            repository.AddMember(new ProjectMember() { ProjectId = projectId, UserId = userId });
        }

        void DeleteMemberFromProject(int projectId, int userId)
        {
            repository.DeleteMember(projectId, userId);
        }

        Project FindProjectById(int id)
        {
            return repository.FindById(id);
        }

        IEnumerable<Project> FindAllProjects()
        {
            return repository.FindAll();
        }

        IEnumerable<Project> FindByUserId(int userId)
        {
            return repository.FindByUserId(userId);
        }

        void DeleteProject(int projectId)
        {
            repository.Delete(projectId);
        }

        void SaveProject(Project project)
        {
            repository.Save(project);
        }

    }
}
