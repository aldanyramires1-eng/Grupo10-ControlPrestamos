using System.Web.Mvc;

namespace Grupo10_ControlPrestamos_ASPNet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }
    }
}
