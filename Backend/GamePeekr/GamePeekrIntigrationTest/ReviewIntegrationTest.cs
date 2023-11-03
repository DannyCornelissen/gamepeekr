

using System.Net.Http.Json;
using System.Text;
using GamePeekr.DTOs;
using GamePeekrEntityLayer;
using GamePeekrIntigrationTest.ReviewJsonSerialiseDeserialiseObjects;
using GamePeekrReviewManagementDAL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GamePeekrIntigrationTest
{
    [TestClass]
    public class ReviewIntegrationTest
    {

        private HttpClient _client;
        private GamePeekrDBContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new GamePeekrWebHostFactory();
            _client = factory.CreateClient();
            var options = new DbContextOptionsBuilder<GamePeekrDBContext>();
            options.UseSqlServer("Server=localhost,1433;Database=TestGamePeekrDB; TrustServerCertificate=True; User Id=sa;Password=Butterfly@1;");
            GamePeekrDBContext context = new GamePeekrDBContext(options.Options);
            context.Database.Migrate();
            context.Database.EnsureCreated();
            _context = context;
        }

        [TestCleanup]
        public void Cleanup()
        {
            _context.Database.EnsureDeleted();
        }

        [TestMethod]
        public async Task ShouldRetrieveAllReviewsFromApi()
        {
            //arrange
            DatabaseSeeder.Seed(_context);
       
            //act
            var response = await _client.GetAsync("/api/Review");
            var jsonString = await response.Content.ReadAsStringAsync();
            
            //assert
            response.EnsureSuccessStatusCode();

            //act
            List<SimpleReviewDeserialiseObject> review = JsonConvert.DeserializeObject<List<SimpleReviewDeserialiseObject>>(jsonString);

            // Assert 
            Assert.AreEqual(3, review.Count);
            Assert.AreEqual("Elden Ring", review[0].game);
            Assert.AreEqual("Great game!", review[0].title);
            Assert.AreEqual(10, review[0].likes);
            Assert.AreEqual(5, review[0].rating);
        }

        [TestMethod]
        public async Task ShouldRetrieveReviewByIdFromApi()
        {
            //arrange
            _context.Database.EnsureDeleted();

            _context.Database.Migrate();
            _context.Database.EnsureCreated();
            DatabaseSeeder.Seed(_context);

            //act
            var response = await _client.GetAsync("/api/Review/ea43abec-eb2e-471f-b3e2-9195e710a753");
            var jsonString = await response.Content.ReadAsStringAsync();

            //assert
            response.EnsureSuccessStatusCode();

            //act
            DetailReviewDeserialiseObject review = JsonConvert.DeserializeObject<DetailReviewDeserialiseObject>(jsonString);

            // Assert 
            Assert.AreEqual("Elden Ring", review.game);
            Assert.AreEqual("Great game!", review.title);
            Assert.AreEqual(10, review.likes);
            Assert.AreEqual(5, review.rating);
        }


        [TestMethod]
        public async Task ShouldPostToApi()
        {
            //arrange
            _context.Database.EnsureDeleted();

            _context.Database.Migrate();
            _context.Database.EnsureCreated();
            var reviewData = new DetailReviewDeserialiseObject()
            {
                title = "inserted title",
                reviewText = "inserted reviewtext",
                rating = 0,
                game = "string"
            };
            string jsonContent = JsonConvert.SerializeObject(reviewData);
            HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            //act

            var response = await _client.PostAsync("/api/Review/", content);
            List<ReviewEntity> reviews = _context.Review.ToList();


            //assert
            response.EnsureSuccessStatusCode();

            Assert.AreEqual(1, reviews.Count);
            Assert.AreEqual(reviewData.title, reviews[0].Title);
            Assert.AreEqual(reviewData.reviewText, reviews[0].ReviewText);
        }
    }
}