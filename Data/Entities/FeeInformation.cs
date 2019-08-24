using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class FeeInformation : ITransactionEntity
    {
        public int? CreditId { get; set; }
        public Credit Credit { get; set; }
        public int Number { get; set; }
        public DateTimeOffset Date { get; set; }
        public double TotalFee { get; set; }
        public double CurrentAmount { get; set; }
        public double CapitalPayment{get;set;}
        public int Id {get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreationDate { get ; set; }
        public DateTimeOffset DeletedDate { get; set; }
    }
}
