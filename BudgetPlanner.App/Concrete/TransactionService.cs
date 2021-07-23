using BudgetPlanner.App.Common;
using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Concrete
{
    public class TransactionService : BaseService<Transaction>
    {
        public static void MakeTable(List<Transaction> lista)
        {
            Console.WriteLine($"{"ID",-5}{"Typ transakcji",-20}{"Data",-15}{"Kwota",-10}{"Konto",-10}{"Waluta",-10}{"Kategoria",-20}{"Komentarz",-40}");
            foreach (var trans in lista)
            {
                Console.WriteLine($"{trans.Id,-5}{trans.Type.ToString(),-20}{trans.DateOfTransaction.ToShortDateString(),-15}{trans.AmountOfMoney,-10}{trans.Account.Name,-10}{trans.Currency.ShortName,-10}{trans.Category.Name,-20}{trans.Name,-40}");
            }
        }

        public void ShowInformationAboutTransactionsByChoosenCriterion(int id)
        {
            var newItemList = Items.Where(x => x.Id == id).ToList();
            Console.WriteLine($"Oto dane wykonanej transakcji: \n");
            MakeTable(newItemList);
        }

        public void ShowInformationAboutTransactionsByChoosenCriterion(TransactionType type)
        {
            var newItemList = Items.Where(x => x.Type == type).ToList();
            Console.WriteLine("Transakcje według wybranego typu: \n");
            MakeTable(newItemList);
        }

        public void ShowInformationAboutTransactionsByChoosenCriterion(DateTime[] dateRange)
        {
            var newItemList = Items.Where(x => (x.DateOfTransaction >= dateRange[0] && x.DateOfTransaction <= dateRange[1].AddDays(1))).ToList();
            Console.WriteLine("Transakcje według wybranego zakresu dat: \n");
            MakeTable(newItemList);

        }

        public void ShowInformationAboutTransactionsByChoosenCriterion(double[] amounts)
        {
            var newItemList = Items.Where(x => (x.AmountOfMoney >= amounts[0] && x.AmountOfMoney <= amounts[1])).ToList();
            Console.WriteLine("Transakcje według wybranego zakresu kwot: \n");
            MakeTable(newItemList);
        }

        public void ShowInformationAboutTransactionsByChoosenCriterion(Account acc)
        {
            var newItemList = Items.Where(x => (x.Account == acc)).ToList();
            Console.WriteLine("Transakcje według wybranego konta: \n");
            MakeTable(newItemList);
        }

        public void ShowInformationAboutTransactionsByChoosenCriterion(Category cat)
        {
            var newItemList = Items.Where(x => (x.Category == cat)).ToList();
            Console.WriteLine("Transakcje według wybranej kategorii: \n");
            MakeTable(newItemList);
        }

        public void ShowInformationAboutTransactionsByChoosenCriterion(string name)
        {
            var newItemList = Items.Where(x => x.Name.Contains(name)).ToList();
            Console.WriteLine("Transakcje zawierające szukaną frazę: \n");
            MakeTable(newItemList);
        }
        public override void ShowListOfItems()
        {
            Console.Clear();
            Console.WriteLine("Oto dane wszystkich zrealizowanych transakcji: \n");
            MakeTable(Items);
        }

        public void ShowInformationAboutTransactionSortedAscendingByChoosenCriterion()
        {
            Console.Clear();
            Console.WriteLine("Oto dane wszystkich zrealizowanych transakcji: \n");
            var newItemList = Items.OrderBy(x => x.DateOfTransaction).ToList();
            MakeTable(newItemList);
        }

        public void ShowInformationAboutTransactionSortedDescendingByChoosenCriterion()
        {
            Console.Clear();
            Console.WriteLine("Oto dane wszystkich zrealizowanych transakcji: \n");
            var newItemList = Items.OrderByDescending(x => x.DateOfTransaction).ToList();
            MakeTable(newItemList);
        }

        public void ShowInformationAboutTransactionSortedAscendingByAmountOfMoney()
        {
            Console.Clear();
            Console.WriteLine("Oto dane wszystkich zrealizowanych transakcji: \n");
            var newItemList = Items.OrderBy(x => x.AmountOfMoney).ToList();
            MakeTable(newItemList);
        }

        public void ShowInformationAboutTransactionSortedDescendingByAmountOfMoney()
        {
            Console.Clear();
            Console.WriteLine("Oto dane wszystkich zrealizowanych transakcji: \n");
            var newItemList = Items.OrderByDescending(x => x.AmountOfMoney).ToList();
            MakeTable(newItemList);
        }

        public void ShowStatementInChoosenPeriod(DateTime startDate, DateTime endDate)
        {
            if (Items.Count > 0)
            {
                var sumOfRevenues = Items.Where(x => x.Type == TransactionType.Przychód && x.DateOfTransaction >= startDate && x.DateOfTransaction <= endDate.AddDays(1)).Sum(x => x.AmountOfMoney);
                Console.Write($"Suma przychodów w okresie od {startDate.ToShortDateString()} do {endDate.ToShortDateString()} to: {sumOfRevenues.ToString()} {Items[0].Currency.ShortName}\n\n");

                Items.Where(x => x.Type == TransactionType.Przychód && x.DateOfTransaction >= startDate && x.DateOfTransaction <= endDate.AddDays(1)).GroupBy(x => x.Category).ToList().ForEach(x =>
                {
                    Console.WriteLine(x.Key.Name);

                    var suma = x.ToList().Sum(x => x.AmountOfMoney);
                    Console.WriteLine($"{suma} {Items[0].Currency.ShortName}\n");
                });

                var sumOfExpenses = Items.Where(x => x.Type == TransactionType.Wydatek && x.DateOfTransaction >= startDate && x.DateOfTransaction <= endDate.AddDays(1)).Sum(x => x.AmountOfMoney);
                Console.Write($"\nSuma wydatków w okresie od {startDate.ToShortDateString()} do {endDate.ToShortDateString()} to: {sumOfExpenses.ToString()} {Items[0].Currency.ShortName}\n");

                Console.WriteLine("\nSuma wydatków z podziałem na poszczególne kategorie w danym okresie:\n");

                Items.Where(x => x.Type == TransactionType.Wydatek && x.DateOfTransaction >= startDate && x.DateOfTransaction <= endDate.AddDays(1)).GroupBy(x => x.Category).ToList().ForEach(x =>
                {
                    Console.WriteLine(x.Key.Name);

                    var suma = x.ToList().Sum(x => x.AmountOfMoney);
                    Console.WriteLine($"{suma} {Items[0].Currency.ShortName}\n");
                });
            }
            else
            {
                Console.WriteLine("Brak transakcji. Najpierw dodaj transakcje by zobaczyc zestawienie");
            }
        }

    }
}
