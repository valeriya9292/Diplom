using System.Linq;
using System.Web.Mvc;
using BLL.Services;
using Web.Models;
using Web.Models.Convertions;
using Web.Models.DTO;

namespace Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserService service;
        public UserController(UserService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var user = service.FindUserById(id);
            return View(user);
        }

        public ActionResult Profile(string login)
        {

            var user = service.FindUserByLogin(login);
            return View("Details", user);
        }

        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            var anyUser = service.FindAllUsers().Any(u => u.Login.Contains(model.Login));
            if (anyUser)
                return Json(new { error = "Login is used by another user" }, JsonRequestBehavior.AllowGet);
            try
            {
                service.SaveUser(model.ToEntityUser());
                var user = service.FindUserByLogin(model.Login);
                return Json(new UserDto(user), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { error = "Sorry! User was not saved =(" }, JsonRequestBehavior.AllowGet);
            }
        }
        //public ActionResult EditGet(int id)
        //{
        //    var user = service.FindUserById(id);
        //    user.Password = string.Empty;
        //     return Json(user, JsonRequestBehavior.AllowGet);
        //}

        public ActionResult Get(int id)
        {
            var user = service.FindUserById(id);

            return Json(new UserDto(user), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAll()
        {
            var users = service.FindAllUsers();
            return Json(users.Select(u => new UserDto(u)), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(EditUserModel model)
        {
            try
            {
                service.SaveUser(model.ToEntityUserFromEdit());
                var user = service.FindUserById(model.Id);
                return Json(new UserDto(user), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new {error = "Sorry! User was not edited =("}, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Delete(int id)
        {
            service.DeleteUser(id);
            return Json(new { id }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                service.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetUserImage(int id, decimal? flag)
        {
            var user = service.FindUserById(id);
            var avatar = user != null ? user.Avatar : null;
            if (avatar == null)
            {
                var path = Server.MapPath("~/Images/avatar.png");
                avatar = System.IO.File.ReadAllBytes(path);
            }
            return File(avatar, "image/png");
        }
    }
}
