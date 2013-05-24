using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Resources;
namespace DAL
{
    public class UserActivityDAO : BaseDAO
    {
        public UserActivity Update(UserActivity objUserActivity, Review objReview)
        {
           var lstResult = _Database.UserActivities.Where(objUA => objUA.ActivityListActivityId == objUserActivity.ActivityListActivityId && objUA.UserId == objUserActivity.UserId);

            // If review user does not exist inset new else update the old oe. 
           if (lstResult.Count() == 0)
               return Insert(objUserActivity, objReview);
           else
           {
               UserActivity newObjUserActivity = lstResult.First();

               objReview.ReviewId = Convert.ToInt64(newObjUserActivity.ReviewId);
               objReview = (new ReviewDAO()).Update(objReview);

               newObjUserActivity.Status = objUserActivity.Status;
                _Database.SaveChanges();
                return newObjUserActivity;
              
           }

        }

        public UserActivity Insert(UserActivity objUserActivity, Review objReview)
        {
            objReview = (new ReviewDAO()).Insert(objReview);
            objUserActivity.ReviewId = objReview.ReviewId;

            _Database.UserActivities.Add(objUserActivity);
            _Database.SaveChanges();

            return objUserActivity;
        }
    }
}
