using BudgetPlanner.App.Common;
using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        public MenuActionService() : base()
        {
            Initialize();
        }
       
        public void ShowMenuActionsByMenuName(string menuName)
        {
            
            foreach (var menuAction in Items)
            {
                if(menuAction.MenuName == menuName)
                {
                    Console.WriteLine($"{menuAction.Id}. {menuAction.Name}");
                }
            }
            
        }

        private void Initialize()
        {
            AddNewItem(new MenuAction(1, "Dodaj transakcję", "Main"));
            AddNewItem(new MenuAction(2, "Pokaż listę transakcji", "Main"));
            AddNewItem(new MenuAction(3, "Generuj zestawienie z danego okresu", "Main"));
            AddNewItem(new MenuAction(4, "Sprawdź stan danego konta", "Main"));
            AddNewItem(new MenuAction(5, "Dodaj nową kategorię", "Main"));
            AddNewItem(new MenuAction(6, "Dodaj nowe konto", "Main"));
            AddNewItem(new MenuAction(7, "Zamknij program", "Main"));
            AddNewItem(new MenuAction(1, "Sortuj według wybranego kryterium", "TransactionMenu"));
            AddNewItem(new MenuAction(2, "Filtruj według wybranego kryterium", "TransactionMenu"));
            AddNewItem(new MenuAction(3, "Wróć do głównego menu", "TransactionMenu"));
            AddNewItem(new MenuAction(1, "Sortuj według daty transakcji", "SortTransactionMenu"));
            AddNewItem(new MenuAction(2, "Sortuj według kwoty transakcji", "SortTransactionMenu"));
            AddNewItem(new MenuAction(1, "Sortuj rosnąco", "SortTypeMenu"));
            AddNewItem(new MenuAction(2, "Sortuj malejąco", "SortTypeMenu"));
            AddNewItem(new MenuAction(1, "Filtruj po ID", "FilterTransactionMenu"));
            AddNewItem(new MenuAction(2, "Filtruj po typie transakcji", "FilterTransactionMenu"));
            AddNewItem(new MenuAction(3, "Filtruj po dacie", "FilterTransactionMenu"));
            AddNewItem(new MenuAction(4, "Filtruj po kwocie", "FilterTransactionMenu"));
            AddNewItem(new MenuAction(5, "Filtruj po koncie", "FilterTransactionMenu"));
            AddNewItem(new MenuAction(6, "Filtruj po kategorii", "FilterTransactionMenu"));
            AddNewItem(new MenuAction(7, "Filtruj po komentarzu", "FilterTransactionMenu"));
        }

    }
}
