using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class FeeInformation : TransactionEntity
    {
        public int? LoanId { get; set; }
        public Loan Loan { get; set; }
        public int Number { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal TotalFee { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal CapitalPayment{get;set;}
        public decimal RateAmount { get; set; }
    }
}
