using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bucket.Models
{
    public class LogOn
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int ClientType { get; set; }
    }

    public enum ClientTypeCode : byte
    {
        WEB = 0,
        IPHONE = 1,
        ANDROID = 2
    }
}