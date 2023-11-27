using System.Linq.Expressions;
using GamePeekr.DTOs;
using GamePeekrEntities;
using GamepeekrReviewManagement;
using GamepeekrReviewManagement.Classes;
using GamepeekrReviewManagement.Interfaces;
using GamepeekrReviewManagement.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamePeekr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IreviewRepository _ireview;
        private readonly IUserRepository _iuser;
        public ReviewController(IreviewRepository ireview, IUserRepository iuser)
        {
            _ireview = ireview;
            _iuser = iuser;
        }
        // GET: api/<ReviewController>
        [HttpGet]
        public IActionResult Get()
        {
           
            try
            {
                ReviewService reviewCollection = new ReviewService(_ireview);
                ReviewGetDTOList reviewGetDTOList = new ReviewGetDTOList();
                reviewCollection.GetReviews();

                foreach (Review review in reviewCollection.GetReviews())
                {
                    ReviewGetDTO reviewDTO = new ReviewGetDTO(review);
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
                ReviewGetByIdDTO reviewGetByIdDTO = new ReviewGetByIdDTO(reviewById);
                return Ok(reviewGetByIdDTO);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error: An unexpected error occurred.");
            }
        }

        //POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] ReviewPostDTO review)
        {
            UserService userService = new UserService(_iuser);
            ReviewService reviewService = new ReviewService(_ireview);
            User user = userService.GetUserById(review.UserId);


            Review newReview = new Review(review.Title, review.ReviewText, review.Rating, review.Game, user);
            ReviewCheckEnum.ReviewCheck check = newReview.checkReviewContent();
            if (check == ReviewCheckEnum.ReviewCheck.CorrectTitleAndReviewText)
            {
                reviewService.AddReview(newReview);
                return Ok();
            }
            return StatusCode(400, check);
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
