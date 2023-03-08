namespace CreditApp.Shared.Services.Common.Dtos
{
    public class FeeInformationDto
    {
        public int Id { get; set; }
        public int LoanId { get; set; }
        public decimal? SurCharge { get; set; }
    }
}
