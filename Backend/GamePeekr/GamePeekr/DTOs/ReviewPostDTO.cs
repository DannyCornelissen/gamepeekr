namespace GamePeekr.DTOs
{
    public class ReviewPostDto
    {
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public string Game { get; set; }
        public string UserId { get; set; }
    }
}
