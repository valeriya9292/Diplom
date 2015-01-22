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
            this.repository = repository;
        }

        public Task FindTaskById(int id)
        {
            return repository.FindById(id);
        }

        public IEnumerable<Task> FindAllTasks()
        {
            return repository.FindAll();
        }

        public IEnumerable<Task> FindTasksByProjectId(int projectId)
        {
            return repository.FindByProjectId(projectId);
        }

        public void DeleteTask(int taskId)
        {
            repository.Delete(taskId);
        }

        public int SaveTask(Task task)
        {
            return repository.Save(task);
        }

    }
}
