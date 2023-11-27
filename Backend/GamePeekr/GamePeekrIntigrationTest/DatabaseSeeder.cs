using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GamePeekrEntities;
using GamePeekrReviewManagementDAL;
using Microsoft.EntityFrameworkCore;

namespace GamePeekrIntigrationTest
{
    internal static class DatabaseSeeder
    {
        internal static void Seed(GamePeekrDBContext context)
        {
            var user = CreateUserEntity(context);
            // Create a few reviews
            var reviews = new List<ReviewEntity>()
            {

                new ReviewEntity()
                {
                    Id = new Guid("277975b3-d741-40d4-8803-95dda0c9e3c7"),
                    Title = "Mixed feelings",
                    ReviewText = "This game has some good ideas, but it's not fully realized. It's also a bit too difficult.",
                    Rating = 3,
                    Game = "Horizon Forbidden West",
                    Flagged = false,
                    Likes = 7,
                    userId =  user.Id,
                    User = user
                },

                new ReviewEntity()
                {
                    Id = new Guid("8d6931b3-ffd3-42ba-9cca-340fbbf2ced7"),
                    Title = "Disappointing",
                    ReviewText = "This game is not what I was expecting. It's buggy and the graphics are outdated.",
                    Rating = 2,
                    Game = "Call of Duty: Vanguard",
                    Flagged = false,
                    Likes = 5,
                    userId =  user.Id,
                    User = user
                },

                new ReviewEntity()
                {
                    Id = new Guid("ea43abec-eb2e-471f-b3e2-9195e710a753"),
                    Title = "Great game!",
                    ReviewText = "This game is a lot of fun. It's well-made and the gameplay is addicting.",
                    Rating = 5,
                    Game = "Elden Ring",
                    Flagged = false,
                    Likes = 10,
                    userId = user.Id,
                    User = user
                }

            };

            // Add the reviews to the database
            context.Review.AddRange(reviews);
            context.SaveChanges();
        }

        internal static UserEntity CreateUserEntity(GamePeekrDBContext context)
        {
            var user = new UserEntity()
            {
                Id = new Guid("9ada92a5-594d-4fc6-a0f9-24d240c3ba84"),
                ApiKey = new Guid("99e715ed-5ce8-451c-a7b2-4a59cc2c33e0"),
                UserName = "TestUser"
            };
            context.User.Add(user);
            context.SaveChanges();
            return user;
        }
    }
}
