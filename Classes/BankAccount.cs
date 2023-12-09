using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Interfaces;
namespace BankSystem.Classes
{
    public class BankAccount : IAccountOperations
    {
        public string AccountNumber { get; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($" {amount} so'm pul {AccountNumber} ga qo'shildi.");
        }

        public void Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                Console.WriteLine($" {amount} so'm pul {AccountNumber} dan ayrildi.");
            }
            else
            {
                Console.WriteLine($" {AccountNumber} accountida mablag' yetarli emas.");
            }
        }

        public void GetBalance()
        {
            Console.WriteLine($" {AccountNumber} accountida balans: {Balance} so'm.");
        }
    }
}
