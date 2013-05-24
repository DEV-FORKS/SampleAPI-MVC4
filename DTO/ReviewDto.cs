using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ReviewDto
    {
        public String ReviewID { get; set; }
        public String ActivityID { get; set; }
        public String UserID { get; set; }
        public String Review { get; set; }
        public String ReviewDate { get; set; }
    }
}
