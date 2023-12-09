using BankSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Interfaces
{
    internal interface IAccountManagement
    {
        void CreateAccount(string accountNumber, decimal initialBalance);
        void CloseAccount(string accountNumber);
        BankAccount GetAccount(string accountNumber);
    }
}
