using System.Linq.Expressions;
using GamePeekr.DTOs;
using GamePeekrEntityLayer;
using GamepeekrReviewManagement;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamePeekr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReview _ireview;
        public ReviewController(IReview ireview)
        {
            _ireview = ireview;
        }
        // GET: api/<ReviewController>
        [HttpGet]
        public IActionResult Get()
        {
           
            try
            {
                ReviewCollection reviewCollection = new ReviewCollection(_ireview);
                ReviewGetDTOList reviewGetDTOList = new ReviewGetDTOList();
                reviewCollection.GetReviews();

                foreach (Review review in reviewCollection.Reviews)
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
                Review review = new Review(_ireview);
                review.GetReviewById(id);
                ReviewGetByIdDTO reviewGetByIdDTO = new ReviewGetByIdDTO(review);
                return Ok(reviewGetByIdDTO);
            }
            catch
            {
                return StatusCode(500, "Internal Server Error: An unexpected error occurred.");
            }
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] ReviewPostDTO review)
        {
           // try
          //  {
                Review newReview = new Review(review.Title, review.ReviewText, review.Rating, review.Game, _ireview);
                ReviewCheckEnum.ReviewCheck check = newReview.checkReviewContent();
                if (check == ReviewCheckEnum.ReviewCheck.CorrectTitleAndReviewText)
                {
                    newReview.AddReview();
                    return Ok();
                }
                return StatusCode(400, check);
          //  }
          //  catch (Exception e)
          //  {
          //      return StatusCode(500, "Internal Server Error: An unexpected error occurred.");
         //   }

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
