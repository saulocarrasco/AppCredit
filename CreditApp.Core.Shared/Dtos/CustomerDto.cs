namespace CreditApp.Shared.Services.Common.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string MobilePhone { get; set; }
        public string PhoneNumber { get; set; }
        public string Identification { get; set; }
        public string IdentificationType { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public string CreationDate { get; set; }
        public string DeletedDate { get; set; }
    }
}
