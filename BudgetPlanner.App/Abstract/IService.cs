using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Abstract
{
    interface IService<T>
    {
        List<T> Items { get;}

        int AddNewItem(T item);

        List<T> GetAllItems();

        T GetItemByIdOrName(int id);
        T GetItemByIdOrName(string name);

        void RemoveItem(T item);

        void ShowListOfItems();
    }
}
