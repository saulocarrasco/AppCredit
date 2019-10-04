using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public abstract class Person : ITransactionEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Identification> Identifications { get; set; }
        public IEnumerable<Loan> Loans { get; set; }
        public int Id { get ; set ; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? CreationDate { get ; set ; }
        public DateTimeOffset? DeletedDate { get ; set; }
    }
}
