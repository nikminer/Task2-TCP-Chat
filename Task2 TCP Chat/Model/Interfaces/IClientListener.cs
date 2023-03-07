namespace Task2_TCP_Chat.Model.Interfaces
{
    internal interface IClientListener
    {
        public IChatClient ChatClient { get; set; }
        public void StartListening();
    }
}
