﻿using System;
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
        public ActionResult Edit(int id)
        {
            var user = service.FindUserById(id);
            user.Password = string.Empty;
            return View(user.ToViewEditUser());
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
            var user = service.FindUserById(id);
            return View(user.ToViewUser());
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
