using System;
using System.IO;
using System.Net.Sockets;
using Task2_TCP_Chat.Model.Interfaces;

namespace Task2_TCP_Chat.Model
{
    internal class ChatClient: PropertyChanger, IChatClient
    {
        // Обязанность класса выполнять базовые функции подключения и отключения
        public TcpClient TcpClient { get; private set; }

        private IClientListener _listener;

        private string _userName = "NewUser";
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged("UserNick");
            }
        }

        public IConnectionData ConnectionData { get; set; }

        public IClientMemory ClientMemory { get; set; }

        public IClientSender ClientSender { get; set; }

        public ChatClient()
        {
            ConnectionData = new ConnectionData();
            ClientMemory = new ClientMemory();
            
        }


        public void Connect()
        {
            if (TcpClient is not null && TcpClient.Connected)
            {
                return;
            }

            TcpClient = new TcpClient();
            TcpClient.Connect(ConnectionData.Host, ConnectionData.Port);

            _listener = new ClientListener(this);
            _listener.StartListening();

            ClientSender = new ClientSender(this);
            ClientSender.Send($"{UserName}");
        }

        public void Disconnect()
        {
            TcpClient.Close();
        }

    }
}
