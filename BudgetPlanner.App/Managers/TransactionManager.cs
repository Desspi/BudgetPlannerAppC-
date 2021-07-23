using BudgetPlanner.App.Concrete;
using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Managers
{
    public class TransactionManager
    {
        private AccountService accountService;
        private CategoryService categoryService;
        private TransactionService transactionService;

        public TransactionManager(AccountService acc, CategoryService cat, TransactionService trans)
        {
            accountService = acc;
            categoryService = cat;
            transactionService = trans;
        }

        public int GetTransactionIdView()
        {
            Console.Write("Proszę podaj ID szukanej transakcji: ");
            Int32.TryParse(Console.ReadLine(), out int choosenId);
            Console.Clear();
            return choosenId;
        }

        public TransactionType GetTransactionTypeView(string typ)
        {
            Console.WriteLine("1. Przychód");
            Console.WriteLine("2. Wydatek\n");
            Console.Write($"Wybierz rodzaj {typ}: ");
            var selected = Console.ReadLine();
            int transactionTypeId;
            if (Int32.TryParse(selected, out transactionTypeId) && transactionTypeId == 1 || transactionTypeId == 2)
            { 
            Console.Clear();
            return (TransactionType)transactionTypeId;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Podałeś nieprawidłową liczbę. Spróbuj jeszcze raz\n");
                return GetTransactionTypeView(typ);
            }
        }

        public Account GetTransactionAccountView()
        {
            accountService.ShowListOfItems();
            Console.WriteLine($"\nWybierz konto: ");
            if (Int32.TryParse(Console.ReadLine(), out int transactionAccountId) && accountService.Items.Count >= transactionAccountId)
            {
                Console.Clear();
                return accountService.Items[transactionAccountId - 1];
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Podałeś nieprawidłową liczbę. Spróbuj jeszcze raz\n");
                return GetTransactionAccountView();
            }   
        }

        public double GetTransactionAmountView(TransactionType transactionType, Account transactionAccount)
        {
            if ((int)transactionType == 1)
            {
                
                Console.Write($"Podaj kwotę jaką chcesz zasilić konto: ");
                if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                {
                    transactionAccount.SumOfMoney += amount;
                    Console.Clear();
                    return amount;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Kwota musi być większa od 0. Spróbuj jeszcze raz\n");
                    return GetTransactionAmountView(transactionType, transactionAccount);
                }
                
            }
            else if ((int)transactionType == 2)
            {
                Console.Write($"Podaj o jaką kwotę chcesz uszczuplić swoje konto: ");
                if (double.TryParse(Console.ReadLine(), out double amount) && amount > 0)
                {
                    transactionAccount.SumOfMoney -= amount;
                    Console.Clear();
                    return amount;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Kwota musi być większa od 0. Spróbuj jeszcze raz\n");
                    return GetTransactionAmountView(transactionType, transactionAccount);
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("\nWystąpił błąd, podałeś nieprawidłowe dane, spróbuj jeszcze raz\n");
                return GetTransactionAmountView(transactionType, transactionAccount);
            }
        }

        public Category GetTransactionCategoryView(TransactionType type)
        {
            List<Category> categoriesByType = categoryService.GetCategoriesByCategoryType(type);
            foreach (var item in categoriesByType)
            {
                Console.WriteLine($"{categoriesByType.IndexOf(item) + 1}. {item.Name}");
            }
            Console.Write("\nWybierz kategorię związaną z transakcją: ");
            if (Int32.TryParse(Console.ReadLine(), out int selectedCategory) && categoriesByType.Count >= selectedCategory && selectedCategory > 0)
            {
                Console.Clear();
                return categoriesByType[selectedCategory - 1];
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Podałeś nieprawidłową liczbę. Spróbuj jeszcze raz\n");
                return GetTransactionCategoryView(type);
            }
            
        }

        public string GetTransactionNameView()
        {
            Console.WriteLine("Wybierz nazwę transakcji: ");
            string transactionName = Console.ReadLine();
            Console.Clear();
            return transactionName;
        }

        public double[] GetAmountOfMoneyRange()
        {
            double[] amounts = new double[2];
            Console.Clear();
            Console.Write("Proszę kwotę minimalną dla szukanych transakcji: ");
            if (double.TryParse(Console.ReadLine(), out amounts[0]))
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Podałeś niewłaściwą kwotę. Spróbuj jeszcze raz");
                return GetAmountOfMoneyRange();
            }
            Console.Write("Proszę kwotę maksymalną dla szukanych transakcji: ");
            if (double.TryParse(Console.ReadLine(), out amounts[1]))
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Podałeś niewłaściwą kwotę. Spróbuj jeszcze raz");
                return GetAmountOfMoneyRange();
            }
            Console.Clear();
            return amounts;
        }

        public Transaction GetTransaction()
        {
            
            TransactionType transType = GetTransactionTypeView("transakcji");
            Account transAcc = GetTransactionAccountView();
            double amount = GetTransactionAmountView(transType, transAcc);
            Category category = GetTransactionCategoryView(transType);
            string name = GetTransactionNameView();
            return new Transaction(transactionService.GetLastId() + 1, name, transType, DateTime.Now, amount, transAcc, transAcc.Currency, category);
        }
    }
}
