namespace Task2_TCP_Chat_Server.Interfaces
{
    interface IUser: IDisposable
    {
        public string Id { get; }
        public StreamWriter Writer { get; }
        public StreamReader Reader { get; }
        public string UserName { get; set; }

        public void SendAsync(string message);
    }
}
