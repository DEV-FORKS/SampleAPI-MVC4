using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DTO;
using DAL;

namespace RL
{
    public class ReviewRepository
    {
        private ReviewDAO _ReviewDAO = new ReviewDAO();

        public ReviewDto Insert(Review objReview)
        {
            var objReviewDto = _ReviewDAO.Insert(objReview);
            if (objReviewDto == null)
                return null;
            return objReviewDto.ToDataTransferObject();
        }

        public ReviewDto Update(Review objReview)
        {
            var objReviewDto = _ReviewDAO.Update(objReview);
            if (objReviewDto == null)
                return null;
            return objReviewDto.ToDataTransferObject();
        }
    }
}
