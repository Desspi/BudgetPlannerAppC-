using BudgetPlanner.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BudgetPlanner.Domain.Entity
{
    public enum TransactionType
    {
        Przychód = 1,
        Wydatek
    }
    public class Transaction : BaseEntity
    {
        public TransactionType Type { get; set; }
        public DateTime DateOfTransaction { get; set; }

        public double AmountOfMoney { get; set; }

        public Account Account { get; set; }

        public Currency Currency { get; set; }

        public Category Category { get; set; }

        public Transaction(int id, string name, TransactionType type, DateTime date, double amountOfMoney, Account acc, Currency curr, Category cat) : base(id, name)
        {
            Type = type;
            DateOfTransaction = date;
            AmountOfMoney = amountOfMoney;
            Account = acc;
            Currency = curr;
            Category = cat;
        }


    }
}
