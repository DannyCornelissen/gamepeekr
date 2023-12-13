using GamePeekr.DTOs;
using GamePeekrEntities;
using GamepeekrReviewManagement.Helpers;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamePeekr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewStatusEnumController : ControllerBase
    {
        // GET: api/<ReviewStatusEnumController>
        [HttpGet]
        public IEnumerable<ReviewCheckEnumDto> Get()
        {
            ReviewCheckEnumCollectionDto reviewCheckEnumCollectionDto = new ReviewCheckEnumCollectionDto();
            foreach (string status in EnumHelper.EnumToList<ReviewCheckEnum.ReviewCheck>())
            {
                ReviewCheckEnumDto reviewCheckStatusEnum = new ReviewCheckEnumDto();
                reviewCheckStatusEnum.Name = status;
                reviewCheckStatusEnum.id = EnumHelper.EnumParse<ReviewCheckEnum.ReviewCheck>(status);
                reviewCheckEnumCollectionDto.ReviewCheckEnums.Add(reviewCheckStatusEnum);

            }
            return reviewCheckEnumCollectionDto.ReviewCheckEnums;
        }

        // GET api/<ReviewStatusEnumController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return EnumHelper.EnumToString<ReviewCheckEnum.ReviewCheck>(id);
        }
    }
}
