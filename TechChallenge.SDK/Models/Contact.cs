using System.Numerics;
using TechChallenge.SDK.ValueObjects;

namespace TechChallenge.SDK.Models
{
    public partial class Contact
    {
        public Contact() { }
        public Contact(Name name, Email email, Phone phone)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            Phone = phone;
            Validate();
        }

        public Guid Id { get; set; }

        public Name Name { get; set; }
        public Email Email { get; set; }
        public Phone Phone { get; set; }

        public void UpdateName(Name name)
        {
            Name = name
                   ?? throw new ArgumentNullException("O nome não pode ser vazio.");
        }

        public void UpdateEmail(Email email)
        {
            Email = email
                ?? throw new ArgumentNullException("O email não pode ser vazio.");
        }

        public void UpdatePhone(Phone phone)
        {
            Phone = phone
                ?? throw new ArgumentNullException("O telefone não pode ser vazio.");
        }

        private void Validate()
        {
            if (Name is null)
                throw new ArgumentNullException("O nome não pode ser vazio.");
            if (Email is null)
                throw new ArgumentNullException("O email não pode ser vazio.");
            if (Phone is null)
                throw new ArgumentNullException("O telefone não pode ser vazio.");
        }
    }
}
