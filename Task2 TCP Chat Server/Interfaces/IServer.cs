namespace Task2_TCP_Chat_Server.Interfaces
{
    internal interface IServer
    {
        public IServerUsersRegister ServerUsersRegister { get; set; }
        public IServerBroadcaster ServerBroadcaster { get; set; }
        public Task StartServer();
    
    }
}
