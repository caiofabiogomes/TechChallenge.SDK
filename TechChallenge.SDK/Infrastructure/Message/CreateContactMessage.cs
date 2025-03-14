namespace TechChallenge.SDK.Infrastructure.Message
{
    public class CreateContactMessage
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DDD { get; set; }

        public int Phone { get; set; }

        public string Email { get; set; }

        public CreateContactMessage(string firstName, string lastName, int Ddd, int phone, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            DDD = Ddd;
            Phone = phone;
            Email = email;
        }
    }
}
