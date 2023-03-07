using System.Net.Sockets;
using Task2_TCP_Chat_Server.Interfaces;

namespace Task2_TCP_Chat_Server
{
    internal class User : IUser
    {
        public string Id { get; } 
        public StreamWriter Writer { get; private set; }
        public StreamReader Reader { get; private set; }
         private TcpClient _client { get; }
        public string UserName { get; set; } = "Anonymous";

        public User(TcpClient client)
        {
            Id = Guid.NewGuid().ToString();
            _client = client;
            Stream stream = client.GetStream();
            Reader = new StreamReader(stream);
            Writer = new StreamWriter(stream);
        }

        public async void SendAsync(string message)
        {
            await Writer.WriteLineAsync(message);
            await Writer.FlushAsync();
        }

        public void Dispose()
        {
            Writer.Close();
            Reader.Close();
            _client.Close();
        }
    }
}
