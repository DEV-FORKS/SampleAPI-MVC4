using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ReviewDAO : BaseDAO
    {
        public Review Insert(Review objReview)
        {
            _Database.Reviews.Add(objReview);
            _Database.SaveChanges();

            return objReview;
        }

        public Review Update(Review objReview)
        {
            var thisReview = _Database.Reviews.Where(objR => objR.ReviewId == objReview.ReviewId);

            if (thisReview.Count() == 0)
                return null;
            else
            {
                ((Review)thisReview).Review1 = objReview.Review1;
                _Database.SaveChanges();
                return (Review)thisReview;
            }
        }
    }
}
