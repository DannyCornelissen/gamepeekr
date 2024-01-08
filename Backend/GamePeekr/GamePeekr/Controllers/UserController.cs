using GamePeekr.DTOs;
using GamepeekrReviewManagement.Classes;
using GamepeekrReviewManagement.Interfaces;
using GamepeekrReviewManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamePeekr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _iuser;

        public UserController(IUserRepository iuser)
        {
            _iuser = iuser;
        }


        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] UserPostDataDto user)
        {
            UserService userService = new UserService(_iuser);
            userService.AddUserIfNotExists(new User(user.Id, user.UserName));
        }
    }
}
