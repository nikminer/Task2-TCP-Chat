using System;
using System.Net;
using System.Windows;
using Task2_TCP_Chat.Model.Interfaces;

namespace Task2_TCP_Chat.Model
{
    internal class ConnectionData: PropertyChanger, IConnectionData
    {
        private IPAddress _host = IPAddress.Loopback;
        public string Host
        {
            get { return _host.ToString(); }
            set
            {
                try
                {
                    _host = IPAddress.Parse(value);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                OnPropertyChanged("Host");
            }
        }

        private int _port = 123;
        public int Port
        {
            get { return _port; }
            set
            {
                _port = value;
                OnPropertyChanged("Port");
            }
        }
    }
}
