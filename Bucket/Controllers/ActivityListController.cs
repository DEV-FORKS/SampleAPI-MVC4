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
    [AuthenticationActionFilter]
    [ExceptionActionFilter]
    public class ActivityListController : Controller
    {
        [HttpGet]
        public ActionResult GetActivityList()
        {
            AccessTokenDto objAccessToken = (AccessTokenDto)TempData["AccessToken"];
            var objUserRepository = new UserRepository();
            var objUser = (objUserRepository.GetUser(Int64.Parse(objAccessToken.UserID)));
            var objActivityListRepository = new ActivityListRepository();
            var lstResult = objActivityListRepository.GetUserActivityList(objUser);
           
            return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                    Data = JsonSerializer.SerializeToString(lstResult)
                }));
        }

        [HttpGet]
        public ActionResult GetPendingActivityList()
        {
            AccessTokenDto objAccessToken = (AccessTokenDto)TempData["AccessToken"];
            var objUserRepository = new UserRepository();
            var objUser = (objUserRepository.GetUser(Int64.Parse(objAccessToken.UserID)));
            var objActivityListRepository = new ActivityListRepository();
            var lstResult = objActivityListRepository.GetPendingUserActivityList(objUser);

            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(lstResult)
            }));
        }

        [HttpPost]
        public ActionResult CreateNewActivityList(String sActivityList)
        {
            if (String.IsNullOrEmpty(sActivityList))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingData
                }));

            var objActivityList = JsonSerializer.DeserializeFromString<ActivityListDto>(sActivityList);
            AccessTokenDto objAccessToken = (AccessTokenDto)TempData["AccessToken"];
            var objUserRepository = new UserRepository();
            var objUser = (objUserRepository.GetUser(Int64.Parse(objAccessToken.UserID)));

            var objActivityListRepository = new ActivityListRepository();
            var objNewActivityList = objActivityListRepository.CreateNew(objActivityList, objUser);
            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(objNewActivityList)
            }));
        }

        [HttpPost]
        public ActionResult InviteUsersToActivityList(String  sListUser, String sActivityList)
        {
            if (String.IsNullOrEmpty(sListUser) || 
                String.IsNullOrEmpty(sActivityList))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingData
                }));

            var lstUser = JsonSerializer.DeserializeFromString<List<UserDto>>(sListUser);
            var objActivityList = JsonSerializer.DeserializeFromString<ActivityListDto>(sActivityList);

            var objActivityListRepository = new ActivityListRepository();
            var lstResult = objActivityListRepository.AddMultipleUsersToActivityList(lstUser, objActivityList);
            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(lstResult)
            }));
        }

        [HttpPost]
        public ActionResult AcceptActivityListInvite(String sActivityList)
        {
            if (String.IsNullOrEmpty(sActivityList))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingData
                }));

            var objActivityList = JsonSerializer.DeserializeFromString<ActivityListDto>(sActivityList);
            AccessTokenDto objAccessToken = (AccessTokenDto)TempData["AccessToken"];
            var objUserRepository = new UserRepository();
            var objUser = (objUserRepository.GetUser(Int64.Parse(objAccessToken.UserID)));

            var objActivityListRepository = new ActivityListRepository();
            var objUserActivityList = objActivityListRepository.ConfirmUserActivityListStatus(objUser, objActivityList);
            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(objUserActivityList)
            }));
        }
    }
}
