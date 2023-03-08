using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApp.Infrastructure.Entities
{
    public class User : TransactionEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
