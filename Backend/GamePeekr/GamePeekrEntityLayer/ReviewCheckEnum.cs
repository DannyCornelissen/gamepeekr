using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePeekrEntityLayer
{
    public class ReviewCheckEnum
    {
        public enum ReviewCheck
        {
           BadTitle = 1,
           BadReviewText = 2,
           BadTitleAndReviewText = 3,
           CorrectTitleAndReviewText = 4
        }
    }
}
