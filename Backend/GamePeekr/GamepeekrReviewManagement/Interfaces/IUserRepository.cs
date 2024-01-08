using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePeekrEntities;

namespace GamepeekrReviewManagement.Interfaces
{
    public interface IUserRepository
    {
        public UserEntity GetUserById(string id);

        public void AddUserIfNotExists(UserEntity user);

        public void ElevateReviewerToAdmin(string id, int role);
    }
}
