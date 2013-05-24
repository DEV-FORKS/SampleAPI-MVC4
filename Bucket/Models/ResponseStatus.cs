using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bucket.Models
{
    public class ResponseStatus
    {
        public int ResponseStatusCode
        {
            get { return m_ResponseStatusCode; }
            set { m_ResponseStatusCode = value; }
        }
        private int m_ResponseStatusCode;
        public object Data
        {
            get { return m_Data; }
            set { m_Data = value; }
        }
        private object m_Data;
    }
    public enum ResponseStatusCode : byte
    {
        ERROR = 0,
        SUCCESS = 1,
        WRONGUSERNAMEORPASSWORD = 2,
        WRONGTOKENID = 3,
        ERRORWITHMESSAGE = 4
    }
}