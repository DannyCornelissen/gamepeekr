﻿using GamepeekrReviewManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GamePeekrEntityLayer;

[assembly: InternalsVisibleTo("GamePeekrTest")]
namespace GamepeekrReviewManagement
{
    public class ReviewCollection
    {
        private readonly IReview _ireview;
        private List<Review> _reviews;
        public IEnumerable<Review> Reviews { get;}

        public ReviewCollection(IReview ireview)
        {
            _ireview = ireview;
            _reviews = new List<Review>();
            Reviews = _reviews;
        }

        public void GetReviews()
        {
            List<ReviewEntity> reviewEntityList = _ireview.GetReviews().OrderByDescending(r => r.Likes).ToList(); 
            List<Review> reviewList = new List<Review>();
            foreach (ReviewEntity review in reviewEntityList)
            {
                Review newReview = new Review(review);
                reviewList.Add(newReview);
            }
            _reviews.AddRange(OrderReviews(reviewList));

        }

        internal List<Review> OrderReviews(List<Review> reviewList)
        {
            List<Review> reviews = reviewList.OrderByDescending(r => r.Likes).ToList();

            return reviews;
        }
    }
}
