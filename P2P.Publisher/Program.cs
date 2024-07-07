using RabbitMQ.Client;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://egzzskzx:XX6dYEZMSwHR_dj4OZUvMkPBBtVK14us@hawk.rmq.cloudamqp.com/egzzskzx");

// Connection Active & Open Channel
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

string queueName = "example-p2p-queue";

channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false);

byte[] message = Encoding.UTF8.GetBytes("Hello");

channel.BasicPublish(exchange: string.Empty, routingKey: queueName, body: message);



Console.ReadLine();