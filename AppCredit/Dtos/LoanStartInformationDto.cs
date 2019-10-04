using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCredit.Api.Dtos
{
    public class LoanStartInformationDto
    {
        public decimal Capital { get; set; }
        public double BankRate { get; set; }
        public int QuantityAliquot { get; set; }
        public int Modality { get; set; }
        public DateTimeOffset StartDate { get; set; }
    }
}
