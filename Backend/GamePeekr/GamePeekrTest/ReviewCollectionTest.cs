using GamepeekrReviewManagement;
using Moq;

namespace GamePeekrTest
{
    [TestClass]
    public class ReviewCollectionTest
    {
        [TestMethod]
        public void OrderReviews_WhenGivenUnorderedReviewList_ReturnsOrderedByLikes()
        {
            // Arrange
            IReview mockReview = new Mock<IReview>().Object;
            ReviewCollection reviewCollection = new ReviewCollection(mockReview);
            List<Review> reviewList = new List<Review>();

            Review review1 = new Review(mockReview);
            review1.Likes = 10;
            reviewList.Add(review1);

            Review review2 = new Review(mockReview);
            review2.Likes = 80;
            reviewList.Add(review2);

            Review review3 = new Review(mockReview);
            review3.Likes = 5;
            reviewList.Add(review3);


            // Act
            reviewList = reviewCollection.OrderReviews(reviewList);

            
            // Assert
            Assert.AreEqual(reviewList[0].Likes, 80);
            Assert.AreEqual(reviewList[1].Likes, 10);
            Assert.AreEqual(reviewList[2].Likes, 5);
        }
    }
}