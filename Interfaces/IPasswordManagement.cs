using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Interfaces
{
    internal interface IPasswordManagement
    {
        void SetPassword(string accountNumber, string password);
        bool VerifyPassword(string accountNumber, string password);
    }
}
