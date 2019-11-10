using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class Payment : TransactionEntity
    {
        public decimal TotalAmount { get; set; }
        public decimal CapitalPayment { get; set; }
        public decimal Profit { get; set; }
        public int LoanId { get; set; }
        public Loan Loan { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal? SurCharge { get; set; }
    }
}
