using System.Web.Mvc;
using Grupo10_ControlPrestamos_ASPNet.Models;

namespace Grupo10_ControlPrestamos_ASPNet.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Usuario"] != null)
            {
                return RedirectToAction("Index", "Prestamos");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Usuario == "admin" && model.Password == "123")
            {
                Session["Usuario"] = model.Usuario;
                return RedirectToAction("Index", "Prestamos");
            }

            ModelState.AddModelError(string.Empty, "Credenciales incorrectas.");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
