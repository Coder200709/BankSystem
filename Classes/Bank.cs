using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankSystem.Interfaces;
namespace BankSystem.Classes
{
    public class Bank : IAccountManagement, IPasswordManagement
    {
        private List<BankAccount> accounts;
        private Dictionary<string, string> passwordDictionary;

        public Bank()
        {
            accounts = new List<BankAccount>();
            passwordDictionary = new Dictionary<string, string>();
        }

        public void CreateAccount(string accountNumber, decimal initialBalance)
        {
            if (GetAccount(accountNumber) != null)
            {
                Console.WriteLine("Account allaqachon mavjud.");
                return;
            }

            var account = new BankAccount(accountNumber, initialBalance);
            accounts.Add(account);
            Console.WriteLine($"{accountNumber} accounti muvaffaqiyatli yaratildi.");
        }

        public void CloseAccount(string accountNumber)
        {
            var account = GetAccount(accountNumber);
            if (account == null)
            {
                Console.WriteLine("Account mavjud emas.");
                return;
            }

            accounts.Remove(account);
            passwordDictionary.Remove(accountNumber);
            Console.WriteLine($"{accountNumber} accounti muvaffaqiyatli o'chirildi.");
        }

        public BankAccount GetAccount(string accountNumber)
        {
            return accounts.Find(account => account.AccountNumber == accountNumber);
        }

        public void SetPassword(string accountNumber, string password)
        {
            if (passwordDictionary.ContainsKey(accountNumber))
            {
                Console.WriteLine("Bu Account uchun allaqachon parol qo'yilgan.");
                return;
            }

            passwordDictionary.Add(accountNumber, password);
            Console.WriteLine("Parol muvaffaqiyatli qo'yildi.");
        }

        public bool VerifyPassword(string accountNumber, string password)
        {
            if (!passwordDictionary.ContainsKey(accountNumber))
            {
                Console.WriteLine("Bu Account uchun parol qo'yilmagan.");
                return false;
            }

            return passwordDictionary[accountNumber] == password;
        }

        public void Transfer(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            var fromAccount = GetAccount(fromAccountNumber);
            var toAccount = GetAccount(toAccountNumber);

            if (fromAccount == null || toAccount == null)
            {
                Console.WriteLine("Account xato kiritilgan.");
                return;
            }

            if (fromAccount.Balance < amount)
            {
                Console.WriteLine("Balans yetarli emas.");
                return;
            }

            fromAccount.Withdraw(amount);
            toAccount.Deposit(amount);
            Console.WriteLine($" {amount} so'm pul  {fromAccountNumber} accountidan  {toAccountNumber} accountigaga " +
                $"muvaffaqiyatli jo'natildi .");
        }
    }
}
