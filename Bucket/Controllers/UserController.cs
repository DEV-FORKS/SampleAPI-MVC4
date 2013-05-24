using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bucket.Models;
using ServiceStack.Text;
using DTO;
using Bucket.BL;
using Bucket.Models;
using RL;
using Bucket.Resources;

namespace Bucket.Controllers
{
    [ExceptionActionFilter]
    public class UserController : Controller
    {
        [HttpPost]
        public ActionResult SignUp(String sUser, int iClientType)
        {
            Console.Write(sUser);
            if (String.IsNullOrEmpty(sUser))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingRegistrationModel
                }));

            var objUserDto = JsonSerializer.DeserializeFromString<UserDto>(sUser);

            if (String.IsNullOrEmpty(objUserDto.Email) ||
                String.IsNullOrEmpty(objUserDto.Password) ||
                String.IsNullOrEmpty(objUserDto.FName) ||
                String.IsNullOrEmpty(objUserDto.LName) ||
                String.IsNullOrEmpty(objUserDto.NickName) ||
                String.IsNullOrEmpty(objUserDto.DateOfBirth) ||
                String.IsNullOrEmpty(objUserDto.Zipcode))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingFeilds
                }));

            var objUserRepository = new UserRepository();

            var objUserDB = objUserRepository.GetUserByEmail(objUserDto.Email);

            if (objUserDB != null)
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.DuplicateEmail
                }));

            objUserDto = objUserRepository.Add(objUserDto);

            var objAccessTokenDto = new AccessTokenRepository()
                                    .RefreshAccessToken(objUserDto, iClientType);

            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = objAccessTokenDto.Token
            }));
        }
     
        [AuthenticationActionFilter]
        public ActionResult GetFriends()
        {
            AccessTokenDto objAccessToken = (AccessTokenDto)TempData["AccessToken"];
            var objUserRepository = new UserRepository();
            var objUser = (objUserRepository.GetUser(Int64.Parse(objAccessToken.UserID)));
            var objFriendRepository = new FriendRepository();
            var lstResult = objFriendRepository.GetAll(objUser); 
            
            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(lstResult)
            }));
        }

        [AuthenticationActionFilter]
        public ActionResult SendFriendRequest(String sUserFriend)
        {
            if(String.IsNullOrEmpty(sUserFriend))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingFriendObject
                }));

            AccessTokenDto objAccessToken = (AccessTokenDto)TempData["AccessToken"];
            var objUserRepository = new UserRepository();
            var objUser = (objUserRepository.GetUser(Int64.Parse(objAccessToken.UserID)));
            var objFriend = JsonSerializer.DeserializeFromString<UserDto>(sUserFriend);
            var objFriendRepository = new FriendRepository();
            bool friendAdded = objFriendRepository.AddFriend(objUser, objFriend);

            if(friendAdded == true)
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                    Data = Resource.FriendRequestSent
                }));
            else
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.ErrorSendingFriendRequest
                }));
        }

        [AuthenticationActionFilter]
        public ActionResult ConfirmFriendRequest(String sUserFriend)
        {
            if (String.IsNullOrEmpty(sUserFriend))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingFriendObject
                }));

            var objFriend = JsonSerializer.DeserializeFromString<UserDto>(sUserFriend);
            AccessTokenDto objAccessToken = (AccessTokenDto)TempData["AccessToken"];
            var objUserRepository = new UserRepository();
            var objUser = (objUserRepository.GetUser(Int64.Parse(objAccessToken.UserID)));
            var objFriendRepository = new FriendRepository();
            var friendConfirmed = objFriendRepository.ConfirmFriend(objUser, objFriend);
            if(friendConfirmed)
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                    Data = Resource.FriendConfirmed
                }));
            else
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.ErrorConfirmingFriend
                }));
        }

        [HttpPost]
        public ActionResult SearchFriend(String sSearchString)
        {
            if(String.IsNullOrEmpty(sSearchString))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingSearchString
                }));

            AccessTokenDto objAccessToken = (AccessTokenDto)TempData["AccessToken"];
            var objUserRepository = new UserRepository();
            var objUser = (objUserRepository.GetUser(Int64.Parse(objAccessToken.UserID)));
            var lstResult = objUserRepository.SearchUser(sSearchString);

            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(lstResult)
            }));
        }

    }
}
