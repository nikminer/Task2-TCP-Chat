using System;
using System.Windows;
using Task2_TCP_Chat.Model;
using Task2_TCP_Chat.Model.Interfaces;

namespace Task2_TCP_Chat.ModelView
{
    internal class ClientVM : PropertyChanger
    {
        #region Data
        private string _currentText = string.Empty;
        public string CurrentText
        {
            get { return _currentText; }
            set
            {
                _currentText = value;
                OnPropertyChanged("CurrentText");
            }
        }
        #endregion Data

        public IChatClient ChatClient { get; set; }
        
        public ClientVM()
        {
            ChatClient = new ChatClient();
        }

        #region Commands

        private ClientCommand connectCommand;
        public ClientCommand ConnectCommand
        {
            get
            {
                return connectCommand ??
                  (connectCommand = new ClientCommand(obj =>
                  {
                      try
                      {
                          ChatClient.Connect();

                          MessageBox.Show("Успешно подключено", "TCP Chat", MessageBoxButton.OK, MessageBoxImage.Information);
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                      }
                      
                  }));
            }
        }

        private ClientCommand sendCommand;
        public ClientCommand SendCommand
        {
            get
            {
                return sendCommand ??
                  (sendCommand = new ClientCommand(obj =>
                  {
                      try
                      {
                          if (CurrentText.Length == 0)
                          {
                              return;
                          }

                          if (ChatClient.ClientSender is null)
                          {
                              throw new Exception("Не подключено к серверу");
                          }

                          ChatClient.ClientSender.Send(CurrentText);

                          CurrentText = string.Empty;
                      }
                      catch (Exception e)
                      {
                          MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                      }

                  }));
            }
        }

        #endregion Commands
    }
}
