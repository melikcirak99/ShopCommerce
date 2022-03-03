using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;

namespace ShopCommerce.UI.Filter
{
    public class SellerFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string _seller = context.HttpContext.Session.GetString("seller");
            if(_seller == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"area","/" },
                    {"action","SellerLogin" },
                    {"controller","Login" },
                    
                });

            }
            base.OnActionExecuting(context);
        }
    }
}
