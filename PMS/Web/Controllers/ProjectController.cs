using System.Web.Mvc;

namespace Web.Controllers
{
    public class ProjectController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProjects()
        {
            return Json(new[]
            {
                new
                {
                    label = "Project1",
                    id = 1,
                    children = new[] {new {label = "Task1", id = 2}, new {label = "Task2", id = 3}}
                }
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
