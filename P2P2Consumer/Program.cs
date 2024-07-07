﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new("amqps://egzzskzx:XX6dYEZMSwHR_dj4OZUvMkPBBtVK14us@hawk.rmq.cloudamqp.com/egzzskzx");

// Connection Active & Open Channel
using IConnection connection = factory.CreateConnection();
using IModel channel = connection.CreateModel();

string queueName = "example-p2p-queue";

channel.QueueDeclare(queue: queueName, durable: false, exclusive: false, autoDelete: false);

EventingBasicConsumer consumer = new(channel);

channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);

consumer.Received += (sender, args) =>
{
    Console.WriteLine(Encoding.UTF8.GetString(args.Body.Span));
};

Console.ReadLine();