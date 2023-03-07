using System.Net.Sockets;

namespace Task2_TCP_Chat_Server.Interfaces
{
    internal interface IServerUsersRegister
    {
        public List<IUser> Users { get; }

        public void RegisterUserAsync(TcpClient tcpClient);

        public void UnregisterUserAsync(IUser user);
    }
}
