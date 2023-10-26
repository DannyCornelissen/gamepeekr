using GamePeekrEntityLayer;
namespace GamepeekrReviewManagement;


public interface IReview
{
    public List<ReviewEntity> GetReviews();
    public ReviewEntity GetReviewById(Guid id);
}