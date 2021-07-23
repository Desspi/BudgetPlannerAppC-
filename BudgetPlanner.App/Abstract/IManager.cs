using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.App.Abstract
{
    interface IManager<T>
    {
        T ChooseFromTheList();
    }
}
