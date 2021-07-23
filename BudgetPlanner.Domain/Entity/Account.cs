using BudgetPlanner.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Domain.Entity
{
    public class Account : BaseEntity
    {
        public Currency Currency { get; set; }
        public double SumOfMoney { get; set; }

        public Account(int id, string name, Currency currency, double sumofmoney) : base(id, name)
        {
            Id = id;
            Currency = currency;
            SumOfMoney = sumofmoney;
        }
    }
}
