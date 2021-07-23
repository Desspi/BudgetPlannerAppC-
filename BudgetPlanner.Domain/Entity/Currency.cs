using BudgetPlanner.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Domain.Entity
{
    public class Currency : BaseEntity
    {
        public string ShortName { get; set; }

        public Currency(int id, string name, string shortName) : base(id, name)
        {
            ShortName = shortName;
        }
    }
}
