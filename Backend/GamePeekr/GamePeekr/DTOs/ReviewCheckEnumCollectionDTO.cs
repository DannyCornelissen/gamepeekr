

namespace GamePeekr.DTOs
{
    public class ReviewCheckEnumCollectionDto
    {
        public List<ReviewCheckEnumDto> ReviewCheckEnums { get; set; }

        public ReviewCheckEnumCollectionDto()
        {
            ReviewCheckEnums = new List<ReviewCheckEnumDto>();
        }
    }
}
