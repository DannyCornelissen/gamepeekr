using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamepeekrReviewManagement;

namespace GamePeekrReviewManagementDAL
{
    public class ReviewEntity : IReviewEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ReviewText { get; set; }
        public int Rating { get; set; }
        public string Game { get; set; }
        public bool Flagged { get; set; }
        public int Likes { get; set; }
    }
}
