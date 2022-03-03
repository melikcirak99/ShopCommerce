using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace ShopCommerce.UI.Filter
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string _user = context.HttpContext.Session.GetString("user");
            if(_user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"area","/" },
                    {"action","Login" },
                    {"controller","User" }
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
