using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner
{

    public static class Helpers
    {
        public static DateTime GetDateFromUser()
        {
            Console.Write("\nWpisz datę: ");
            DateTime UserDate;
            if (DateTime.TryParse(Console.ReadLine(), out UserDate))
            {
                Console.Clear();
                return UserDate;
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Podałeś datę w złym formacie. Spróbuj jeszcze raz");
                return GetDateFromUser();
            }
        }

        public static DateTime[] GetDateRangeFromUser()
        {
            DateTime[] dates = new DateTime[2];
            Console.Clear();
            Console.Write("Proszę podaj dzień, od którego począwszy chcesz zobaczyć swoje transakcje (format dd-mm-yyyy): ");
            dates[0] = Helpers.GetDateFromUser();
            Console.Write("Proszę podaj dzień, do którego zobaczyć swoje transakcje (format dd-mm-yyyy): ");
            dates[1] = Helpers.GetDateFromUser();
            Console.Clear();
            return dates;
        }

       

        // Przedstawienie aplikacji użytkownikowi
        public static void IntroduceTheApplication()
        {
            Console.WriteLine("Witaj w BudgetPlannerApp!\n");
            Console.WriteLine("BudgetPlannerApp to aplikacja do prostego śledzenia Twoich dochodów i wydatków\n");
            Console.WriteLine("Naciśnij dowolny klawisz aby rozpocząć");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ClickToProceed()
        {
            Console.Write("\nNaciśnij dowolny klawisz by przejść do menu: ");
            Console.ReadKey();
            Console.Clear();
        }

        public static void SayGoodByeToUser()
        {
            Console.Clear();
            Console.WriteLine("Do zobaczenia!\n");
        }

        public static void WrongActionChoosen()
        {
            Console.Clear();
            Console.WriteLine("Wybrałeś działanie spoza właściwego zakresu\n");
        }
    }
}

