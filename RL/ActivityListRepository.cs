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
    public class ActivityListRepository
    {
        private ActivityListDAO _ActivityListDAO = new ActivityListDAO();

        public ActivityListDto Get(long sActivityListId)
        {
            var ActivityListDto = _ActivityListDAO.Get(sActivityListId);
            if (ActivityListDto == null)
                return null;
            return ActivityListDto.ToDataTransferObject();
        }

        public List<ActivityListDto> GetUserActivityList(UserDto objUser)
        {
            var lstResult = _ActivityListDAO.GetUserActivityList(objUser.ToBusinessEntity());
            List<ActivityListDto> lstActivityListDto = new List<ActivityListDto>();

            foreach (ActivityList al in lstResult)
                lstActivityListDto.Add(al.ToDataTransferObject());

            return lstActivityListDto;
        }

        public List<ActivityListDto> GetPendingUserActivityList(UserDto objUser)
        {
            var lstResult = _ActivityListDAO.GetUserActivityList(objUser.ToBusinessEntity());
            List<ActivityListDto> lstActivityListDto = new List<ActivityListDto>();

            foreach (ActivityList al in lstResult)
                lstActivityListDto.Add(al.ToDataTransferObject());

            return lstActivityListDto;
        }
       
        public List<UserDto> GetUsers(ActivityList objActivityList)
        {
            var lstResult = _ActivityListDAO.GetUsers(objActivityList);
            List<UserDto> lstUserDto = new List<UserDto>();

            foreach (User u in lstResult)
                lstUserDto.Add(u.ToDataTransferObject());
            return lstUserDto;
        }

        public ActivityListDto CreateNew(ActivityListDto objActivityList, UserDto objUser)
        {
            var objThisActivityList = _ActivityListDAO.CreateNew(objActivityList.ToBusinessEntity(), objUser.ToBusinessEntity());
            if (objThisActivityList == null)
                return null;
            return objThisActivityList.ToDataTransferObject();
        }

        public UserActivityListDto ConfirmUserActivityListStatus(UserDto objUser, ActivityListDto objActivityList)
        {
            var objUserActivityListDto = _ActivityListDAO.ConfirmUserActivityListStatus(objUser.ToBusinessEntity(), objActivityList.ToBusinessEntity());
            return objUserActivityListDto.ToDataTransferObject();
        }

        public UserActivityListDto AddUser(ActivityList objActivityList, User objUser)
        {
            var objUserActivityListDto = _ActivityListDAO.AddUser(objActivityList, objUser);
            if (objUserActivityListDto == null)
                return null;
            return objUserActivityListDto.ToDataTransferObject();
        }

        public List<UserActivityListDto> AddMultipleUsersToActivityList(List<UserDto> lstUserDto, ActivityListDto objActivityListDto)
        {
            var lstUser = new List<User>();
            foreach(UserDto u in lstUserDto)
                lstUser.Add(u.ToBusinessEntity());
            var lstResult = _ActivityListDAO.AddMultipleUsersToActivityList(lstUser, objActivityListDto.ToBusinessEntity());

            var lstUserActivityList = new List<UserActivityListDto>();
            foreach (UserActivityList ula in lstResult)
                lstUserActivityList.Add(ula.ToDataTransferObject());

            return lstUserActivityList;


        }
        public bool RemoveUser(ActivityList objActivityList, User objUser)
        {
            return _ActivityListDAO.RemoveUser(objActivityList, objUser);
        }

        public bool DeleteActivityList(ActivityList objActivityList, User objUser)
        {
            return _ActivityListDAO.DeleteActivityList(objActivityList, objUser);
        }
    }
}
