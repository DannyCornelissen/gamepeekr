using GamepeekrReviewManagement.Classes;
using GamepeekrReviewManagement.Interfaces;
using GamepeekrReviewManagement.Services;
using Moq;

namespace GamePeekrTest
{
    [TestClass]
    public class ReviewServiceTest
    {
        [TestMethod]
        public void OrderReviews_WhenGivenUnorderedReviewList_ReturnsOrderedByLikes()
        {
            //Arrange
            IreviewRepository mockReview = new Mock<IreviewRepository>().Object;
            User mockUser = new Mock<User>(Guid.NewGuid(), Guid.NewGuid(), "username").Object;
            ReviewService reviewService = new ReviewService(mockReview);
            List<Review> reviewList = new List<Review>();

            Review review1 = new Review("title","text",2,"game" ,mockUser);
            review1.Likes = 10;
            reviewList.Add(review1);

            Review review2 = new Review("title", "text", 2, "game", mockUser);
            review2.Likes = 80;
            reviewList.Add(review2);

            Review review3 = new Review("title", "text", 2, "game", mockUser);
            review3.Likes = 5;
            reviewList.Add(review3);


            // Act
            reviewList = reviewService.OrderReviews(reviewList);


            // Assert
            Assert.AreEqual(reviewList[0].Likes, 80);
            Assert.AreEqual(reviewList[1].Likes, 10);
            Assert.AreEqual(reviewList[2].Likes, 5);
        }
    }
}