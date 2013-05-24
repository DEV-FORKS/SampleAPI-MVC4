using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccessTokenDAO : BaseDAO
    {
        public AccessToken GetByUserIdAndClientType(long lUserId, int iClientType)
        {
            var lstResults = _Database.AccessTokens.Where(objAccessToken =>
                                                            objAccessToken.UserId == lUserId &&
                                                            objAccessToken.ClientType == iClientType);
            if (lstResults.Count() == 0)
                return null;
            return lstResults.First();
        }

        public void Add (AccessToken objAccessToken)
        {
            _Database.AccessTokens.Add(objAccessToken);
            _Database.SaveChanges();
        }

        public void Delete(AccessToken objAccessToken)
        {
            _Database.AccessTokens.Remove(objAccessToken);
            _Database.SaveChanges();
        }

        public AccessToken GetByToken(string sAccessToken)
        {
            var lstResults = _Database.AccessTokens.Where(objAccessToken =>
                                                            objAccessToken.Token.Equals(sAccessToken));
            if (lstResults.Count() == 0)
                return null;
            return lstResults.First();
        }
    }
}
