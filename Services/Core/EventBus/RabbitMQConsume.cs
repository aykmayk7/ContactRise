using EventBus.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{
    public class RabbitMQConsume : IRabbitMQConsume
    {
        public async Task<string> ConsumeMessage()
        {
            string message = string.Empty;
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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    message = Encoding.UTF8.GetString(body);

                };
                channel.BasicConsume(queue: EventBusConstants.ReportQueue,
                                     autoAck: true,
                                     consumer: consumer);

                return message;
            }        
        }
    }
}
