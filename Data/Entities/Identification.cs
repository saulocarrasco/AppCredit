using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Identification : TransactionEntity
    {
        public Doctype Doctype { get; set; }
        public string Value { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}
