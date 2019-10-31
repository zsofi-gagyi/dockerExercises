using consumer.Memory;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rabbitConsumer.Controllers
{
    public static class UpdateReceiver
    {

        public static async Task ReceiveUpdates()
        {
            var factory = new ConnectionFactory() { HostName = "rabbit" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "news_from_the_producer",
                                                  durable: false,
                                                  exclusive: false,
                                                  autoDelete: false,
                                                  arguments: null); // idempotent - repeating it is not a problem

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body;
                        var receivedMessage = Encoding.UTF8.GetString(body);
                        NewsConsume(JObject.Parse(receivedMessage));
                    };
                    channel.BasicConsume(queue: "news_from_the_producer",
                                         autoAck: true,
                                         consumer: consumer);
                }
            }
        }

        private static void NewsConsume(JObject newsObject)
        {
            var dateTime = newsObject["Time"].Value<DateTime>();
            var latestNews = new string[]
                {
                    dateTime.ToLongDateString() + ", " + dateTime.ToLongTimeString(),
                    newsObject["VisitorNr"].Value<int>().ToString()
                };
            NewsStore.news.AddFirst(latestNews);
        }
    }
}
