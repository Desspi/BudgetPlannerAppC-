using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Domain.Common
{
    public abstract class BaseEntity : AuditableModel
    {
        public int Id { get; protected set; }

        public string Name { get; set; }

        public BaseEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
