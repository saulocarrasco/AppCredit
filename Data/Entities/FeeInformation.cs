using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class FeeInformation : ITransactionEntity
    {
        public int? LoanId { get; set; }
        public Loan Loan { get; set; }
        public int Number { get; set; }
        public DateTimeOffset Date { get; set; }
        public decimal TotalFee { get; set; }
        public decimal CurrentAmount { get; set; }
        public decimal CapitalPayment{get;set;}
        public int Id {get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? CreationDate { get ; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public decimal RateAmount { get; set; }
    }
}
