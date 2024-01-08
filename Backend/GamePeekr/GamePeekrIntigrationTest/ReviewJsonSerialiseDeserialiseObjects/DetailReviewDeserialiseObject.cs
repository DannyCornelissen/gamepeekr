using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamePeekrIntigrationTest.ReviewJsonSerialiseDeserialiseObjects
{
    internal class DetailReviewDeserialiseObject
    {
        public string title { get; set; }
        public int rating { get; set; }
        public string game { get; set; }
        public int likes { get; set; }
        public string reviewText { get; set; }
        public string userId { get; set; }
    }
}
