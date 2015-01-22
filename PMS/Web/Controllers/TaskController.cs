using System;
using System.Linq;
using System.Web.Mvc;
using BLL.DomainModel.Entities;
using BLL.Services;
using Web.Models.DTO;

namespace Web.Controllers
{
    public class TaskController : BaseController
    {
        private readonly TaskService service;
        private readonly UserService userService;
        private readonly ProjectService projectService;

        public TaskController(TaskService service, UserService userService, ProjectService projectService)
        {
            this.service = service;
            this.userService = userService;
            this.projectService = projectService;
        }

        public ActionResult Index(int id)
        {
            var project = projectService.FindProjectById(id);
            return View(new Tuple<int, string>(id, project.Name));
        }

        public ActionResult Get(int id)
        {
            var task = service.FindTaskById(id);

            return Json(new TaskDto(task), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTasks(int id)
        {
            var tasks = service.FindTasksByProjectId(id);
            return Json(tasks.Select(t => new TaskDto(t)), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(Task model)
        {
            try
            {
                service.SaveTask(model);
                var task = service.FindTaskById(model.Id);
                return Json(new TaskDto(task), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { error = "Sorry! Task was not edited =(" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Create(TaskDto model)
        {
            //todo: make name of task unique
            try
            {
                var currentUser = userService.FindUserByLogin(User.Identity.Name);
                var taskToSave = model.ToTask(currentUser.Id);
                var taskId = service.SaveTask(taskToSave);
                var task = service.FindTaskById(taskId);
                return Json(new TaskDto(task), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { error = "Sorry! Task was not saved =(" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            service.DeleteTask(id);
            return Json(new { id }, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult GetTaskMembers(int id)
        //{
        //    var users = userService.FindAllUsers();
        //    var taskMembers = userService.FindUsersByTaskId(id);
        //    return Json(new TaskMembersDto(taskMembers.Select(pm => pm.Id),
        //        users.Select(u => new TaskMemberDto(u)), id), JsonRequestBehavior.AllowGet);
        //}

        //public ActionResult SaveTaskMembers(int taskId, string users)
        //{
        //    try
        //    {
        //        var usersIds = users.Split(',').Select(int.Parse).ToArray();
        //        var saved = userService.FindUsersByTaskId(taskId).Select(s => s.Id);

        //        service.UpdateTaskMembers(taskId, usersIds, saved);

        //        return Json(new { }, JsonRequestBehavior.AllowGet);
        //    }
        //    catch
        //    {
        //        return Json(new { error = "Sorry! Task Members were not saved=(" }, JsonRequestBehavior.AllowGet);
        //    }
        //}    
    }
}
