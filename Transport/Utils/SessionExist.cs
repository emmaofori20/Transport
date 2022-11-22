using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Transport.Utils
{
    public class SessionExist : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionVar = filterContext.HttpContext.Session.GetString(SessionValueKeys.otherNames);
            if (sessionVar == null)
            {
                filterContext.Result = new RedirectResult("~/Account/SignOut");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
