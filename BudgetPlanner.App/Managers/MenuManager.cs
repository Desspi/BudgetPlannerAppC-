using BudgetPlanner.App.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Managers
{
    public class MenuManager
    {
        private MenuActionService menuService;

        public MenuManager(MenuActionService menuService)
        {
            this.menuService = menuService;
        }

        public string GetActionFromUser(out string operation)
        {
            Console.Write("\nWybierz z menu określone działanie i wprowadź cyfrę: ");
            operation = Console.ReadLine();
            Console.Clear();
            return operation;
        }

        public string[] CreateSortingMenu()
        {
            string[] choices = new string[2];
            Console.Clear();
            Console.WriteLine("Wybierz według czego mają być posortowane dane: \n");
            menuService.ShowMenuActionsByMenuName("SortTransactionMenu");
            GetActionFromUser(out choices[0]);
            Console.Clear();
            Console.WriteLine("Wybierz jak mają być posortowane dane: \n");
            menuService.ShowMenuActionsByMenuName("SortTypeMenu");
            GetActionFromUser(out choices[1]);
            return choices;
        }
    }
}
