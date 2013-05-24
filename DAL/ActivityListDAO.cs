using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Resources;

namespace DAL
{
    public class ActivityListDAO : BaseDAO
    {
        // Return an activity list for the given id
        public ActivityList Get(long sActivityListId)
        {
            var lstResult = _Database.ActivityLists.Where(ObjActivityList => ObjActivityList.ActivityListId == sActivityListId);

            if (lstResult.Count() == 0)
                return null;
            return lstResult.First();
        }

        // return all the activity list for a user
        public List<ActivityList> GetUserActivityList(User objUser)
        {
            var lstUserActivtyListIds = _Database.UserActivityLists.Where(objUserActivityList => objUserActivityList.UserId == objUser.UsersId && objUserActivityList.Status.Equals(ResourceDAL.UserActivityListStatusMember)).Select(obj => obj.ActivityListId);
            var lstActivtyList = _Database.ActivityLists.Where(objActivityList => lstUserActivtyListIds.Contains(objActivityList.ActivityListId));
            return lstActivtyList.ToList();
        }
        // return all the activity list for a user
        public List<ActivityList> GetPendingUserActivityList(User objUser)
        {
            var lstUserActivtyListIds = _Database.UserActivityLists.Where(objUserActivityList => objUserActivityList.UserId == objUser.UsersId && objUserActivityList.Status.Equals(ResourceDAL.UserActivityListStausPending)).Select(obj => obj.ActivityListId);
            var lstActivtyList = _Database.ActivityLists.Where(objActivityList => lstUserActivtyListIds.Contains(objActivityList.ActivityListId));
            return lstActivtyList.ToList();
        }

        // Get List of users for a given activity List
        public List<User> GetUsers(ActivityList objActivityList)
        {
            var lstActivityListUserIds = _Database.UserActivityLists.Where(objUserActivity => objUserActivity.ActivityListId == objActivityList.ActivityListId && objUserActivity.Status.Equals(ResourceDAL.UserActivityListStatusMember)).Select(obj => obj.UserId);
            var lstUser = _Database.Users.Where(objUsers => lstActivityListUserIds.Contains(objUsers.UsersId));
            return lstUser.ToList();
        }

        // Add new activity List to Activity List and User Activity List
        public ActivityList CreateNew(ActivityList objActivityList, User objUser)
        {
            
            // Insert Activity List
            _Database.ActivityLists.Add(objActivityList);
            _Database.SaveChanges();
            
            // Insert User Activity List
            UserActivityList objUserActivityList = new UserActivityList();
            objUserActivityList.ActivityListId = objActivityList.ActivityListId;
            objUserActivityList.UserId = objUser.UsersId;
            objUserActivityList.Status = "MEMBER";
            objUserActivityList.Date = DateTime.Now;
            
            _Database.UserActivityLists.Add(objUserActivityList);
            _Database.SaveChanges();

            return objActivityList;
        }

        // Update the User Activity list status - to new Status
        public UserActivityList ConfirmUserActivityListStatus(User objUser, ActivityList objActivityList)
        {
            UserActivityList newObjUserActivityList = (UserActivityList) _Database.UserActivityLists.Where(objUAL => objUAL.ActivityListId == objActivityList.ActivityListId && objUAL.UserId == objUser.UsersId);
            newObjUserActivityList.Status = ResourceDAL.UserActivityListStatusMember;
            _Database.SaveChanges();

            return newObjUserActivityList;
        }

        //Add User to activity list 
        public UserActivityList AddUser(ActivityList objActivityList, User objUser)
        {
            UserActivityList objUserActivityList = new UserActivityList();

            objUserActivityList.UserId = objUser.UsersId;
            objUserActivityList.ActivityListId = objActivityList.ActivityListId;
            objUserActivityList.Status = ResourceDAL.UserActivityListStausPending;
            objUserActivityList.Date = DateTime.Now;

            _Database.UserActivityLists.Add(objUserActivityList);
            _Database.SaveChanges();

            return objUserActivityList;
        }

        // Add multiple user to activity list
        public List<UserActivityList> AddMultipleUsersToActivityList(List<User> lstUser, ActivityList objActivityList)
        {
            var lstUserActivityList = new List<UserActivityList>();
            foreach (User u in lstUser)
                lstUserActivityList.Add(AddUser(objActivityList, u));
            return lstUserActivityList;
        }

        //Remove user from activity list
        public bool RemoveUser(ActivityList objActivityList, User objUser)
        {
            UserActivityList objUserActivityList =(UserActivityList)_Database.UserActivityLists.Where(objUAL => objUAL.ActivityListId == objActivityList.ActivityListId && objUAL.UserId == objUser.UsersId);

            _Database.UserActivityLists.Remove(objUserActivityList);

            try
            {
                _Database.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.Write("Error: On Removing User from Activity" + e.Message.ToString());
                return false;
            }
            return true;

        }
    
        // Delete an Activity List if the user is the owner of the activity 
        public bool DeleteActivityList(ActivityList objActivityList, User objUser)
        {
            return false;
        }
    }
}
