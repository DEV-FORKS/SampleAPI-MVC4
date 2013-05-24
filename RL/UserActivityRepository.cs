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
    public class UserActivityRepository
    {
        private UserActivityDAO _UserActivityDAO = new UserActivityDAO();

        public UserActivityDto Update(UserActivityDto objUserActivity, ReviewDto objReview)
        {
            var objNewUserActivity = _UserActivityDAO.Update(objUserActivity.ToBusinessEntity(), objReview.ToBusinessEntity());
            if (objNewUserActivity == null)
                return null;
            return objNewUserActivity.ToDataTransferObject();
        }

    }
}
