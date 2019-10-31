using consumer.Memory;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace rabbitConsumer.Controllers
{
    public class UpdateReceiver
    {
        public UpdateReceiver()
        {
            System.Threading.Thread.Sleep(30000);
            //so the rabbit server starts up and we'll have something to connect to
            //TODO: write a healthcheck of the rabbitMQ in the .yaml instead

            var factory = new ConnectionFactory() { HostName = "rabbit" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "news_from_the_producer",
                                                  durable: true,
                                                  exclusive: false,
                                                  autoDelete: false,
                                                  arguments: null); 
             // idempotent - repeating it is not a problem

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
