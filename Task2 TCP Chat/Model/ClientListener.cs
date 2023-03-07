using System;
using System.ComponentModel;
using System.IO;
using System.Windows;
using Task2_TCP_Chat.Model.Interfaces;

namespace Task2_TCP_Chat.Model
{
    internal class ClientListener : IClientListener
    {
        // Обязанность класса слушать порт в ожидание новых сообщений

        private BackgroundWorker _worker = new BackgroundWorker();
        private StreamReader _reader;
        public IChatClient ChatClient { get; set; }
        public ClientListener(IChatClient chatClient)
        {
            ChatClient = chatClient;
            _worker = new BackgroundWorker();
            _worker.DoWork += Worker_DoWork;

            _reader = new StreamReader(chatClient.TcpClient.GetStream()); 
        }

        public void StartListening()
        {
            if (_reader is null)
            {
                throw new Exception("Не удалось получить поток для чтения");
            }
            
            _worker.RunWorkerAsync();
        }

        private async void Worker_DoWork(object? sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    string? input = await _reader.ReadLineAsync();
                    if (string.IsNullOrEmpty(input))
                    {
                        continue;
                    }

                    Message message = new Message();
                    string[] parts = input.Split(':');
                    message.Text = parts[1];
                    message.Nick = parts[0];

                    App.Current.Dispatcher.Invoke((Action)delegate
                    {
                        ChatClient.ClientMemory.AddMessage(message);
                    });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    
                    return;
                }
            }
        }
    }
}
