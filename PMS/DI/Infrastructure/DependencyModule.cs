using BLL.Repositories;
using DAL.ORM.Repositories;
using Ninject.Modules;

namespace DI.Infrastructure
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IProjectRepository>().To<ProjectRepository>();
            Bind<ITaskRepository>().To<TaskRepository>();
            Bind<ITimeLogRepository>().To<TimeLogRepository>();
            Bind<ICommentRepository>().To<CommentRepository>();
        }
    }
}
