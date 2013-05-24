using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public static class Mapper
    {
        public static UserDto ToDataTransferObject(this User objUser)
        {
            return new UserDto()
            {
                UserID = "" + objUser.UsersId,
                FName = objUser.FName,
                LName = objUser.LName,
                NickName = objUser.NickName,
                Password = objUser.Password,
                DateOfBirth = ((DateTime) objUser.DOB).ToString("MM-dd-yyyy"),
                Zipcode = objUser.Zipcode
            };
        }

        public static User ToBusinessEntity(this UserDto objUser)
        {
            return new User()
            {
                UsersId = String.IsNullOrEmpty(objUser.UserID) ? 0 : Int64.Parse(objUser.UserID),
                FName = objUser.FName,
                LName = objUser.LName,
                NickName = objUser.NickName,
                Password = objUser.Password,
                DOB = DateTime.Parse(objUser.DateOfBirth),
                Zipcode = objUser.Zipcode
            };
        }

        public static AccessTokenDto ToDataTransferObject(this AccessToken objAccessToken)
        {
            return new AccessTokenDto()
            {
                Token = objAccessToken.Token,
                UserID = "" + objAccessToken.UserId,
                ClientType = "" + objAccessToken.ClientType
            };
        }

        public static AccessToken toBusinessEntity(this AccessTokenDto objAccessToken)
        {
            return new AccessToken()
            {
                Token = objAccessToken.Token,
                UserId = Int64.Parse(objAccessToken.UserID),
                ClientType = Int16.Parse(objAccessToken.ClientType)

            };
        }

        public static ActivityListDto ToDataTransferObject(this ActivityList objActivityList)
        {
            return new ActivityListDto()
            {
                ActivityListId = "" + objActivityList.ActivityListId,
                Name = objActivityList.Name,
                DateCreated = ((DateTime)objActivityList.Date).ToString("MM-dd-yyy"),
                NumOfUsers = objActivityList.NumOfUsers.ToString(),
                NumOfActivity = objActivityList.NumOfActivity.ToString()
            };
        }

        public static ActivityList ToBusinessEntity(this ActivityListDto objActivityList)
        {
            return new ActivityList()
            {
                ActivityListId = String.IsNullOrEmpty(objActivityList.ActivityListId) ? 0 : Int64.Parse(objActivityList.ActivityListId),
                Name = objActivityList.Name,
                Date = DateTime.Parse(objActivityList.DateCreated),
                NumOfUsers = Int32.Parse(objActivityList.NumOfUsers),
                NumOfActivity = Int32.Parse(objActivityList.NumOfActivity)

            };
        }

        public static UserActivityListDto ToDataTransferObject(this UserActivityList objUserActivityList)
        {
            return new UserActivityListDto()
            {
                UserActivityListID = "" + objUserActivityList.UserActivityListId,
                UserID = "" + objUserActivityList.UserId,
                ActivityListID = "" + objUserActivityList.ActivityListId,
                Date = ((DateTime)objUserActivityList.Date).ToString("MM-dd-yyyy"),
                Status = objUserActivityList.Status
            };
        }

        public static UserActivityList ToBusinessEntity(this UserActivityListDto objUserActivityList)
        {
            return new UserActivityList()
            {
                UserActivityListId = String.IsNullOrEmpty(objUserActivityList.UserActivityListID) ? 0 : Int64.Parse(objUserActivityList.UserActivityListID),
                UserId = String.IsNullOrEmpty(objUserActivityList.UserID) ? 0 : Int64.Parse(objUserActivityList.UserID),
                ActivityListId = String.IsNullOrEmpty(objUserActivityList.ActivityListID) ? 0 : Int64.Parse(objUserActivityList.ActivityListID),
                Date = DateTime.Parse(objUserActivityList.Date),
                Status = objUserActivityList.Status
            };
        }

        public static ActivityDto ToDataTransferObject(this Activity objActivity)
        {
            return new ActivityDto()
            {
                ActivityID = "" + objActivity.ActivityId,
                Name = objActivity.Name, 
                Description = objActivity.Description,
                Date = ((DateTime)objActivity.Date).ToString("MM-dd-yyyy"),
                Address = objActivity.Address,
                City = objActivity.City,
                State = objActivity.State, 
                Zipcode = objActivity.Zipcode
            };
        }

        public static Activity ToBusinessEntity(this ActivityDto objActivity)
        {
            return new Activity()
            {
                ActivityId = String.IsNullOrEmpty(objActivity.ActivityID) ? 0 : Int64.Parse(objActivity.ActivityID),
                Name = objActivity.Name,
                Description = objActivity.Description,
                Date = DateTime.Parse(objActivity.Date), 
                Address = objActivity.Address,
                City = objActivity.City, 
                State = objActivity.State,
                Zipcode = objActivity.Zipcode
            };
        }

        public static ActivityListActivityDto ToDataTransferObject(this ActivityListActivity objALA)
        {
            return new ActivityListActivityDto()
            {
                ActivityListActivityID = "" + objALA.ActivityListActivityId,
                ActivityID  = "" + objALA.ActivityId, 
                ActivityListID = "" + objALA.ActivityListId, 
                Date = ((DateTime)objALA.Date).ToString("MM-dd-yyyy")
            };
        }

        public static ActivityListActivity ToBusinessEntity(this ActivityListActivityDto objALA)
        {
            return new ActivityListActivity()
            {
               ActivityListActivityId = String.IsNullOrEmpty(objALA.ActivityListActivityID) ? 0 : Int64.Parse(objALA.ActivityListActivityID),
               ActivityId = String.IsNullOrEmpty(objALA.ActivityID) ? 0 : Int64.Parse(objALA.ActivityID),
               ActivityListId = String.IsNullOrEmpty(objALA.ActivityListID) ? 0 : Int64.Parse(objALA.ActivityListID),
               Date = DateTime.Parse(objALA.Date)
            };
        }

        public static UserActivityDto ToDataTransferObject(this UserActivity objUA)
        {
            return new UserActivityDto()
            {
                UserActivityID = "" + objUA.UserActivityId,
                ActivityListActivityID = "" + objUA.ActivityListActivityId, 
                UserID = "" + objUA.UserId,
                Status = objUA.Status,
                ReviewID = "" + objUA.ReviewId
            };
        }

        public static UserActivity ToBusinessEntity(this UserActivityDto objUA)
        {
            return new UserActivity()
            {
                UserActivityId = String.IsNullOrEmpty(objUA.UserActivityID) ? 0 : Int64.Parse(objUA.UserActivityID),
                ActivityListActivityId = String.IsNullOrEmpty(objUA.ActivityListActivityID) ? 0 : Int64.Parse(objUA.ActivityListActivityID),
                UserId = String.IsNullOrEmpty(objUA.UserID) ? 0 : Int64.Parse(objUA.UserID),
                Status = objUA.Status,
                ReviewId = String.IsNullOrEmpty(objUA.ReviewID) ? 0 : Int64.Parse(objUA.ReviewID)
            };
        }

        public static ReviewDto ToDataTransferObject(this Review objReview)
        {
            return new ReviewDto()
            {
                ReviewID = "" + objReview.ReviewId, 
                ActivityID = "" + objReview.ActivityId,
                UserID = "" + objReview.UserId,
                Review = objReview.Review1, 
                ReviewDate = ((DateTime)objReview.ReviewDate).ToString("MM-dd-yyyy")
            };
        }

        public static Review ToBusinessEntity(this ReviewDto objReview)
        {
            return new Review()
            {
                ReviewId = String.IsNullOrEmpty(objReview.ReviewID) ? 0 : Int64.Parse(objReview.ReviewID),
                ActivityId = String.IsNullOrEmpty(objReview.ActivityID) ? 0 : Int64.Parse(objReview.ActivityID),
                UserId = String .IsNullOrEmpty(objReview.UserID) ? 0 : Int64.Parse(objReview.UserID),
                Review1 = objReview.Review, 
                ReviewDate = DateTime.Parse(objReview.ReviewDate)
            };
        }

        public static FriendDto ToDataTransferObject(this Friend objFriend)
        {
            return new FriendDto()
            {
                FID = "" + objFriend.FId,
                UserID = "" + objFriend.UserId,
                FriendID = "" + objFriend.FriendId,
                Status = objFriend.Status,
                Date = ((DateTime)objFriend.Date).ToString("MM-dd-yyyy")
            };
        }

        public static Friend ToBusinessEntity(this FriendDto objFriend)
        {
            return new Friend()
            {
                FId = String.IsNullOrEmpty(objFriend.FID) ? 0 : Int64.Parse(objFriend.FID),
                UserId = String.IsNullOrEmpty(objFriend.UserID) ? 0 : Int64.Parse(objFriend.UserID),
                FriendId = String.IsNullOrEmpty(objFriend.FriendID) ? 0 : Int64.Parse(objFriend.FriendID),
                Status = objFriend.Status,
                Date = DateTime.Parse(objFriend.Date)
            };
        }
    }
}
