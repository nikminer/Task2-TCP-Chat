using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_TCP_Chat.Model.Interfaces
{
    internal interface IConnectionData
    {
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
