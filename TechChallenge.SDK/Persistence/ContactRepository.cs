using Polly;
using TechChallenge.SDK.Models;

namespace TechChallenge.SDK.Persistence
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsDBContext _context;
        private readonly AsyncPolicy _retryPolicy;

        public ContactRepository(ContactsDBContext context)
        {
            _context = context;
            _retryPolicy = Policy.Handle<Exception>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));
        }

        public async Task AddAsync(Contact entity)
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                await _context.Contacts.AddAsync(entity);
                await _context.SaveChangesAsync();
            });
        }

        public async Task UpdateAsync(Contact entity)
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                _context.Contacts.Update(entity);
                await _context.SaveChangesAsync();
            });
        }

        public async Task DeleteAsync(Contact entity)
        {
            await _retryPolicy.ExecuteAsync(async () =>
            {
                _context.Set<Contact>().Remove(entity);
                await _context.SaveChangesAsync();
            });
        }

        public async Task<Contact?> GetByIdAsync(Guid id)
        {
            return await _retryPolicy.ExecuteAsync(async () =>
            {
                return await _context.Contacts.FindAsync(id);
            });
        }

        public IQueryable<Contact> Query()
        {
            return _context.Contacts.AsQueryable();
        }
    }
}
