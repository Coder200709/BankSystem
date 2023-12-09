using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Interfaces
{
    internal interface IAccountOperations
    {
        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        void GetBalance();
    }
}
