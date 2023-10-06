namespace GamePeekr.DTOs
{
    public class ReviewGetDTOList
    {
       public List<ReviewGetDTO> ReviewGetDTOs { get; set; }

       public ReviewGetDTOList()
       {
           ReviewGetDTOs = new List<ReviewGetDTO>();
       }
    }
}
