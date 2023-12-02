using RabbitMQ.Client;
using System.Text.Json;
using System.Text;
using RabbitMQ.Client.Events;
using Core;

namespace Consumidor
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    UserName = "guest",
                    Password = "guest"
                };

                using var connection = factory.CreateConnection();
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "Fila",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null
                    );

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (sender, eventArgs) => 
                    { 
                        var body = eventArgs.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var pedido = JsonSerializer.Deserialize<Pedido>(message);

                        Console.WriteLine(pedido?.ToString());
                    };

                    channel.BasicConsume(
                        queue: "Fila",
                        autoAck: true,
                        consumer: consumer
                    );
                }
                await Task.Delay(2000, stoppingToken);
            }
        }
    }
}