using BudgetPlanner.App.Abstract;
using BudgetPlanner.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace BudgetPlanner.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(x => x.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public virtual int AddNewItem(T item)
        {
            Items.Add(item);
            return item.Id;
        }

        public virtual List<T> GetAllItems()
        {
            return Items;
        }

        public virtual void RemoveItem(T item)
        {
            Items.Remove(item);
        }

        public virtual void ShowListOfItems()
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
            
        }

        public T GetItemByIdOrName(int id)
        {
            int pos = -1;
            foreach (T item in Items)
            {
                if (item.Id == id)
                {
                    pos = Items.IndexOf(item);
                    break;
                }
            }
            return Items[pos];
        }

        public T GetItemByIdOrName(string name)
        {
            int pos = -1;
            foreach (T item in Items)
            {
                if (item.Name == name)
                {
                    pos = Items.IndexOf(item);
                    break;
                }
            }
            return Items[pos];
        }
    }
}
