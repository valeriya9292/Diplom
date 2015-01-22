using System.Collections.Generic;
using System.Linq;
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

        public void AddMemberToProject(int projectId, int userId)
        {
            repository.AddMember(new ProjectMember() { ProjectId = projectId, UserId = userId });
        }


        public void DeleteMemberFromProject(int projectId, int userId)
        {
            repository.DeleteMember(projectId, userId);
        }

        public Project FindProjectById(int id)
        {
            return repository.FindById(id);
        }

        public IEnumerable<Project> FindAllProjects()
        {
            return repository.FindAll();
        }

        public IEnumerable<Project> FindByUserId(int userId)
        {
            return repository.FindByUserId(userId);
        }

        public Project FindProjectByName(string name)
        {
            return repository.FindByName(name);
        }

        public void DeleteProject(int projectId)
        {
            repository.Delete(projectId);
        }

        public void SaveProject(Project project)
        {
            repository.Save(project);
        }

        public void UpdateProjectMembers(int projectId, IEnumerable<int> usersIds, IEnumerable<int> savedUsersIds)
        {
            var toDelete = savedUsersIds.Where(s => !usersIds.Contains(s)).Select(s => s);
            var toSave = usersIds.Where(u => !savedUsersIds.Contains(u)).Select(s => s);

            foreach (var userId in toDelete)
            {
                DeleteMemberFromProject(projectId, userId);
            }

            foreach (var userId in toSave)
            {
                AddMemberToProject(projectId, userId);
            }
        }
    }
}
