using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bucket.Models
{
    public class User
    {
        public String UserID { get; set; }
        public String Email { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public String NickName { get; set; }
        public String Password { get; set; }
        public String DateOfBirth { get; set; }
        public String Zipcode { get; set; }
    }
}