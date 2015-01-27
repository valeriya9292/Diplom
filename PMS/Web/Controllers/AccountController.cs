using System.Web.Mvc;
using System.Web.Security;
using BLL.DomainModel.Enums;
using BLL.Services;
using Web.Models;
using Web.Providers;

namespace Web.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly UserService service;
        public AccountController(UserService service)
        {
            this.service = service;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LogInModel viewModel, string returnUrl)
        {
            // ((CustomMembershipProvider)Membership.Provider).CreateUser("admin@email.com", "1234567", Role.Admin);
            if (ModelState.IsValid)
            {
                var provider = (CustomMembershipProvider)Membership.Provider;
                if (provider.ValidateUser(viewModel.Login, viewModel.Password))
                {
                    FormsAuthentication.SetAuthCookie(viewModel.Login, viewModel.RememberMe);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    var roleProvider = new CustomRoleProvider();
                    return RedirectToAction("Index", "Project");
                }
                ModelState.AddModelError("", "Incorrect login or password");
            }


            return View(viewModel);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Register(RegisterModel viewModel)
        //{
        //    if (viewModel.Captcha != (string)Session[Web.Infrastructure.Captcha.CaptchaValueKey])
        //    {
        //        ModelState.AddModelError("Captcha", "Text from picture is not correct");
        //        return View(viewModel);
        //    }

        //    var anyUser = service.FindAllUsers().Any(u => u.Email.Contains(viewModel.Email));
        //    if (anyUser)
        //    {
        //        ModelState.AddModelError("Email", "User with this address already exists");
        //        return View(viewModel);
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var membershipUser = ((CustomMembershipProvider)Membership.Provider)
        //                                            .CreateUser(viewModel.Email, viewModel.Password);

        //        if (membershipUser != null)
        //        {
        //            FormsAuthentication.SetAuthCookie(viewModel.Email, false);
        //            return RedirectToAction("GetPublicFiles", "File");
        //        }
        //        ModelState.AddModelError("", "Registration error");
        //    }
        //    return View(viewModel);
        //}

        //public ActionResult Captcha()
        //{
        //    Session[Web.Infrastructure.Captcha.CaptchaValueKey] = RandomUtil.GetRandomString(4);
        //    var captcha = new Captcha(Session[Web.Infrastructure.Captcha.CaptchaValueKey].ToString(), 250, 100,
        //        FontFamily.Families.ElementAt(/*RandomUtil.GetRandomInt(FontFamily.Families.Length - 1)*/1).Name);
        //    Response.Clear();
        //    Response.ContentType = "image/jpeg";
        //    captcha.Image.Save(Response.OutputStream, ImageFormat.Jpeg);
        //    captcha.Dispose();
        //    return null;
        //}
    }
}
