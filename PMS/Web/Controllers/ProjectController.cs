using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using BLL.DomainModel.Entities;
using BLL.Services;
using Web.Models.DTO;


namespace Web.Controllers
{
    public class ProjectController : BaseController
    {
        private readonly ProjectService service;
        private readonly UserService userService;
        private readonly TaskService taskService;

        public ProjectController(ProjectService service, UserService userService, TaskService taskService)
        {
            this.service = service;
            this.userService = userService;
            this.taskService = taskService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Get(int id)
        {
            var project = service.FindProjectById(id);

            return Json(new ProjectDto(project), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProjects()
        {
            var projects = service.FindAllProjects();
            return Json(projects.Select(p => new ProjectDto(p)), JsonRequestBehavior.AllowGet);
            //return Json(new[]
            //{
            //    new
            //    {
            //        label = "Project1",
            //        id = 1,
            //        children = new[] {new {label = "Task1", id = 2}, new {label = "Task2", id = 3}}
            //    }
            //}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GanttIndex(int id)
        {
            return View(id);
        }

        public ActionResult GanttData(int id)
        {
            var project = service.FindProjectById(id);
            var tasks = taskService.FindTasksByProjectId(id);
            return Json(new Gantt(new ProjectDto(project), tasks.Select(t => new TaskDto(t))),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(Project model)
        {
            try
            {
                service.SaveProject(model);
                var project = service.FindProjectById(model.Id);
                return Json(new ProjectDto(project), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { error = "Sorry! Project was not edited =(" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Create(Project model)
        {
            var anyProject = service.FindAllProjects().Any(p => p.Name.Contains(model.Name));
            if (anyProject)
                return Json(new {error = "Project with this name already exists"}, JsonRequestBehavior.AllowGet);
            try
            {
                service.SaveProject(model);
                var project = service.FindProjectByName(model.Name);
                return Json(new ProjectDto(project), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new {error = "Sorry! Project was not saved =("}, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            service.DeleteProject(id);
            return Json(new {id}, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProjectMembers(int id)
        {
            var users = userService.FindAllUsers();
            var projectMembers = userService.FindUsersByProjectId(id);
            return Json(new ProjectMembersDto(projectMembers.Select(pm => pm.Id),
                users.Select(u => new ProjectMemberDto(u)), id), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveProjectMembers(int projectId, string users)
        {
            try
            {
                var usersIds = users.Split(',').Select(int.Parse).ToArray();
                var saved = userService.FindUsersByProjectId(projectId).Select(s => s.Id);

                service.UpdateProjectMembers(projectId, usersIds, saved);

                return Json(new {}, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { error = "Sorry! Project Members were not saved=(" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
