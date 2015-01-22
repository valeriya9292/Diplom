using System.Collections.Generic;
using BLL.DomainModel.Entities;

namespace BLL.Repositories
{
    public interface ITaskRepository
    {
        Task FindById(int id);
        IEnumerable<Task> FindAll();
        IEnumerable<Task> FindByProjectId(int projectId);

        void Delete(int taskId);

        int Save(Task task);
    }
}
