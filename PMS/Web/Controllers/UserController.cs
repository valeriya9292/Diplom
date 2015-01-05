using System;
using System.IO;
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
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View("CreateUser");
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
                    return View();
                }
            }
            return View();
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var user = service.FindUserById(id);
                user.FirstName = collection["FirstName"];
                user.LastName = collection["LastName"];
                user.Email = collection["Email"];
                user.Skype = collection["Skype"];
                user.Phone = collection["Phone"];
                service.SaveUser(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
