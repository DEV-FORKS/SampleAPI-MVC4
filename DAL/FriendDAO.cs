using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Resources;

namespace DAL
{
    public class FriendDAO : BaseDAO
    {
        // Add the user as friend and sets status
        public bool AddFriend(User objUser, User objFriend)
        {
           var lstResult = _Database.Friends.Where(objF => objF.UserId == objUser.UsersId && objF.FriendId == objFriend.UsersId);

            if(lstResult.Count() > 0)
                return false;

            Friend objUserFriend = new Friend();
            objUserFriend.UserId = objUser.UsersId;
            objUserFriend.FriendId = objFriend.UsersId;
            objUserFriend.Status = ResourceDAL.FriendStatusFriends;
            objUserFriend.Date = DateTime.Now;

            _Database.Friends.Add(objUserFriend);
            _Database.SaveChanges();

            Friend objFriendRequest = new Friend();
            objFriendRequest.UserId = objFriend.UsersId;
            objFriendRequest.FriendId = objUser.UsersId;
            objFriendRequest.Status = ResourceDAL.FriendStatusPending;
            objFriendRequest.Date = DateTime.Now;

            return true;
        }

        public List<User> GetAll(User objUser)
        {
            var lstFriendsUserId = _Database.Friends.Where(objFriends => objFriends.UserId == objUser.UsersId && objFriends.Status.Equals(ResourceDAL.FriendStatusFriends)).Select(obj => obj.FriendId);
            var lstFriends = _Database.Users.Where(objFriends => lstFriendsUserId.Contains(objFriends.UsersId));
            return lstFriends.ToList();
        }

        public Friend UpdateFriendStatus(Friend objFriend)
        {
            var lstResult = _Database.Friends.Where(objF => objFriend.UserId == objFriend.UserId && objF.FriendId == objFriend.FriendId);

            if (lstResult.Count() == 0)
                return null;
            Friend objThisFriend = (Friend)lstResult.First();
            objThisFriend.Status = ResourceDAL.FriendStatusFriends;
            objThisFriend.Date = DateTime.Now;

            _Database.SaveChanges();

            return objThisFriend;
        }

        public bool DeleteFriend(User objUser, User objFriend)
        {
            var lstResult = _Database.Friends.Where(objF => (objF.UserId == objUser.UsersId && objF.FriendId == objF.FriendId) || (objF.UserId == objFriend.UsersId && objF.FriendId == objUser.UsersId));

            foreach(Friend f in lstResult)
                _Database.Friends.Remove(f);
            _Database.SaveChanges();

            return true;
        }

        public bool ConfirmFriend(User objUser, User objFriend)
        {
            var lstResult = _Database.Friends.Where(objF => objF.UserId == objUser.UsersId && objF.FriendId == objFriend.UsersId);

            if (lstResult.Count() == 0)
                return false;

            Friend objUserFriend = new Friend();
            objUserFriend = lstResult.First();
            objUserFriend.Status = ResourceDAL.FriendStatusFriends;
            _Database.SaveChanges();
            return true;
        }
    }
}
