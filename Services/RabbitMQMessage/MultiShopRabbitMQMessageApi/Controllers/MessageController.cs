using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace MultiShopRabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class MessageController : ControllerBase
    {

        [HttpPost]
        public IActionResult CreateMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2", false, false, false, arguments: null);

            var messageContent = "Merhaba bugün hava soğuk.";

            var byteMessageContent = Encoding.UTF8.GetBytes(messageContent);

            channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContent);

            return Ok("Mesajınız Kuyruğa Alınmıştır.");
        }
        private static string message = "";
        [HttpGet]
        public IActionResult ReadMessage()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            var connection = connectionFactory.CreateConnection();

            var channel = connection.CreateModel();
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
            };
            channel.BasicConsume(queue: "Kuyruk2", autoAck: false, consumer: consumer);

            return Ok(message);
        }
    }
}
