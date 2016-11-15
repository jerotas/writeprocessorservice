using System;
using System.Configuration;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using SharedModels;

namespace TestRestService {
    public class Program {
        private static readonly string RestServiceUrl = ConfigurationManager.AppSettings["RestServiceURL"];

        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args) {
            var getResult = TestGetFromRestService($"{RestServiceUrl}/WriteProcessorService.svc/GetData/2");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[Get] Result: " + getResult);
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            var postResult = TestPostWithRestService($"{RestServiceUrl}/WriteProcessorService.svc/PostMemberChange", 
                new Member {
                    FirstName = "First",
                    MiddleInitial = "M",
                    LastName = "Last",
                    Gender = "F",
                    GroupSourceKey = 123,
                    MemberSourceKey = 456
                });

            Console.WriteLine("[Post] Result: " + postResult);
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done, press any key to exit.");
            Console.ResetColor();

            Console.ReadKey();
        }

        private static string TestPostWithRestService(string restPostUrl, object dataToPost) {
            var jsonData = JsonConvert.SerializeObject(dataToPost);

            //POST JSON REQUEST TO API
            using (var client = new WebClient()) {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                var result = client.UploadString(restPostUrl, "POST", jsonData);
                return "Post Success: " + result;
            }
        }

        private static string TestGetFromRestService(string restGetUrlWithParams) {
            var webrequest = (HttpWebRequest)WebRequest.Create(restGetUrlWithParams);

            using (var response = webrequest.GetResponse()) {
                // ReSharper disable once AssignNullToNotNullAttribute
                using (var reader = new StreamReader(response.GetResponseStream())) {
                    var result = reader.ReadToEnd();

                    return result;
                }
            }
        }
    }
}
