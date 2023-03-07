using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task2_TCP_Chat
{
    internal class PropertyChanger: INotifyPropertyChanged
    {
        // Класс необходимый для обновления данных по паттерну MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
