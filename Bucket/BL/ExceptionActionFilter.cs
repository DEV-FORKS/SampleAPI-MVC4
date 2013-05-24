using Bucket.Models;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bucket.BL
{
    public class ExceptionActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

            if (filterContext.Exception != null && filterContext.ExceptionHandled == false)
            {
                object sTokenID = filterContext.HttpContext.Request.Params["AccessToken"];
                if (sTokenID != null)
                {
                    // ErrorBL.LogServerError(sTokenID, filterContext.Exception);
                }
                var objContentResult = new ContentResult();
                objContentResult.Content = JsonSerializer.SerializeToString(new ResponseStatus { ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERROR) });
                filterContext.ExceptionHandled = true;
                filterContext.Result = objContentResult;
            }
        }
    }
}