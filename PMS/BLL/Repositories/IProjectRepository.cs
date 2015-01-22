using System.Collections.Generic;
using BLL.DomainModel.Entities;

namespace BLL.Repositories
{
    public interface IProjectRepository
    {
        void AddMember(ProjectMember projectMember);
        void DeleteMember(int projectId, int userId);

        Project FindById(int id);
        IEnumerable<Project> FindAll();
        IEnumerable<Project> FindByUserId(int userId);
        Project FindByName(string name);

        void Delete(int projectId);

        void Save(Project project);
    }
}
