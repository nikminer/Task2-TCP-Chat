using System.Net.Sockets;

namespace Task2_TCP_Chat.Model.Interfaces
{
    internal interface IChatClient
    {
        public TcpClient TcpClient { get; }
        public string UserName { get; set; }

        public IConnectionData ConnectionData { get; set; }

        public IClientMemory ClientMemory { get; set; }

        public IClientSender ClientSender { get; set; }

        public void Connect();
        public void Disconnect();
    }
}
