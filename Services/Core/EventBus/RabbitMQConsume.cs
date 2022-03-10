using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace EventBus
{
    public class RabbitMQConsume<T>
    {
        public void ConsumeMessage(T Model)
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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    // DOLDUR BURALARI


                    
                };
                channel.BasicConsume(queue: EventBusConstants.ReportQueue,
                                     autoAck: true,
                                     consumer: consumer);         

            }
        }
    }
}
