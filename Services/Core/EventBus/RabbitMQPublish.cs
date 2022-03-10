using RabbitMQ.Client;
using System;
using System.Text;

namespace EventBus
{
    public class RabbitMQPublish<T>
    {
        public void SendMessage(T Model)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                Port = Protocols.DefaultProtocol.DefaultPort,
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/",
                ContinuationTimeout = new TimeSpan(10, 0, 0, 0)
            };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: EventBusConstants.ReportQueue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = Newtonsoft.Json.JsonConvert.SerializeObject(Model); ;
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: EventBusConstants.ReportQueue,
                                     basicProperties: null,
                                     body: body);

            }
        }
    }
}
