using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Identification : ITransactionEntity
    {
        public Doctype Doctype { get; set; }
        public string Value { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}
