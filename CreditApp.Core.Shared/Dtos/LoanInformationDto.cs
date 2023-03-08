using CreditApp.Infrastructure.Entities;

namespace CreditApp.Shared.Services.Common.Dtos
{
    public class LoanInformationDto
    {
        public int CustomerId { get; set; }
        public LoanStartInformationDto BasicInfoLoan { get; set; }
        public IEnumerable<FeeInformation> LoanInformation { get; set; }
    }
}
