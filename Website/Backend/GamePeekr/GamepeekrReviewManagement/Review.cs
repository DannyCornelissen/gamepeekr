

namespace GamepeekrReviewManagement
{
    public class Review
    {

        private readonly IReview _ireview;

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public string Game { get; set; }
        public bool Flagged { get; set; }
        public int Likes { get; set; }


        public Review(IReviewEntity reviewEntity)
        {
            toReview(reviewEntity);
        }

        public Review(IReview ireview)
        {
           _ireview = ireview;
        }

        private void toReview(IReviewEntity reviewEntity)
        {
            Id = reviewEntity.Id;
            Title = reviewEntity.Title;
            ReviewText = reviewEntity.ReviewText;
            Rating = reviewEntity.Rating;
            Game = reviewEntity.Game;
            Flagged = reviewEntity.Flagged;
            Likes = reviewEntity.Likes;
        }

  

        public void GetReviewById(Guid id)
        {
           toReview(_ireview.GetReviewById(id));
        }

    }
}