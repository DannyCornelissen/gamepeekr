using System.Reflection;
using GamePeekrEntities;

namespace GamepeekrReviewManagement.Classes
{
    public class Review
    {

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
        public User Reviewer { get; set; }


        public Review(string title, string reviewText, int rating, string game, User reviewer)
        {
            Id = Guid.NewGuid();
            Title = title;
            ReviewText = reviewText;
            Rating = rating;
            Game = game;
            Reviewer = reviewer;
        }

        public Review(ReviewEntity reviewEntity)
        {
            Id = reviewEntity.Id;
            Title = reviewEntity.Title;
            ReviewText = reviewEntity.ReviewText;
            Rating = reviewEntity.Rating;
            Game = reviewEntity.Game;
            Flagged = reviewEntity.Flagged;
            Likes = reviewEntity.Likes;
        }

        public ReviewEntity toReviewEntity()
        {
            ReviewEntity reviewEntity = new ReviewEntity();
            reviewEntity.Id = Id;
            reviewEntity.Title = Title;
            reviewEntity.ReviewText = ReviewText;
            reviewEntity.Rating = Rating;
            reviewEntity.Game = Game;
            reviewEntity.Likes = Likes;
            reviewEntity.userId = Reviewer.Id;
            return reviewEntity;
        }


        public bool GetCheckCompletion()
        {
            return _checkCompletion;
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