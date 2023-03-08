using System;
using System.Collections.Generic;
using System.Text;

namespace CreditApp.Infrastructure.Entities
{
    public class Loan : TransactionEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? CreationDate { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal LoanAmount { get; set; }
        public int FeesNumber { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        //Utility
        public decimal GrossProfit { get; set; }
        public DateTimeOffset Begining { get; set; }
        public DateTimeOffset End { get; set; }
        public IEnumerable<FeeInformation> FeeInformations { get; set; }
        public double BankRate { get; set; }
    }
}
