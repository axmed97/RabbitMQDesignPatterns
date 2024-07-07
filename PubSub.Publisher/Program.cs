using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://egzzskzx:XX6dYEZMSwHR_dj4OZUvMkPBBtVK14us@hawk.rmq.cloudamqp.com/egzzskzx");

// Connection Active & Open Channel
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();
