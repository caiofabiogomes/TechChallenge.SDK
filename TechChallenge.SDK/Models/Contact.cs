namespace TechChallenge.SDK.Models
{
    public partial class Contact
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string EmailAddress { get; set; } = null!;

        public int PhoneDdd { get; set; }

        public int PhoneNumber { get; set; }
    }
}
