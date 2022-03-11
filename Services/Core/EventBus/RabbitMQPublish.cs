using EventBus.Interfaces;
using Microsoft.Extensions.Configuration;
using RabbitMQ.Client;
using System;
using System.Text;
using System.Threading.Tasks;

namespace EventBus
{
    public class RabbitMQPublish<T> : IRabbitMQPublish<T>
    {
        private IConfiguration _configuration;

        public RabbitMQPublish(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMessage(T Model)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration.GetSection("EventBus:HostName").Value,
                Port = Protocols.DefaultProtocol.DefaultPort,
                UserName = _configuration.GetSection("EventBus:UserName").Value,
                Password = _configuration.GetSection("EventBus:Password").Value,
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
