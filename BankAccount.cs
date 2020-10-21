using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    class BankAccount
    {
        public string AccountNumber { get; }
        public string Name { get; set; }

        public decimal Balance
        {
            get
            {

                decimal balance = 0;
                foreach (var item in allTransactions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }

        private List<Transaction> allTransactions = new List<Transaction>();

        private static int seed = 111111111;
        
        public BankAccount(string name,decimal initialBalance)
        {
            Name = name;
            Deposit(initialBalance, DateTime.Now, "First Deposit");
            AccountNumber = seed.ToString();
            seed++;
        }
        
        public void Deposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount should be > 0");

            }
            var deposit = new Transaction(amount, date, note);
            allTransactions.Add(deposit);
        }

        public void Withdraw(decimal amount,DateTime date,string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount should be >0");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("No suffiecient fund");
            }
            var withdraw = new Transaction(-amount, date, note);
            allTransactions.Add(withdraw);
        }

        public string GetHistory()
        {
            var report = new StringBuilder();
            report.Append("Date  Amount  Note");
            foreach (var item in allTransactions)
            {
                report.Append($"\n{item.Date.ToShortDateString()} {item.Amount} {item.Notes}");
            }
            return report.ToString();
        }
    }
}
