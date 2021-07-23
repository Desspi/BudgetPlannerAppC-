using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Managers
{
    public class CurrencyManager
    {
        public static int GetIdFromUserView()
        {
            Console.Write("\nWybierz swoją domyślną walutę z listy: ");
            Int32.TryParse(Console.ReadLine(), out int userCurrencyId);
            Console.Clear();

            return userCurrencyId;
        }
    }
}
