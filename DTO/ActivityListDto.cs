using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ActivityListDto
    {
        public String ActivityListId { get; set; }
        public String Name { get; set; }
        public String DateCreated { get; set; }
        public String CreatedBy { get; set; }
        public String NumOfUsers { get; set; }
        public String NumOfActivity { get; set; }
    }
}
