using GamePeekrEntities;

namespace GamepeekrReviewManagement.Interfaces;


public interface IreviewRepository
{
    public List<ReviewEntity> GetReviews();
    public ReviewEntity GetReviewById(Guid id);

    public void AddReview(ReviewEntity reviewEntity);
}