using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Server.Core;

public class Sender : ISender
{
    public Socket Handler { get; set; } 
    
    public void Send<T>(T entity)
    {
        string entityType = typeof(T).Name;

        Message message = new Message
        {
            Name = "Sending_Entity", 
            Priority = 1, 
            //Type = MessageTypeEnum.Classic, 
            EntityType = entityType
        };//, entity);
        string jsonMessage = JsonSerializer.Serialize(message);

        Console.WriteLine(jsonMessage);

        /*var messageBytes = Encoding.UTF8.GetBytes(jsonMessage);
        Handler.SendAsync(messageBytes, 0);*/
    }
}