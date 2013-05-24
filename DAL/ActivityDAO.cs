using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ActivityDAO : BaseDAO
    {
        // Add new activity to activity list
        public Activity InsertNewActivity(Activity objActivity)
        {
            _Database.Activities.Add(objActivity);
            _Database.SaveChanges();

            return objActivity;
        }

        // Add activity to activity list 
        public ActivityListActivity AddToActivityList(Activity objActivity, ActivityList objActivityList)
        {
            ActivityListActivity objALA = new ActivityListActivity();
            objALA.ActivityId = objActivity.ActivityId;
            objALA.ActivityListId = objActivityList.ActivityListId;
            objALA.Date = DateTime.Now;

            _Database.ActivityListActivities.Add(objALA);
            _Database.SaveChanges();

            return objALA;
        }

        // Return list of activities to user
        public List<Activity> GetActivities(String sSearchString)
        {
            var lstResult = _Database.Activities.Where(objActivity => objActivity.Name.Contains(sSearchString) || objActivity.Description.Contains(sSearchString));
            return lstResult.ToList();
        }

        // Remove Activity From Activity List
        public bool RemoveFromActivityList(Activity objActivity, ActivityList objActivityList)
        {
            ActivityListActivity objActivityListActivity = (ActivityListActivity)_Database.ActivityListActivities.Where(objALA => objALA.ActivityListId == objActivityList.ActivityListId && objALA.ActivityId == objActivity.ActivityId);

            _Database.ActivityListActivities.Remove(objActivityListActivity);

            try
            {
                _Database.SaveChanges();
            }
            catch (Exception e)
            {
                System.Console.Write("Error: On Removing Activity from Activity List" + e.Message.ToString());
                return false;
            }
            return true;
        }

        //Get all activity for activity list
        public List<Activity> GetAllForActivityList(ActivityList objActivityList)
        {
            var lstActivityListActivities = _Database.ActivityListActivities.Where(objALA => objALA.ActivityListId == objActivityList.ActivityListId).Select(obj => obj.ActivityId);
            var lstActivities = _Database.Activities.Where(objActivities => lstActivityListActivities.Contains(objActivities.ActivityId));

            return lstActivities.ToList();
        }

    }
}
