﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BLL.DomainModel.Entities;
using BLL.Repositories;
using DAL.ORM.Convertions;
using ORM.Model;
using ORM.Model.Enums;

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
                var projectMember = context.ProjectMembers.FirstOrDefault(pm => pm.ProjectId == projectId && pm.UserId == userId);
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
                return context.Projects.AsEnumerable().Select(it => it.ToEntityProject()).ToList();
            }
        }

        public IEnumerable<Project> FindByUserId(int userId)
        {
            using (var context = new PmsDbContext())
            {
                var projectIds = context.ProjectMembers.Where(it => it.UserId == userId).Select(it => it.ProjectId);
                return context.Projects.Where(it => projectIds.Contains(it.Id)).Select(it => it.ToEntityProject()).ToList();
            }
        }

        public Project FindByName(string name)
        {
            using (var context = new PmsDbContext())
            {
                return context.Projects.FirstOrDefault(it => it.Name == name).ToEntityProject();
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
                var oldProject = context.Projects.FirstOrDefault(c => c.Id == project.Id);
                if (oldProject != null)
                {
                    oldProject.Description = project.Description;
                    oldProject.Duration = project.Duration;
                    oldProject.Name = project.Name;
                    oldProject.Progress = project.Progress;
                    oldProject.StartDate = project.StartDate;
                    oldProject.Status = (OrmProjectStatus)project.Status;

                    context.Entry(oldProject).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    context.Projects.Add(project.ToOrmProject());
                }
                context.SaveChanges();
            }
        }
    }
}
