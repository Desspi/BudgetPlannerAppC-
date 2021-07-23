using BudgetPlanner.App.Concrete;
using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Managers
{
    public class CategoryManager
    {
        private CategoryService categoryService;
        private TransactionManager transactionManager;

        public CategoryManager(CategoryService cat, TransactionManager trans)
        {
            categoryService = cat;
            transactionManager = trans;
        }

        public void AddNewCategoryView()
        {
            Console.Write("Wprowadź nazwę dla nowej kategorii: ");
            string newCategoryName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Czego ma dotyczyć nowa kategoria?\n");
            TransactionType type = transactionManager.GetTransactionTypeView("kategorii");
            categoryService.AddNewItem(new Category(categoryService.GetLastId() + 1, newCategoryName, type));
            Console.Clear();
            Console.WriteLine($"Kategoria {newCategoryName} została dodana!");
        }
    }
}
