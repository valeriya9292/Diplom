using System.Linq;
using System.Web.Mvc;
using BLL.Services;
using Web.Models;
using Web.Models.Convertions;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService service;
        public UserController(UserService service)
        {
            this.service = service;
        }

        public ActionResult Index()
        {
            var users = service.FindAllUsers();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            var user = service.FindUserById(id);
            return View(user);
        }


        public ActionResult Create()
        {
            return PartialView("CreateUser");
        }
        [HttpPost]
        public ActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                var anyUser = service.FindAllUsers().Any(u => u.Login.Contains(model.Login));
                if (anyUser)
                {
                    ModelState.AddModelError("Login", "User already exists");
                    return View("CreateUser", model);
                }
                try
                {
                    var user = model.ToEntityUser();
                    service.SaveUser(user);

                    return RedirectToAction("Index", "User");
                }
                catch
                {
                    return PartialView("CreateUser");
                }
            }
            return PartialView("CreateUser");
        }
        public ActionResult Edit(int id)
        {
            var user = service.FindUserById(id);
            user.Password = string.Empty;
            return PartialView(user.ToViewEditUser());
        }

        public ActionResult Get(int id)
        {
            var user = service.FindUserById(id);
            return Json(new { id, user.FirstName, user.LastName, Role = user.Role.ToString() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAll()
        {
            var user = service.FindAllUsers();
            return Json(user.Select(u => new { id = u.Id, u.FirstName, u.LastName, Role = u.Role.ToString() }), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Edit(EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.ToEntityUserFromEdit();
                service.SaveUser(user);

                return RedirectToAction("Index", "User");
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            service.DeleteUser(id);
            return Json(new { id }, JsonRequestBehavior.AllowGet);
            //var user = service.FindUserById(id);
            //return PartialView(user.ToViewUser());
        }
        public ActionResult DeleteView(int id)
        {
            //service.DeleteUser(id);
            //return Json(new { id }, JsonRequestBehavior.AllowGet);
            var user = service.FindUserById(id);
            return PartialView("Delete", user.ToViewUser());
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

        public ActionResult GetUserImage(int id)
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
