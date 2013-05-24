using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAO : BaseDAO
    {
        // Return user object based on email and passowrd
        public User GetUser(String sEmail, String sPassword)
        {
            var lstResult = _Database.Users.Where(objUser => objUser.Email.Equals(sEmail.ToLower()) && objUser.Password.Equals(sPassword));

            if (lstResult.Count() == 0)
                return null;

            return lstResult.First();
        }

        // Overload method: Returen user object based on UserId
        public User GetUser(long lUserId)
        {
            var lstResult = _Database.Users.Where(ObjUser => ObjUser.UsersId == lUserId);

            if (lstResult.Count() == 0)
                return null;
            return lstResult.First();
        }

        // Return user object by Email
        public User GetUserByEmail(String sEmail)
        {
            var lstResult = _Database.Users.Where(ObjUser => ObjUser.Email.Equals(sEmail.ToLower()));

            if (lstResult.Count() == 0)
                return null;

            return lstResult.First();
        }

        // Return user object based on any matching string - FName, LName, Email
        public List<User> SearchUser(String sSearchString)
        {
            var lstResult = _Database.Users.Where(ObjUser => ObjUser.FName.Contains(sSearchString) || ObjUser.LName.Contains(sSearchString)|| (ObjUser.Email.Contains(sSearchString)));
            return lstResult.ToList();
        }

        // Add user to user table
        public User Add(User objUser)
        {
            _Database.Users.Add(objUser);
            _Database.SaveChanges();
            return objUser;
        }
    }
}
