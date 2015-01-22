using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Web.Controllers
{
    public class BaseController : Controller
    {
        public string CurrentRole
        {
            get { return Roles.GetRolesForUser(User.Identity.Name).FirstOrDefault(); }
        }
    }
}
