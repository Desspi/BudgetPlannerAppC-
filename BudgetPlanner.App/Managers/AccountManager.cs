using BudgetPlanner.App.Concrete;
using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Managers
{
    public class AccountManager
    {
        CurrencyService currencyService;
        AccountService accountService;

        public AccountManager(CurrencyService curr, AccountService acc)
        {
            currencyService = curr;
            accountService = acc;
        }
        public void AddNewAccountView()
        {
            Console.Write("Wprowadź nazwę dla nowego konta: ");
            string newAccountName = Console.ReadLine();
            Console.Clear();
            currencyService.ShowListOfItems();
            Console.Write("\nWprowadź walutę dla nowego konta: ");
            if (Int32.TryParse(Console.ReadLine(), out int selection) && currencyService.Items.Count > selection)
            {
                accountService.AddNewItem(new Account(accountService.GetLastId() + 1, newAccountName, currencyService.GetItemByIdOrName(selection), 0));
                Console.WriteLine("Konto zostało dodane!");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Wybrałeś walutę, która nie istnieje. Spróbuj jeszcze raz");
                AddNewAccountView();
            }
            
        }
        public static double GetMainAccountValueFromUserView(Currency userCurrency)
        {
            Console.WriteLine("Prowadź saldo konta głównego");
            Console.WriteLine("Później będziesz miał możliwość dodania większej ilości kont\n");
            Console.Write($"Stan konta w {userCurrency.ShortName} to: ");
            Double.TryParse(Console.ReadLine(), out double userMainValue);
            Console.Clear();
            return userMainValue;
        }
    }
}
