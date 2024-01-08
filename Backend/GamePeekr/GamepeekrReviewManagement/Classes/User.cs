using GamePeekrEntities;

namespace GamepeekrReviewManagement.Classes
{
    public class User
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public UserRoles Role { get; set; }
        public List<Review>? Reviews { get; set; }

        public User(string id, string userName)
        {
            Id = id;
            Reviews = new List<Review>();
            UserName = userName;
            Role = new UserRoles();
            Role = UserRoles.Reviewer;
        }

        public User(UserEntity user)
        {
            Id = user.Id;
            UserName = user.UserName;
            Role = (UserRoles)user.RoleValue;
        }

        public UserEntity toUserEntity()
        {
            UserEntity userEntity = new UserEntity();
            userEntity.Id = Id;
            userEntity.UserName = UserName;
            userEntity.RoleValue = (int)Role;
            return userEntity;
        }
    }
}
