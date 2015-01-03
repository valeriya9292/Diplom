using System.Collections.Generic;
using BLL.DomainModel.Entities;
using BLL.Repositories;

namespace BLL.Services
{
    public class TaskService
    {
        private readonly ITaskRepository repository;

        public TaskService(ITaskRepository repository)
        {
            repository = repository;
        }

        Task FindTaskById(int id)
        {
            return repository.FindById(id);
        }

        IEnumerable<Task> FindAllTasks()
        {
            return repository.FindAll();
        }

        IEnumerable<Task> FindTasksByProjectId(int projectId)
        {
            return repository.FindByProjectId(projectId);
        }

        void DeleteTask(int taskId)
        {
            repository.Delete(taskId);
        }

        void SaveTask(Task task)
        {
            repository.Save(task);
        }

    }
}
