using System.Collections.ObjectModel;
using Task2_TCP_Chat.Model.Interfaces;

namespace Task2_TCP_Chat.Model
{
    internal class ClientMemory: PropertyChanger, IClientMemory
    {
        // Обязанность класса хранить текущую сессию

        public ObservableCollection<Message> Messages { get; set; }

        public ClientMemory()
        {
            Messages = new ObservableCollection<Message>();
        }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
            OnPropertyChanged("Messages");
        }
    }
}
