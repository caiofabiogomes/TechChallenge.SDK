using TechChallenge.SDK.Models;
using Microsoft.EntityFrameworkCore;

namespace TechChallenge.SDK.Persistence
{
    public partial class ContactsDBContext : DbContext
    {
        public ContactsDBContext(DbContextOptions<ContactsDBContext> options)
        : base(options)
        {
        }
        public virtual DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().OwnsOne(c => c.Email, email =>
            {
                email.Property(e => e.Endereco).HasColumnName("EmailAddress");
            });

            modelBuilder.Entity<Contact>().OwnsOne(c => c.Name, name =>
            {
                name.Property(n => n.FirstName).HasColumnName("FirstName");
                name.Property(n => n.LastName).HasColumnName("LastName");
            });

            modelBuilder.Entity<Contact>().OwnsOne(c => c.Phone, phone =>
            {
                phone.Property(p => p.DDD).HasColumnName("PhoneDDD");
                phone.Property(p => p.Number).HasColumnName("PhoneNumber");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
