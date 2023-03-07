using System.Net.Sockets;
using Task2_TCP_Chat_Server.Interfaces;

namespace Task2_TCP_Chat_Server
{
    // Обязанность класса выполнять учёт пользователей
    internal class ServerUsersRegister : IServerUsersRegister
    {
        public List<IUser> Users { get; private set; }
        private IServer _server { get; set; }
        public ServerUsersRegister(Server server)
        {
            Users = new List<IUser>();
            _server = server;
        }

        public async void RegisterUserAsync(TcpClient tcpClient)
        {
            IUser user = new User(tcpClient);
            Users.Add(user);

            // Ожидаем что первое сообщение пользователя - это будет сообщение о его подключении
            string? username = await user.Reader.ReadLineAsync();

            user.UserName = username != null? username: user.UserName;

            // Уведомляем о том что пользователь подключился
            string message = $"Server:{username} вошел в чат";
            await _server.ServerBroadcaster.BroadcastMessageAsync(message);

            // Запускаем прослушку пользователя
            IServerListener serverListener = new ServerListener(user, _server);
            Task.Run(serverListener.StartListinigAsync);
        }

        // Метод обрабатывающий отключение пользователя от сервера
        public async void UnregisterUserAsync(IUser user)
        {
            string message = $"Server:{user.UserName} покинул чат";

            await _server.ServerBroadcaster.BroadcastMessageAsync(message, user);

            if (user != null)
            {
                Users.Remove(user);
                user.Dispose();
            }
        }
    }
}
