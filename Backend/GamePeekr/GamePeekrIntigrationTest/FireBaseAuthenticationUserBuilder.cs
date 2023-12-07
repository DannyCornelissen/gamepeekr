using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;

namespace GamePeekrIntigrationTest
{
    internal static class FireBaseAuthenticationUserBuilder
    {
        private static readonly string apiKey  = Environment.GetEnvironmentVariable("FIREBASE_API_KEY");
        private static readonly string keyPath = Environment.GetEnvironmentVariable("FIREBASE_KEY_PATH");
        private static readonly string keyJson = Environment.GetEnvironmentVariable("FIREBASE_ADMIN_CREDENTIALS");
        private static void CreateFirebaseApp()
        {
            if (keyPath != null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromFile(keyPath),
                });
            }
            else if (keyJson != null)
            {
                FirebaseApp.Create(new AppOptions
                {
                    Credential = GoogleCredential.FromJson(keyJson),
                });
                Console.WriteLine("keyJson: "+ keyJson );
            }
        }

        internal static async Task<string> Auth()
        {
            CreateFirebaseApp();

            var userRecordArgs = new UserRecordArgs
            {
                Email = "user@example.com",
                Password = "password",
            };
            var createdUser = await FirebaseAuth.DefaultInstance.CreateUserAsync(userRecordArgs);

            string User = await SignInAsync(userRecordArgs);
            dynamic jsonObject = JsonConvert.DeserializeObject(User);
            await FirebaseAuth.DefaultInstance.DeleteUserAsync(createdUser.Uid);
            return jsonObject.idToken;
        }

        private static async Task<string> SignInAsync(UserRecordArgs userRecordArgs)
        {
          
            string signInEndpoint = "https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key=" + apiKey;

            var signInData = new
            {
               email = userRecordArgs.Email,
               password = userRecordArgs.Password,
                returnSecureToken = true
            };

            using (HttpClient client = new HttpClient())
            {

                string jsonSignInData = Newtonsoft.Json.JsonConvert.SerializeObject(signInData);


                var content = new StringContent(jsonSignInData, Encoding.UTF8, "application/json");


                HttpResponseMessage response = await client.PostAsync(signInEndpoint, content);

                if (response.IsSuccessStatusCode)
                {

                    string responseBody = await response.Content.ReadAsStringAsync();
                    return responseBody;
                }
                else
                {

                    string errorBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Error signing in: " + errorBody);
                    throw new Exception("Error signing in: " + errorBody);
                }
            }
        }
    }
}
