using Task2_TCP_Chat.Model.Interfaces;

namespace Task2_TCP_Chat.Model
{
    internal class Message : PropertyChanger, IMessage
    {
        private string _nick;
        public string Nick
        {
            get { return _nick; }
            set
            {
                _nick = value;
                OnPropertyChanged("Nick");
            }
        }

        private string _text;
        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                OnPropertyChanged("Text");
            }
        }
    }
}
