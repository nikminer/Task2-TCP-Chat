namespace Task2_TCP_Chat.Model.Interfaces
{
    internal interface IMessage
    {
        public string Nick { get; set; }

        public string Text { get; set; }
    }
}
