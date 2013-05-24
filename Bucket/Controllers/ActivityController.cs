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
    public class ActivityController : Controller
    {
        [HttpPost]
        public ActionResult GetActivityListActivities(String sActivityList)
        {
            if (String.IsNullOrEmpty(sActivityList))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingData
                }));
            var objActivityList = JsonSerializer.DeserializeFromString<ActivityListDto>(sActivityList);
            var objActivityRepository = new ActivityRepository();
            var lstResult = objActivityRepository.GetAllForActivityList(objActivityList);

            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(lstResult)
            })); 

        }

        [HttpPost]
        public ActionResult GetActivites (String sSearchQuery)
        {
            if (String.IsNullOrEmpty(sSearchQuery))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingSearchString
                }));

            var objActivityRepository = new ActivityRepository();
            var lstResult = objActivityRepository.GetActivities(sSearchQuery);

            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(lstResult)
            })); 

        }

        [HttpPost]
        public ActionResult AddActivityToActivityList(String sActivity, String sActivityList)
        {
            if (String.IsNullOrEmpty(sActivityList) ||
                String.IsNullOrEmpty(sActivity))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingData
                }));

            var objActivityList = JsonSerializer.DeserializeFromString<ActivityListDto>(sActivityList);
            var objActivity = JsonSerializer.DeserializeFromString<ActivityDto>(sActivity);
            var objActivityRepository = new ActivityRepository();

            var objActivityListActivity = objActivityRepository.AddToActivityList(objActivity, objActivityList);
            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(objActivityListActivity)
            })); 
        }

        [HttpPost]
        public ActionResult CreateNewActivity(String sActivity)
        {
            if (String.IsNullOrEmpty(sActivity))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingData
                }));
            var objActivity = JsonSerializer.DeserializeFromString<ActivityDto>(sActivity);
            var objActivityRepository = new ActivityRepository();

            var objNewActivity = objActivityRepository.InsertNewActivity(objActivity);
            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(objActivity)
            })); 
        }

        [HttpPost]
        public ActionResult RemoveActivity(String sActivity, String sActivityList)
        {
            if (String.IsNullOrEmpty(sActivityList) ||
                String.IsNullOrEmpty(sActivity))
                return Content(JsonSerializer.SerializeToString(new ResponseStatus
                {
                    ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.ERRORWITHMESSAGE),
                    Data = Resource.MissingData
                }));

            var objActivityList = JsonSerializer.DeserializeFromString<ActivityListDto>(sActivityList);
            var objActivity = JsonSerializer.DeserializeFromString<ActivityDto>(sActivity);
            var objActivityRepository = new ActivityRepository();

            var ActivityRemoved = objActivityRepository.RemoveFromActivityList(objActivity, objActivityList);
            return Content(JsonSerializer.SerializeToString(new ResponseStatus
            {
                ResponseStatusCode = Convert.ToInt32(ResponseStatusCode.SUCCESS),
                Data = JsonSerializer.SerializeToString(ActivityRemoved)
            })); 
        }

    }

}
