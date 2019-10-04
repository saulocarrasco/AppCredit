using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Address : ITransactionEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}
