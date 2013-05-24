using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class AccessTokenDto
    {
        public String Token { get; set; }
        public String UserID { get; set; }
        public String ClientType { get; set; }
    }
}
