using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamepeekrReviewManagement.Classes;
using GamepeekrReviewManagement.Interfaces;

namespace GamepeekrReviewManagement.Services
{
    public class UserService
    {
        private readonly IUserRepository _iuser;

        public UserService(IUserRepository userRepository)
        {
            _iuser = userRepository;
        }

        public User GetUserById(string id)
        {
          return new User(_iuser.GetUserById(id));
        }

        public void AddUserIfNotExists(User user)
        {
            _iuser.AddUserIfNotExists(user.toUserEntity());
        }
    }
}
