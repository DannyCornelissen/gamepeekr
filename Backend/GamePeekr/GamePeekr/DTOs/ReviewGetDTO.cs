using GamepeekrReviewManagement.Classes;

namespace GamePeekr.DTOs
{
    public class ReviewGetDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public string Game { get; set; }
        public int Likes { get; set; }

        public ReviewGetDto(Review review)
        {
            Id = review.Id;
            Title = review.Title;
            Rating = review.Rating;
            Game = review.Game;
            Likes = review.Likes;
        }

    }
}
