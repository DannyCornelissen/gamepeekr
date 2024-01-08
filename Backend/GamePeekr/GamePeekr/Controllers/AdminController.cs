using GamepeekrReviewManagement.Interfaces;
using GamepeekrReviewManagement.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamePeekr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        private readonly IUserRepository _iuser;

        public AdminController(IUserRepository iuser)
        {
            _iuser = iuser;
        }

        // POST api/<AdminController>
        [HttpPost]
        public void Post([FromBody] string id)
        {
            UserService userService = new UserService(_iuser);
            userService.ElevateReviewerToAdmin(id);
        }


    }
}
