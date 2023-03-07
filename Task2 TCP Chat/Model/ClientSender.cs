using System;
using System.IO;
using Task2_TCP_Chat.Model.Interfaces;

namespace Task2_TCP_Chat.Model
{
    internal class ClientSender : IClientSender
    {
        // Обязанность класса отправлять сообщения на сервер

        private StreamWriter _writer;
        public IChatClient ChatClient { get; set; }

        public ClientSender(IChatClient chatClient)
        {
            ChatClient = chatClient;
            _writer = new StreamWriter(chatClient.TcpClient.GetStream());
        }

        public async void Send(string text)
        {
            if (_writer is null)
            {
                throw new Exception("Не удалось получить поток для записи");
            }

            await _writer.WriteLineAsync($"{text}");
            await _writer.FlushAsync();
        }
    }
}
