namespace Task2_TCP_Chat_Server.Interfaces
{
    internal interface IServerBroadcaster
    {
        public Task BroadcastMessageAsync(string message, IUser? ignoreUser = null);
    }
}
