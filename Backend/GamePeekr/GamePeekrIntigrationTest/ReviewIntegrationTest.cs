

using System.Net.Http.Json;
using GamePeekr.DTOs;
using GamePeekrReviewManagementDAL;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GamePeekrIntigrationTest
{
    [TestClass]
    public class ReviewIntegrationTest
    {

        private HttpClient _client;

        [TestInitialize]
        public void TestInitialize()
        {
            var factory = new GamePeekrWebHostFactory();
            _client = factory.CreateClient();
        }


        private GamePeekrDBContext getDbContext()
        {
            var options = new DbContextOptionsBuilder<GamePeekrDBContext>();
            options.UseSqlServer("Server=localhost,1433;Database=TestGamePeekrDB; TrustServerCertificate=True; User Id=sa;Password=Butterfly@1;");
            GamePeekrDBContext context = new GamePeekrDBContext(options.Options);

            return context;
        }

        [TestMethod]
        public async Task ShouldRetrieveAllReviewsFromApi()
        {
            //arrange
            var context = getDbContext();

            context.Database.EnsureDeleted();

            context.Database.Migrate();
            context.Database.EnsureCreated();
            DatabaseSeeder.Seed(context);
       
            //act
            var response = await _client.GetAsync("/api/Review");
            var jsonString = await response.Content.ReadAsStringAsync();
            
            //assert
            response.EnsureSuccessStatusCode();

            //act
            List<ReviewDeserialiseObject> review = JsonConvert.DeserializeObject<List<ReviewDeserialiseObject>>(jsonString);

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
            var context = getDbContext();

            context.Database.EnsureDeleted();

            context.Database.Migrate();
            context.Database.EnsureCreated();
            DatabaseSeeder.Seed(context);

            //act
            var response = await _client.GetAsync("/api/Review/ea43abec-eb2e-471f-b3e2-9195e710a753");
            var jsonString = await response.Content.ReadAsStringAsync();

            //assert
            response.EnsureSuccessStatusCode();

            //act
            ReviewDeserialiseObject review = JsonConvert.DeserializeObject<ReviewDeserialiseObject>(jsonString);

            // Assert 
            Assert.AreEqual("Elden Ring", review.game);
            Assert.AreEqual("Great game!", review.title);
            Assert.AreEqual(10, review.likes);
            Assert.AreEqual(5, review.rating);
        }
    }
}