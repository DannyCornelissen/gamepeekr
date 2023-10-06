namespace GamepeekrReviewManagement;


public interface IReview
{
    public List<IReviewEntity> GetReviews();
    public IReviewEntity GetReviewById(Guid id);
}