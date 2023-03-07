using System.Collections.ObjectModel;

namespace Task2_TCP_Chat.Model.Interfaces
{
    internal interface IClientMemory
    {
        public ObservableCollection<Message> Messages { get; set; }
        public void AddMessage(Message message);
    }
}
