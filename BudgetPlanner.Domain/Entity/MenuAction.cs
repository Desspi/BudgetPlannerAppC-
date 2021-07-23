using BudgetPlanner.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Domain.Entity
{
    public class MenuAction : BaseEntity
    {
        public string MenuName { get; set; }

        public MenuAction(int id, string name, string menuName) : base(id, name)
        {
            MenuName = menuName;
        }
    }
}
