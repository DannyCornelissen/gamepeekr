namespace GamePeekr.DTOs
{
    public class ReviewGetDtoList
    {
       public List<ReviewGetDto> ReviewGetDTOs { get; set; }

       public ReviewGetDtoList()
       {
           ReviewGetDTOs = new List<ReviewGetDto>();
       }
    }
}
