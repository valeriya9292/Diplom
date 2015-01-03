using System.Collections.Generic;
using System.Linq;
using BLL.DomainModel.Entities;
using BLL.Repositories;
using DAL.ORM.Convertions;
using ORM.Properties.Model;

namespace DAL.ORM.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public void AddMember(ProjectMember projectMember)
        {
            using (var context = new PmsDbContext())
            {
                context.ProjectMembers.Add(projectMember.ToOrmProjectMember());
                context.SaveChanges();
            }
        }

        public void DeleteMember(int projectId, int userId)
        {
            using (var context = new PmsDbContext())
            {
                var projectMember = context.ProjectMembers.FirstOrDefault(pm => pm.Id == projectId && pm.UserId == userId );
                if (projectMember == null)
                    return;
                context.ProjectMembers.Remove(projectMember);
                context.SaveChanges();
            }
        }

        public Project FindById(int id)
        {
            using (var context = new PmsDbContext())
            {
                return context.Projects.FirstOrDefault(it => it.Id == id).ToEntityProject();
            }
        }

        public IEnumerable<Project> FindAll()
        {
            using (var context = new PmsDbContext())
            {
                return context.Projects.Select(it => it.ToEntityProject());
            }
        }

        public IEnumerable<Project> FindByUserId(int userId)
        {
            using (var context = new PmsDbContext())
            {
                var projectIds = context.ProjectMembers.Where(it => it.UserId == userId).Select(it => it.ProjectId);
                return context.Projects.Where(it => projectIds.Contains(it.Id)).Select(it => it.ToEntityProject());
            }
        }

        public void Delete(int projectId)
        {
            using (var context = new PmsDbContext())
            {
                var project = context.Projects.FirstOrDefault(f => f.Id == projectId);
                if (project == null) return;
                context.Projects.Remove(project);
                context.SaveChanges();
            }
        }

        public void Save(Project project)
        {
            using (var context = new PmsDbContext())
            {
                var oldProject = context.Projects.FirstOrDefault(u => u.Id == project.Id);
                if (oldProject != null)
                {
                    context.Projects.Remove(oldProject);
                }
                context.Projects.Add(project.ToOrmProject());
                context.SaveChanges();
            }
        }
    }
}
