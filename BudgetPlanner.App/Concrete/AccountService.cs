using BudgetPlanner.App.Common;
using BudgetPlanner.Domain;
using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Concrete
{
    public class AccountService : BaseService<Account>
    {

        public void ShowAccountMoneyValue(Account account)
        {
            Console.WriteLine($"Stan konta wynosi: {account.SumOfMoney + " " +  account.Currency.ShortName}");
        }

    }
}
