using System.Net;
using System.Net.Sockets;
using Task2_TCP_Chat_Server.Interfaces;

namespace Task2_TCP_Chat_Server
{
    internal class Server: IServer
    {
        // Обязанность класса выполнять основные функции сервера такие как запуск или остановка

        TcpListener tcpListener;
        public IServerUsersRegister ServerUsersRegister { get; set; }
        public IServerBroadcaster ServerBroadcaster { get; set; }
        public Server()
        {
            tcpListener = new TcpListener(IPAddress.Loopback, 123);
            ServerUsersRegister = new ServerUsersRegister(this);
            ServerBroadcaster = new ServerBroadcaster(ServerUsersRegister);
        }

        public async Task StartServer()
        {
            try
            {
                // Запускаем прослушку TCP
                tcpListener.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений...");

                while (true)
                {
                    TcpClient? tcpClient = await tcpListener.AcceptTcpClientAsync();

                    if (tcpClient != null)
                    {
                        ServerUsersRegister.RegisterUserAsync(tcpClient);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                ShutDownServer();
            }
        }

        // Метод обрабатывающий завершение работы сервера
        private void ShutDownServer()
        {
            foreach (IUser user in ServerUsersRegister.Users)
            {
                user.Dispose();
            }
            tcpListener.Stop();
        }
    }
}
