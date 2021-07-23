using BudgetPlanner.App.Common;
using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Concrete
{
    public class CategoryService : BaseService<Category>
    {
        public CategoryService() :base()
        {
            Initialize();
        }

        public List<Category> GetCategoriesByCategoryType(TransactionType type)
        {
            List<Category> list = new List<Category>();
            foreach (var item in Items)
            {
                if (item.Type == type)
                {
                    list.Add(item);
                }
            }
            return list;
        }

        private void Initialize()
        {
            AddNewItem(new Category(1,"Transport", TransactionType.Wydatek));
            AddNewItem(new Category(2,"Trening", TransactionType.Wydatek));
            AddNewItem(new Category(3,"Rodzina", TransactionType.Wydatek));
            AddNewItem(new Category(4,"Artykuły spożywcze", TransactionType.Wydatek));
            AddNewItem(new Category(5,"Prezenty", TransactionType.Wydatek));
            AddNewItem(new Category(6,"Edukacja", TransactionType.Wydatek));
            AddNewItem(new Category(7,"Kawiarnie", TransactionType.Wydatek));
            AddNewItem(new Category(8,"Dom", TransactionType.Wydatek));
            AddNewItem(new Category(9,"Wypoczynek", TransactionType.Wydatek));
            AddNewItem(new Category(10,"Zdrowie", TransactionType.Wydatek));
            AddNewItem(new Category(11, "Inne", TransactionType.Wydatek));
            AddNewItem(new Category(12, "Procent", TransactionType.Przychód));
            AddNewItem(new Category(13, "Prezent", TransactionType.Przychód));
            AddNewItem(new Category(14, "Wypłata", TransactionType.Przychód));
            AddNewItem(new Category(15, "Inne", TransactionType.Przychód));
            
        }

    }
}
