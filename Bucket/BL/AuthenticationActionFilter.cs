using Bucket.Models;
using RL;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bucket.BL
{
    public class AuthenticationActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string sTokenID = filterContext.HttpContext.Request.Params["AccessToken"];
            if (String.IsNullOrEmpty(sTokenID))
            {
                ReturnWrongAccessToken(filterContext);
                return;
            }
            try
            {
                var objAccessToken = new AccessTokenRepository().GetAccessToken(sTokenID);
                if (objAccessToken == null)
                {
                    ReturnWrongAccessToken(filterContext);
                    return;
                }
                // var objUser = new UserRepository().GetUser(Int64.Parse(objAccessToken.UserId));
                filterContext.Controller.TempData["AccessToken"] = objAccessToken;
                //filterContext.Controller.TempData["User"] = objUser;
            }
            catch (Exception objException)
            {
                var objContentResult = new ContentResult();
                objContentResult.Content = JsonSerializer.SerializeToString(new ResponseStatus { ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERROR) });
                filterContext.Result = objContentResult;
                return;
            }

        }

        private static void ReturnWrongAccessToken(ActionExecutingContext filterContext)
        {
            var objContentResult = new ContentResult();
            objContentResult.Content = JsonSerializer.SerializeToString(new ResponseStatus { ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.WRONGTOKENID) });
            filterContext.Result = objContentResult;
            return;
        }
    }
}
