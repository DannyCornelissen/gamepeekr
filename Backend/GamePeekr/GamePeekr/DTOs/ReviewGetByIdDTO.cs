using GamepeekrReviewManagement.Classes;

namespace GamePeekr.DTOs
{
    public class ReviewGetByIdDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public string Game { get; set; }
        public int Likes { get; set; }

        public ReviewGetByIdDto(Review review)
        {
            Id = review.Id;
            Title = review.Title;
            ReviewText = review.ReviewText;
            Rating = review.Rating;
            Game = review.Game;
            Likes = review.Likes;
        }
    }
}
