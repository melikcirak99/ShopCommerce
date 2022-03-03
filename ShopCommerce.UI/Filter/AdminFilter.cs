using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace ShopCommerce.UI.Filter
{
    public class AdminFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string _admin = context.HttpContext.Session.GetString("admin");
            if (_admin == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"area","/" },
                    {"action","AdminLogin" },
                    {"controller","Login" }
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
