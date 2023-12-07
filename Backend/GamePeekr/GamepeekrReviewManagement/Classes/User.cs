using GamePeekrEntities;

namespace GamepeekrReviewManagement.Classes
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public List<Review>? Reviews { get; set; }

        public User(string id, string userName)
        {
            Id = id;
            Reviews = new List<Review>();
            UserName = userName;
        }

        public User(UserEntity user)
        {
            Id = user.Id; 
            UserName = user.UserName;
        }

        public UserEntity toUserEntity()
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Id = Id;
            userEntity.UserName = UserName;
            return userEntity;
        }
    }
}
