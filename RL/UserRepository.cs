using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DTO;
using DAL;

namespace RL
{
    public class UserRepository
    {
        private UserDAO _UserDAO = new UserDAO();

        public UserDto GetUser(String sEmail, String sPassword)
        {
            var objUser = _UserDAO.GetUser(sEmail, sPassword);
            if (objUser == null)
                return null;
            return objUser.ToDataTransferObject();
        }

        public UserDto GetUser(long lUserId)
        {
            var objUser = _UserDAO.GetUser(lUserId);
            if (objUser == null)
                return null;
            return objUser.ToDataTransferObject();
        }
   
        public UserDto GetUserByEmail(String sEmail)
        {
            var objUser = _UserDAO.GetUserByEmail(sEmail);
            if (objUser == null)
                return null;
            return objUser.ToDataTransferObject();
        }
        
        public List<UserDto> SearchUser(String sSearchString)
        {
            var lstResult = _UserDAO.SearchUser(sSearchString);
            var lstUser = new List<UserDto>();

            foreach (User u in lstResult)
                lstUser.Add(u.ToDataTransferObject());
            
            return lstUser;
        }
        public UserDto Add(UserDto objUserDto)
        {
            objUserDto.Password = SecurityLogic.GetHash("BUCKET" + objUserDto.Password, SecurityLogic.HashType.SHA512);
            objUserDto.Email = objUserDto.Email.ToLower();
            var objUser = _UserDAO.Add(objUserDto.ToBusinessEntity());
            return objUser.ToDataTransferObject();
        }
    }
}
