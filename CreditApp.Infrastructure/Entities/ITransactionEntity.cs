using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApp.Infrastructure.Entities
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
