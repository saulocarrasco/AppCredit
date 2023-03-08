using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApp.Infrastructure.Entities
{
    public class Role : TransactionEntity
    {
        public string Name { get; set; }
        public IEnumerable<Permission> Permissions { get; set; }
    }
}
