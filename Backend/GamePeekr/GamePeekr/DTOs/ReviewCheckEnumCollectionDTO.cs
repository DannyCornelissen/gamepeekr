

namespace GamePeekr.DTOs
{
    public class ReviewCheckEnumCollectionDTO
    {
        public List<ReviewCheckEnumDTO> ReviewCheckEnums { get; set; }

        public ReviewCheckEnumCollectionDTO()
        {
            ReviewCheckEnums = new List<ReviewCheckEnumDTO>();
        }
    }
}
