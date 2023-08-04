using RabbitMQ.Client;
using System.Text;

var connectionFactory = new ConnectionFactory()
{
    HostName = "localhost"
};

var connection = connectionFactory.CreateConnection();
var chanel = connection.CreateModel();

chanel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

var message = "Hello RabbitMQ";
var byteMessage = Encoding.UTF8.GetBytes(message);

chanel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: byteMessage);

Console.WriteLine("Mesaj gonderildi");
