using System;
using System.Configuration;
using System.Text;
using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using WriteToWritesEventHub.Models;

namespace WriteToWritesEventHub {
    public class Program {
        private static string WritesHubConnectionString => ConfigurationManager.AppSettings["WritesEventHubConnectionString"];
        private static readonly string WritesHubName = ConfigurationManager.AppSettings["HubName"];

        // ReSharper disable once UnusedParameter.Local
        private static void Main(string[] args) {
            SendMessagesToWriteEventHub();

            Console.ReadKey();
        }

        private static void SendMessagesToWriteEventHub() {
            var eventHubClient = EventHubClient.CreateFromConnectionString(WritesHubConnectionString, WritesHubName);

            var rnd = new Random();

            try {
                var memberMessage = new Member {
                    MemberSourceKey = 311402,
                    FirstName = "FName00015255",
                    MiddleInitial = "I",
                    LastName = "Laster",
                    Gender = "F",
                    GroupSourceKey = rnd.Next(100, 200)
                };

                SendMemberChangeToEventHub(eventHubClient, memberMessage);

                var memberMessage2 = new Member {
                    MemberSourceKey = 360753,
                    FirstName = "FName00016255",
                    MiddleInitial = "S",
                    LastName = "Lastest",
                    Gender = "F",
                    GroupSourceKey = rnd.Next(100, 200)
                };

                SendMemberChangeToEventHub(eventHubClient, memberMessage2);
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} > Exception: {1}", DateTime.Now, ex.Message);
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Done, press any key to exit.");
            Console.ResetColor();

            // ReSharper disable once RedundantAssignment
            eventHubClient = null;
        }

        private static void SendMemberChangeToEventHub(EventHubClient client, object o) {
            var serialized = JsonConvert.SerializeObject(o);

            Console.WriteLine($"{DateTime.Now.ToShortDateString()} Sending Message: {serialized}");
            client.Send(new EventData(Encoding.UTF8.GetBytes(serialized)));
        }
    }
}
