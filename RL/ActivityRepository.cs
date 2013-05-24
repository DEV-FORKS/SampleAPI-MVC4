using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DAL;
using DTO;

namespace RL
{
    public class ActivityRepository
    {
        private ActivityDAO _ActivityDAO = new ActivityDAO();

        public ActivityDto InsertNewActivity(ActivityDto objActivity)
        {
            var objThisActivity = _ActivityDAO.InsertNewActivity(objActivity.ToBusinessEntity());
            if (objThisActivity == null)
                return null;
            return objThisActivity.ToDataTransferObject();
        }

        public List<ActivityDto> GetActivities(String sSearchString)
        {
            var lstResult = _ActivityDAO.GetActivities(sSearchString);
            var lstActivities = new List<ActivityDto>();
            foreach(Activity a in lstResult)
                lstActivities.Add(a.ToDataTransferObject());
            return lstActivities;
        }
        
        public ActivityListActivityDto AddToActivityList(ActivityDto objActivity, ActivityListDto objActivityList)
        {
            var objActivityListActivity = _ActivityDAO.AddToActivityList(objActivity.ToBusinessEntity(), objActivityList.ToBusinessEntity());
            if (objActivityListActivity == null)
                return null;
            return objActivityListActivity.ToDataTransferObject();
        }

        public bool RemoveFromActivityList(ActivityDto objActivity, ActivityListDto objActivityList)
        {
            return _ActivityDAO.RemoveFromActivityList(objActivity.ToBusinessEntity(), objActivityList.ToBusinessEntity());
        }

        public List<ActivityDto> GetAllForActivityList(ActivityListDto objActivityList)
        {
           var lstResult = _ActivityDAO.GetAllForActivityList(objActivityList.ToBusinessEntity());
           List<ActivityDto> lstActivityDto = new List<ActivityDto>();
            
            foreach(Activity a in lstResult)
                lstActivityDto.Add(a.ToDataTransferObject());
            return lstActivityDto;
        }
    }
}
