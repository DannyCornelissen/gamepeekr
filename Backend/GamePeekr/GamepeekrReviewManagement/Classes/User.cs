using GamePeekrEntities;

namespace GamepeekrReviewManagement.Classes
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid ApiKey { get; set; }
        public string UserName { get; set; }
        public List<Review>? Reviews { get; set; }

        public User(Guid id, Guid apiKey, string userName)
        {
            Id = id;
            ApiKey = apiKey;
            Reviews = new List<Review>();
            UserName = userName;
        }

        public User(UserEntity user)
        {
            Id = user.Id;
            ApiKey = user.ApiKey;
            UserName = user.UserName;
        }

        public UserEntity toUserEntity()
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Id = Id;
            userEntity.ApiKey = ApiKey;
            userEntity.UserName = UserName;
            return userEntity;
        }
    }
}
