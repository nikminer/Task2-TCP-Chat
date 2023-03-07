using Task2_TCP_Chat_Server.Interfaces;

namespace Task2_TCP_Chat_Server
{
    internal class ServerBroadcaster : IServerBroadcaster
    {
        // Обязанность класса выполнять трансляцию сообщения всем пользователям
        private IServerUsersRegister _serverUsersRegister;

        public ServerBroadcaster(IServerUsersRegister serverUsersRegister)
        {
            _serverUsersRegister = serverUsersRegister;
        }

        // Метод отвечающий за трансляцию сообщений
        public Task BroadcastMessageAsync(string message, IUser? ignoreUser = null)
        {
            Console.WriteLine(message);
            foreach (IUser user in _serverUsersRegister.Users)
            {
                if (ignoreUser == user)
                {
                    continue;
                }

                user.SendAsync(message);
            }

            return Task.CompletedTask;
        }
    }
}
