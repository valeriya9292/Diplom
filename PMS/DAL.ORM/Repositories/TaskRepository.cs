using System.Collections.Generic;
using System.Linq;
using BLL.Repositories;
using DAL.ORM.Convertions;
using ORM.Properties.Model;
using Task = BLL.DomainModel.Entities.Task;

namespace DAL.ORM.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public Task FindById(int id)
        {
            using (var context = new PmsDbContext())
            {
                return context.Tasks.FirstOrDefault(it => it.Id == id).ToEntityTask();
            }
        }

        public IEnumerable<Task> FindAll()
        {
            using (var context = new PmsDbContext())
            {
                return context.Tasks.Select(it => it.ToEntityTask());
            }
        }

        public IEnumerable<Task> FindByProjectId(int projectId)
        {
            using (var context = new PmsDbContext())
            {
                return context.Tasks.Where(t => t.Id == projectId).Select(it => it.ToEntityTask());
            }
        }

        public void Delete(int taskId)
        {
            using (var context = new PmsDbContext())
            {
                var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);
                if (task == null) return;
                context.Tasks.Remove(task);
                context.SaveChanges();
            }
        }

        public void Save(Task task)
        {
            using (var context = new PmsDbContext())
            {
                var oldTask = context.Projects.FirstOrDefault(u => u.Id == task.Id);
                if (oldTask != null)
                {
                    context.Projects.Remove(oldTask);
                }
                context.Tasks.Add(task.ToOrmTask());
                context.SaveChanges();
            }
        }
    }
}
