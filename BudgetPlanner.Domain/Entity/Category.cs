using BudgetPlanner.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Domain.Entity
{
    public class Category : BaseEntity
    {
        public TransactionType Type { get; set; }
        public Category(int id, string name, TransactionType categoryType) : base(id, name) 
        {
            Type = categoryType;
        }
       
    }
}
