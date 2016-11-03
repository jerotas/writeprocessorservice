using System;
using System.IO;
using System.Net;

namespace TestRestService {
    public class Program {
        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args) {
            var result = RetrieveStringFromRestService("http://writeprocessorservice.azurewebsites.net/WriteProcessorService.svc/GetData/2");
            Console.WriteLine("Result: " + result);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done, press any key to exit.");
            Console.ResetColor();

            Console.ReadKey();
        }

        private static string RetrieveStringFromRestService(string restUrlWithParams) {
            var webrequest = (HttpWebRequest)WebRequest.Create(restUrlWithParams);

            using (var response = webrequest.GetResponse()) {
                // ReSharper disable once AssignNullToNotNullAttribute
                using (var reader = new StreamReader(response.GetResponseStream())) {
                    var result = reader.ReadToEnd();

                    return result;
                    //var deser = JsonConvert.DeserializeObject<T>(result);
                    //return deser;
                }
            }
        }

    }
}
