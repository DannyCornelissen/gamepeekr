using GamePeekr.DTOs;
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
        public IEnumerable<ReviewGetDTO> Get()
        {
            ReviewCollection reviewCollection = new ReviewCollection(_ireview);
            ReviewGetDTOList reviewGetDTOList = new ReviewGetDTOList();
            reviewCollection.GetReviews();

            foreach (Review review in reviewCollection.Reviews)
            {
               ReviewGetDTO reviewDTO = new ReviewGetDTO(review);
               reviewGetDTOList.ReviewGetDTOs.Add(reviewDTO);
            }

            return reviewGetDTOList.ReviewGetDTOs;

        }
    

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public ReviewGetByIdDTO Get(Guid id)
        {
            Review review = new Review(_ireview);
            review.GetReviewById(id);
            ReviewGetByIdDTO reviewGetByIdDTO = new ReviewGetByIdDTO(review);
            return reviewGetByIdDTO;
        }

        // POST api/<ReviewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
