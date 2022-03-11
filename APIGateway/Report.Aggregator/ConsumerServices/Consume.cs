using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Report.Aggregator.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Report.Aggregator.ConsumerServices
{
    public class Consume : IHostedService, IDisposable
    {
        private IConnection _connection;
        private IModel _channel;
        private IMediator _mediatr;
        private IDictionary<string, Type> _binding;
        private IConfiguration _configuration;

        public Consume(IMediator mediator,IConfiguration configuration)
        {
            _mediatr = mediator;
            _configuration = configuration;
            _binding = new Dictionary<string, Type>();
            _binding.Add(typeof(ReportCreate).Name, typeof(ReportCreate));
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
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
            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
            _channel.QueueDeclare(typeof(ReportCreate).Name, true, false, false, null);
        }

        public virtual Task StartAsync(CancellationToken cancellationToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += OnReceived;

            _channel.BasicConsume(typeof(ReportCreate).Name, false, consumer);
            return Task.CompletedTask;
        }

        private void OnReceived(object ch, BasicDeliverEventArgs ea)
        {
            var retryPolicy = Policy
                .Handle<Exception>()
                .RetryAsync(3);

            var fallbackPolicy = Policy
                .Handle<Exception>()
                .FallbackAsync(async (cancellationToken) => await Task.Run(() => Console.WriteLine(ea.RoutingKey)));

            fallbackPolicy
                .WrapAsync(retryPolicy)
                .ExecuteAsync(async () => await Send(ea.RoutingKey, ea.Body.ToArray(), ea.DeliveryTag).ConfigureAwait(false))
                .ConfigureAwait(false)
                .GetAwaiter()
                .GetResult();
        }

        private async Task Send(string key, byte[] body, ulong deliveryTag)
        {
            var messageType = _binding[key];
            var content = Encoding.UTF8.GetString(body);

            var request = (IRequest)JsonConvert.DeserializeObject(content, messageType);
            await _mediatr.Send(request);

            _channel.BasicAck(deliveryTag, false);
        }

        public void Dispose()
        {
            _channel?.Close();
            _connection?.Close();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
