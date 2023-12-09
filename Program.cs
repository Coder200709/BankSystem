using System;
using System.Collections.Generic;
using BankSystem.Classes;
public class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("1. Account Yaratish");
            Console.WriteLine("2. Parol qo'yish");
            Console.WriteLine("3. Parolni tekshirish");
            Console.WriteLine("4. Pul kiritish");
            Console.WriteLine("5. Pul Yechib Olish");
            Console.WriteLine("6. Balansni ko'rish");
            Console.WriteLine("7. Pul Jo'natish");
            Console.WriteLine("8. Accountni o'chirish");
            Console.WriteLine("9. Chiqish");
            Console.WriteLine("Tanlovingizni Kiriting:");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Accountni kiriting:");
                    string accountNumber = Console.ReadLine();
                    Console.WriteLine("Boshlang'ich pulni kiriting:");
                    decimal initialBalance = Convert.ToDecimal(Console.ReadLine());
                    bank.CreateAccount(accountNumber, initialBalance);
                    break;

                case "2":
                    Console.WriteLine("Accountni kiriting:");
                    string accountNumber2 = Console.ReadLine();
                    Console.WriteLine("Parolni Kiriting:");
                    string password = Console.ReadLine();
                    bank.SetPassword(accountNumber2, password);
                    break;

                case "3":
                    Console.WriteLine("Accountni kiriting:");
                    string accountNumber3 = Console.ReadLine();
                    Console.WriteLine("Parolni Kiriting:");
                    string password2 = Console.ReadLine();
                    bool isPasswordCorrect = bank.VerifyPassword(accountNumber3, password2);
                    if (isPasswordCorrect)
                    {
                        Console.WriteLine("Parol to'g'ri");
                    }
                    else
                    {
                        Console.WriteLine("Parol Xato");
                    }
                    break;

                case "4":
                    Console.WriteLine("Accountni kiriting:");
                    string accountNumber4 = Console.ReadLine();
                    Console.WriteLine("Boshlang'ich pulni kiriting:");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                    BankAccount depositAccount = bank.GetAccount(accountNumber4);
                    if (depositAccount != null)
                    {
                        depositAccount.Deposit(depositAmount);
                    }
                    else
                    {
                        Console.WriteLine("Account topilmadi.");
                    }
                    break;

                case "5":
                    Console.WriteLine("Accountni kiriting:");
                    string accountNumber5 = Console.ReadLine();
                    Console.WriteLine("Yechib olmoqchi bo'lgan miqdoringizni kiriting:");
                    decimal withdrawalAmount = Convert.ToDecimal(Console.ReadLine());
                    BankAccount withdrawalAccount = bank.GetAccount(accountNumber5);
                    if (withdrawalAccount != null)
                    {
                        withdrawalAccount.Withdraw(withdrawalAmount);
                    }
                    else
                    {
                        Console.WriteLine("Account topilmadi.");
                    }
                    break;

                case "6":
                    Console.WriteLine("Accountni kiriting:");
                    string accountNumber6 = Console.ReadLine();
                    BankAccount balanceAccount = bank.GetAccount(accountNumber6);
                    if (balanceAccount != null)
                    {
                        balanceAccount.GetBalance();
                    }
                    else
                    {
                        Console.WriteLine("Account topilmadi.");
                    }
                    break;

                case "7":
                    Console.WriteLine("Pul yechiladigan Accountni kiriting:");
                    string sourceAccountNumber = Console.ReadLine();
                    Console.WriteLine("Pul jo'natiladigan Accountni kiriting:");
                    string destinationAccountNumber = Console.ReadLine();
                    Console.WriteLine("Jo'natiladigan pul miqdori:");
                    decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
                    bank.Transfer(sourceAccountNumber, destinationAccountNumber, transferAmount);
                    break;

                case "8":
                    Console.WriteLine("Accountni kiriting:");
                    string accountNumber8 = Console.ReadLine();
                    bank.CloseAccount(accountNumber8);
                    break;

                case "9":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Xato son kiritildi. Iltimos qayta urining.");
                    break;
            }

            Console.WriteLine();
        }
    }
}