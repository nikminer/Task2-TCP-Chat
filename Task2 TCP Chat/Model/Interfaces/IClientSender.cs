namespace Task2_TCP_Chat.Model.Interfaces
{
    internal interface IClientSender
    {
        public IChatClient ChatClient { get; set; }
        public void Send(string text);
    }
}
