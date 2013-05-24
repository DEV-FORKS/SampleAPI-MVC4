using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserActivityListDto
    {
        public String UserActivityListID { get; set; }
        public String UserID { get; set; }
        public String ActivityListID { get; set; }
        public String Date { get; set; }
        public String Status { get; set; }
    }
}
