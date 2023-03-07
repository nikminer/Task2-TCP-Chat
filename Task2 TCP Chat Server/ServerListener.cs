using Task2_TCP_Chat_Server.Interfaces;

namespace Task2_TCP_Chat_Server
{
    internal class ServerListener: IServerListener
    {
        // Обязанность класса выполнять прослушку пользователей

        private IUser _user { get; set; }
        private IServer _server { get; set; }

        public ServerListener(IUser user, IServer server)
        {
            _user = user;
            _server = server;
        }

        public async Task StartListinigAsync()
        {
            try
            {
                string? message;
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    message = await _user.Reader.ReadLineAsync();

                    if (message == null)
                    {
                        continue;
                    }

                    message = $"{_user.UserName}:{message}";

                    await _server.ServerBroadcaster.BroadcastMessageAsync(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                _server.ServerUsersRegister.UnregisterUserAsync(_user);
            }
        }

    }
}
