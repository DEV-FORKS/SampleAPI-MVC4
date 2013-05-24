using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
using BL;

namespace RL
{
    public class AccessTokenRepository
    {
        private AccessTokenDAO _AccessTokenDAO = new AccessTokenDAO();
       
        public AccessTokenDto RefreshAccessToken(UserDto objUser, int iClientType)
        {
            var objAccessToken = _AccessTokenDAO.GetByUserIdAndClientType(Int64.Parse(objUser.UserID), iClientType);
            AccessToken objNewAccessToken = null;
            if (objAccessToken == null)
                objNewAccessToken= CreateNewAccessToken(Int64.Parse(objUser.UserID), iClientType);
            else
                objNewAccessToken=  ReplaceCurrentAccessToken(objAccessToken);

            return objNewAccessToken.ToDataTransferObject();
        }

        private AccessToken ReplaceCurrentAccessToken(AccessToken objAccessToken)
        {
            _AccessTokenDAO.Delete(objAccessToken);
            long uID = Int64.Parse(objAccessToken.UserId.ToString());
            int cT = Int32.Parse(objAccessToken.ClientType.ToString());
            return CreateNewAccessToken(uID, cT);
        }

        private AccessToken CreateNewAccessToken(long lUserId, int iClientType)
        {
            AccessToken objAccessToken = new AccessToken();
            objAccessToken.UserId = lUserId;
            objAccessToken.ClientType = (short)iClientType;
            objAccessToken.Token=
                                    SecurityLogic.GetHash(""+lUserId
                                                 + SecurityLogic.GetRandomString(35, false)
                                                 + iClientType, SecurityLogic.HashType.SHA512);
            _AccessTokenDAO.Add(objAccessToken);
            return objAccessToken;
        }

        public AccessTokenDto GetAccessToken(String sAccessToken)
        {
            if (String.IsNullOrEmpty(sAccessToken))
                return null;
            var objAccessToken = _AccessTokenDAO.GetByToken(sAccessToken);

            if (objAccessToken == null)
                return null;
            return objAccessToken.ToDataTransferObject();
        }
    }
}
