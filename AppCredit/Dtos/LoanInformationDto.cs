using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppCredit.Api.Dtos
{
    public class LoanInformationDto
    {
        public int CustomerId { get; set; }
        public LoanStartInformationDto BasicInfoLoan { get; set; }
        public IEnumerable<FeeInformation> LoanInformation { get; set; }

    }
}
