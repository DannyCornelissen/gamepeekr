

using System.Reflection;
using GamePeekrEntityLayer;

namespace GamepeekrReviewManagement
{
    public class Review
    {

        private readonly IReview _ireview;
        private bool _checkCompletion = false;
        private const int MAX_TITLE_LENGTH = 500;
        private const int MAX_REVIEW_LENGTH = 4000;

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public string Game { get; set; }
        public bool Flagged { get; set; }
        public int Likes { get; set; }


        internal Review(ReviewEntity reviewEntity)
        {
            toReview(reviewEntity);
        }

        public Review(IReview ireview)
        {
           _ireview = ireview;
        }

        public Review(string title, string reviewText, int rating, string game, IReview ireview)
        {
            Id = Guid.NewGuid();
            Title = title;
            ReviewText = reviewText;
            Rating = rating;
            Game = game;
            _ireview = ireview;
        }

        private void toReview(ReviewEntity reviewEntity)
        {
            Id = reviewEntity.Id;
            Title = reviewEntity.Title;
            ReviewText = reviewEntity.ReviewText;
            Rating = reviewEntity.Rating;
            Game = reviewEntity.Game;
            Flagged = reviewEntity.Flagged;
            Likes = reviewEntity.Likes;
        }

        private ReviewEntity toReviewEntity()
        {
            ReviewEntity reviewEntity = new ReviewEntity();
            reviewEntity.Id = Id;
            reviewEntity.Title = Title;
            reviewEntity.ReviewText = ReviewText;
            reviewEntity.Rating = Rating;
            reviewEntity.Game = Game;
            reviewEntity.Likes = Likes;
            return reviewEntity;
        }



        public void GetReviewById(Guid id)
        {
           toReview(_ireview.GetReviewById(id));
        }

        public void AddReview()
        {
            if (_checkCompletion)
            { 
                ReviewEntity reviewEntity = toReviewEntity();
                _ireview.AddReview(reviewEntity);
            }
        }

        public ReviewCheckEnum.ReviewCheck checkReviewContent()
        {
            if (ReviewText.Length > MAX_REVIEW_LENGTH && Title.Length > MAX_TITLE_LENGTH)
            {
                return ReviewCheckEnum.ReviewCheck.BadTitleAndReviewText;
            }
            if (ReviewText.Length > MAX_REVIEW_LENGTH && Title.Length <= MAX_TITLE_LENGTH)
            {
                return ReviewCheckEnum.ReviewCheck.BadReviewText;
            }
            if (ReviewText.Length <= MAX_REVIEW_LENGTH && Title.Length > MAX_TITLE_LENGTH)
            {
                return ReviewCheckEnum.ReviewCheck.BadTitle;
            }
            _checkCompletion = true;
            return ReviewCheckEnum.ReviewCheck.CorrectTitleAndReviewText;
        }
    }
}