using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"
};

var connection = connectionFactory.CreateConnection();
var chanel = connection.CreateModel();

var consumer = new EventingBasicConsumer(chanel);

consumer.Received += (model, ea) =>
{
    var byteMessage = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(byteMessage);
    Console.WriteLine($"Oxunan mesaj {message}");
};

chanel.BasicConsume(queue:"hello",autoAck:true,consumer:consumer);

Console.ReadKey();