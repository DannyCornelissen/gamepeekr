using System.Runtime.CompilerServices;
using GamePeekrEntities;
using GamepeekrReviewManagement.Classes;
using GamepeekrReviewManagement.Interfaces;

[assembly: InternalsVisibleTo("GamePeekrTest")]
namespace GamepeekrReviewManagement.Services
{
    public class ReviewService
    {
        private readonly IreviewRepository _ireview;

        public ReviewService(IreviewRepository reviewRepository)
        {
            _ireview = reviewRepository;
        }
        
        public Review GetReviewById(Guid id)
        {
            Review review = new Review(_ireview.GetReviewById(id));
            return review;
        }

        public IEnumerable<Review> GetReviews()
        {
            List<ReviewEntity> reviewEntityList = _ireview.GetReviews();

            List<Review> reviewList = new List<Review>();
            foreach (ReviewEntity review in reviewEntityList)
            {
                Review newReview = new Review(review);
                reviewList.Add(newReview);
            }
            reviewList = OrderReviews(reviewList);
            return reviewList;
        }

        internal List<Review> OrderReviews(List<Review> reviewList)
        {
            List<Review> reviews = reviewList.OrderByDescending(r => r.Likes).ToList();

            return reviews;
        }

        public void AddReview(Review review)
        {
            if (review.GetCheckCompletion())
            {
                ReviewEntity reviewEntity = review.toReviewEntity();
                _ireview.AddReview(reviewEntity);
            }
        }
    }
}
