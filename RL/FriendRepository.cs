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
    public class FriendRepository
    {
        private FriendDAO _FriendDAO = new FriendDAO();

        public bool AddFriend(UserDto objUser, UserDto objFriend)
        {
            return _FriendDAO.AddFriend(objUser.ToBusinessEntity(), objFriend.ToBusinessEntity());  
        }

        public List<UserDto> GetAll(UserDto objUser)
        {
            var lstResult = _FriendDAO.GetAll(objUser.ToBusinessEntity());
            List<UserDto> ul = new List<UserDto>();

            foreach (User u in lstResult)
                ul.Add(u.ToDataTransferObject());

            return ul;
        }

        public FriendDto UpdateFriendStatus(FriendDto objFriend)
        {
            var objThisFriend = _FriendDAO.UpdateFriendStatus(objFriend.ToBusinessEntity());
            if (objThisFriend == null)
                return null;
            return objThisFriend.ToDataTransferObject();
        }

        public bool DeleteFriend(UserDto objUser, UserDto objFriend)
        {
            return _FriendDAO.DeleteFriend(objUser.ToBusinessEntity(), objFriend.ToBusinessEntity());  
        }

        public bool ConfirmFriend(UserDto objUser, UserDto objFriend)
        {
            return _FriendDAO.ConfirmFriend(objUser.ToBusinessEntity(), objFriend.ToBusinessEntity());
        }
    }
}
