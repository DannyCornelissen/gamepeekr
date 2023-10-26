using GamepeekrReviewManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePeekrEntityLayer;

namespace GamepeekrReviewManagement
{
    public class ReviewCollection
    {
        private readonly IReview _ireview;
        private List<Review> _reviews;
        public IEnumerable<Review> Reviews { get;}

        public ReviewCollection(IReview ireview)
        {
            _ireview = ireview;
            _reviews = new List<Review>();
            Reviews = _reviews;
        }

        public void GetReviews()
        {
            List<ReviewEntity> reviewEntityList = _ireview.GetReviews().OrderByDescending(r => r.Likes).ToList(); 

            foreach (ReviewEntity review in reviewEntityList)
            {
                Review newReview = new Review(review);
                _reviews.Add(newReview);
            }
        }
    }
}
