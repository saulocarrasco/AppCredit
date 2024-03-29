﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApp.Infrastructure.Entities
{
    public class Address : TransactionEntity
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public Customer Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}
