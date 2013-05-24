using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServiceStack.Text;
using Bucket.Models;
using Bucket.Resources;
using RL;
using BL;

namespace Bucket.Controllers
{
    public class AuthenticationController : Controller
    {
        [HttpPost]
        public ActionResult LogOn(String sLogOn)
        {
            if (String.IsNullOrEmpty(sLogOn))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingLogOnModel
                }));

            var objLogOn = JsonSerializer.DeserializeFromString<LogOn>(sLogOn);

            if (String.IsNullOrEmpty(objLogOn.Email) ||
                String.IsNullOrEmpty(objLogOn.Password))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingLogOnModel
                }));

            var objUserRepository = new UserRepository();
            var objUserDto = objUserRepository.GetUser(objLogOn.Email, objLogOn.Password);

            if (objUserDto == null)
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingLogOnModel
                }));

            var objAccessTokenDto = new AccessTokenRepository()
                                    .RefreshAccessToken(objUserDto, objLogOn.ClientType);

            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = objAccessTokenDto.Token
            }));
        }

    }
}
