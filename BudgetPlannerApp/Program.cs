using BudgetPlanner.App;
using BudgetPlanner.App.Concrete;
using BudgetPlanner.App.Managers;
using BudgetPlanner.Domain;
using BudgetPlanner.Domain.Entity;
using System;

namespace BudgetPlanner
{
    class Program
    {
        static void Main(string[] args)
        {

            Helpers.IntroduceTheApplication();

            //Wybór waluty dla konta głównego
            CurrencyService currencyService = new CurrencyService();
            currencyService.ShowListOfItems();
            Currency userCurrency = currencyService.GetItemByIdOrName(CurrencyManager.GetIdFromUserView());

            // Wprowadzenie kwoty dla konta głównego
            AccountService accountService = new AccountService();
            accountService.AddNewItem(new Account(1, "Główne", userCurrency, AccountManager.GetMainAccountValueFromUserView(userCurrency)));

           // Inicjacja składowych
            MenuActionService menuService = new MenuActionService();
            MenuManager menuManager = new MenuManager(menuService);
            CategoryService categoryService = new CategoryService();
            AccountManager accountManager = new AccountManager(currencyService, accountService);
            TransactionService transactionService = new TransactionService();
            TransactionManager transactionManager = new TransactionManager(accountService, categoryService, transactionService);
            CategoryManager categoryManager = new CategoryManager(categoryService, transactionManager);
            string operation;


            do
            {
                //Wyświetlenie menu
                Console.WriteLine("MENU GŁÓWNE\n");
                menuService.ShowMenuActionsByMenuName("Main");
                operation = menuManager.GetActionFromUser(out operation);



                switch (operation)
                {
                    case "1":
                        int transId = transactionService.AddNewItem(transactionManager.GetTransaction());
                        transactionService.ShowInformationAboutTransactionsByChoosenCriterion(transId);
                        Helpers.ClickToProceed();
                        break;
                    case "2":
                        string op;
                        //test
                        do
                        {
                            transactionService.ShowListOfItems();
                            Console.WriteLine("Wybierz z poniższej listy co chcesz zrobić: \n");
                            menuService.ShowMenuActionsByMenuName("TransactionMenu");
                            menuManager.GetActionFromUser(out op);
                            switch (op)
                            {
                                case "1":
                                    string[] choices = menuManager.CreateSortingMenu();
                                    if (choices[0] == "1" && choices[1] == "1")
                                    {
                                        transactionService.ShowInformationAboutTransactionSortedAscendingByChoosenCriterion();
                                        Helpers.ClickToProceed();
                                    }
                                    else if (choices[0] == "1" && choices[1] == "2")
                                    {
                                        transactionService.ShowInformationAboutTransactionSortedDescendingByChoosenCriterion();
                                        Helpers.ClickToProceed();
                                    }
                                    else if (choices[0] == "2" && choices[1] == "1")
                                    {
                                        transactionService.ShowInformationAboutTransactionSortedAscendingByAmountOfMoney();
                                        Helpers.ClickToProceed();
                                    }
                                    else if (choices[0] == "2" && choices[1] == "2")
                                    {
                                        transactionService.ShowInformationAboutTransactionSortedDescendingByAmountOfMoney();
                                        Helpers.ClickToProceed();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wybrane działanie nie istnieje! Spróbuj jeszcze raz");
                                        Helpers.ClickToProceed();
                                    }
                                    break;
                                case "2":
                                    string choice;
                                    menuService.ShowMenuActionsByMenuName("FilterTransactionMenu");
                                    menuManager.GetActionFromUser(out choice);
                                    if (choice == "1")
                                    {
                                        int choosenId = transactionManager.GetTransactionIdView();
                                        transactionService.ShowInformationAboutTransactionsByChoosenCriterion(choosenId);
                                    }
                                    else if (choice == "2")
                                    {
                                        TransactionType type = transactionManager.GetTransactionTypeView("transakcji");
                                        transactionService.ShowInformationAboutTransactionsByChoosenCriterion(type);
                                    }
                                    else if (choice == "3")
                                    {
                                        DateTime[] userDateRange = Helpers.GetDateRangeFromUser();
                                        transactionService.ShowInformationAboutTransactionsByChoosenCriterion(userDateRange);
                                    }
                                    else if (choice == "4")
                                    {
                                        double[] amounts = transactionManager.GetAmountOfMoneyRange();
                                        transactionService.ShowInformationAboutTransactionsByChoosenCriterion(amounts);
                                    }
                                    else if (choice == "5")
                                    {
                                        Account choosenAccount = transactionManager.GetTransactionAccountView();
                                        transactionService.ShowInformationAboutTransactionsByChoosenCriterion(choosenAccount);
                                    }
                                    else if (choice == "6")
                                    {
                                        TransactionType type = transactionManager.GetTransactionTypeView("kategorii");
                                        Category choosenCategory = transactionManager.GetTransactionCategoryView(type);
                                        transactionService.ShowInformationAboutTransactionsByChoosenCriterion(choosenCategory);
                                        
                                    }
                                    else if (choice == "7")
                                    {
                                        string comment = transactionManager.GetTransactionNameView();
                                        transactionService.ShowInformationAboutTransactionsByChoosenCriterion(comment);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Wybrałeś działanie zpoza zakresu. Spróbuj jeszcze raz\n");
                                    }
                                    Helpers.ClickToProceed();
                                    break;
                                case "3":
                                    break;
                                default:
                                    Helpers.WrongActionChoosen();
                                    Helpers.ClickToProceed();
                                    break;
                            }
                            //test
                        } while (op != "3");
                        break;
                    case "3":
                        DateTime[] dateRange = Helpers.GetDateRangeFromUser();
                        transactionService.ShowStatementInChoosenPeriod(dateRange[0], dateRange[1]);
                        Helpers.ClickToProceed();
                        break;
                    case "4":
                        accountService.ShowAccountMoneyValue(transactionManager.GetTransactionAccountView());
                        Helpers.ClickToProceed();
                        break;
                    case "5":
                        categoryManager.AddNewCategoryView();
                        Helpers.ClickToProceed();
                        break;
                    case "6":
                        accountManager.AddNewAccountView();
                        Helpers.ClickToProceed();
                        break;
                    case "7":
                        Helpers.SayGoodByeToUser();
                        break;
                    default:
                        Helpers.WrongActionChoosen();
                        break;
                }


            } while (operation != "7");





        }
    }
}
