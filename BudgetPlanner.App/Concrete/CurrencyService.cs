using BudgetPlanner.App.Common;
using BudgetPlanner.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Concrete
{
    public class CurrencyService : BaseService<Currency>
    {
        public CurrencyService() : base()
        {
            Initialize();
        }
      
        public override void ShowListOfItems()
        {
            foreach (var currency in Items)
            {
                if ( currency.Id % 2 == 0)
                {
                    Console.Write($"{currency.Id + ".", -3} {currency.Name,-45}{currency.ShortName, -10}\n");
                }
                else {
                    Console.Write($"{currency.Id + ".", -3} {currency.Name,-44}{currency.ShortName, -10}");
                }
            }
        }

        private void Initialize()
        {
            AddNewItem(new Currency(1, "Polski złoty", "PLN"));
            AddNewItem(new Currency(2, "Euro", "EUR"));
            AddNewItem(new Currency(3, "Funt brytyjski", "GBP"));
            AddNewItem(new Currency(4, "Rubel rosyjski", "RUB"));
            AddNewItem(new Currency(5, "Dolar australijski", "AUD")) ;
            AddNewItem(new Currency(6, "Dolar amerykański", "USD")) ;
            AddNewItem(new Currency(7, "Lek albański", "ALL")) ;
            AddNewItem(new Currency(8, "Dinar algierski", "DZD")) ;
            AddNewItem(new Currency(9, "Dram armeński", "AMD")) ;
            AddNewItem(new Currency(10, "Peso argentyńskie", "ARS")) ;
            AddNewItem(new Currency(11, "Frank CFA", "XAF")) ;
            AddNewItem(new Currency(12, "Taka bangladeska", "BDT")) ;
            AddNewItem(new Currency(13, "Rubel białoruski", "BYN"));
            AddNewItem(new Currency(14, "Lew bułgarski", "BGN")) ;
            AddNewItem(new Currency(15, "Boliviano", "BOB")) ;
            AddNewItem(new Currency(16, "Real brazylijski", "BRL")) ;
            AddNewItem(new Currency(17, "Forint węgierski", "HUF")) ;
            AddNewItem(new Currency(18, "Won południowokoreański", "KRW")) ;
            AddNewItem(new Currency(19, "Dolar wschodniokaraibski", "XCD")) ;
            AddNewItem(new Currency(20, "Dong wietnamski", "VND")) ;
            AddNewItem(new Currency(21, "Lempira honduraska", "HNL")) ;
            AddNewItem(new Currency(22, "Quetzal gwatemalski", "GTQ")) ;
            AddNewItem(new Currency(23, "Cedi ghańskie", "GHS")) ;
            AddNewItem(new Currency(24, "Dola hongkoński", "HKD")) ;
            AddNewItem(new Currency(25, "Lari gruzińskie", "GEL")) ;
            AddNewItem(new Currency(26, "Korona duńska", "DKK")) ;
            AddNewItem(new Currency(27, "Peso dominikańskie", "DOP")) ;
            AddNewItem(new Currency(28, "Dolar fidżyjski", "FJD")) ;
            AddNewItem(new Currency(29, "Denar trynidadzki", "TTD"));
            AddNewItem(new Currency(30, "Funt egipski", "EGP")) ;
            AddNewItem(new Currency(31, "Dirham Zjednoczonych Emiratów Arabskich", "AED")) ;
            AddNewItem(new Currency(32, "Rupia indyjska", "INR")) ;
            AddNewItem(new Currency(33, "Dinar jordański", "JOD")) ;
            AddNewItem(new Currency(34, "Dinar iracki", "IQD")) ;
            AddNewItem(new Currency(35, "Rupia indonezyjska", "IDR")) ;
            AddNewItem(new Currency(36, "Tenge kazachski", "KZT")) ;
            AddNewItem(new Currency(37, "Dolar kanadyjski", "CAD")) ;
            AddNewItem(new Currency(38, "Rial katarski", "QAR")) ;
            AddNewItem(new Currency(39, "Szyling kenijski", "KES")) ;
            AddNewItem(new Currency(40, "Colon kostarykański", "CRC")) ;
            AddNewItem(new Currency(41, "Marka zamienna Bośni i Hercegowiny", "BAM")) ;
            AddNewItem(new Currency(42, "Som kirgijski", "KGS")) ;
            AddNewItem(new Currency(43, "Juan chiński", "CNY")) ;
            AddNewItem(new Currency(44, "Peso kolumbijskie", "COP")) ;
            AddNewItem(new Currency(45, "Pero kubańskie", "CUP")) ;
            AddNewItem(new Currency(46, "Dinar kuwejcki", "KWD")) ;
            AddNewItem(new Currency(47, "Manat azerbejdżański", "AZN")) ;
            AddNewItem(new Currency(48, "Kiat", "MMK"));
        }
    }

}
