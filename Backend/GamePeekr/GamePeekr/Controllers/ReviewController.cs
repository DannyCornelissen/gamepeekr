using System.Linq.Expressions;
using GamePeekr.DTOs;
using GamePeekr.Hubs;
using GamePeekrEntities;
using GamepeekrReviewManagement;
using GamepeekrReviewManagement.Classes;
using GamepeekrReviewManagement.Interfaces;
using GamepeekrReviewManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamePeekr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IreviewRepository _ireview;
        private readonly IUserRepository _iuser;
        private readonly ISignalrService _signalrService;

        public ReviewController(IreviewRepository ireview, IUserRepository iuser, ISignalrService iSignalrService)
        {
            _ireview = ireview;
            _iuser = iuser;
            _signalrService = iSignalrService;

        }
        // GET: api/<ReviewController>
        [HttpGet]
        public IActionResult Get()
        {
           
            try
            {
                ReviewService reviewCollection = new ReviewService(_ireview);
                ReviewGetDtoList reviewGetDTOList = new ReviewGetDtoList();
                reviewCollection.GetReviews();

                foreach (Review review in reviewCollection.GetReviews())
                {
                    ReviewGetDto reviewDTO = new ReviewGetDto(review);
                    reviewGetDTOList.ReviewGetDTOs.Add(reviewDTO);
                }

                return Ok(reviewGetDTOList.ReviewGetDTOs);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error: An unexpected error occurred.");
            }


        }
    

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {

            try
            {
                ReviewService reviewService = new ReviewService(_ireview);
                Review reviewById = reviewService.GetReviewById(id);
                ReviewGetByIdDto reviewGetByIdDTO = new ReviewGetByIdDto(reviewById);
                return Ok(reviewGetByIdDTO);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error: An unexpected error occurred.");
            }
        }

        //POST api/<ReviewController>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReviewPostDto review)
        {
            UserService userService = new UserService(_iuser);
            ReviewService reviewService = new ReviewService(_ireview);
            User user = userService.GetUserById(review.UserId);


            Review newReview = new Review(review.Title, review.ReviewText, review.Rating, review.Game, user);
            ReviewCheckEnum.ReviewCheck check = newReview.checkReviewContent();
            if (check == ReviewCheckEnum.ReviewCheck.CorrectTitleAndReviewText)
            {
                reviewService.AddReview(newReview);
                await _signalrService.SendMessageToAllClients("a new review has been created with title: " + newReview.Title + " posted by: " + newReview.Reviewer.UserName + " on " + DateTime.Now);
                return Ok();
            }
            return StatusCode(400, check);
        }

    }
}
