using System.Web.Mvc;

namespace Grupo10_ControlPrestamos_ASPNet.Filters
{
    public class SessionAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session["Usuario"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new System.Web.Routing.RouteValueDictionary(
                        new
                        {
                            controller = "Account",
                            action = "Login"
                        }));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
