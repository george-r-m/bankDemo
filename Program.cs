using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount("George",10000);
            Console.WriteLine($"Account number= {account.AccountNumber} Account name={account.Name} Balance= {account.Balance}");
            account.Deposit(50, DateTime.Now, "Depositing 50$");
            Console.WriteLine($"\n {account.Balance}");
            account.Withdraw(20, DateTime.Now, "Withdrawing 20");
            Console.WriteLine($"\n {account.Balance}\n");
            Console.WriteLine(account.GetHistory());
        }
    }
}
