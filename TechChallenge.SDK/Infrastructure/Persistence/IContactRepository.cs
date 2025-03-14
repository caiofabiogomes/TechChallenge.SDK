using TechChallenge.SDK.Domain.Models;

namespace TechChallenge.SDK.Infrastructure.Persistence
{
    public interface IContactRepository
    {
        Task AddAsync(Contact entity);
        Task UpdateAsync(Contact entity);
        Task DeleteAsync(Contact entity);
        Task<Contact?> GetByIdAsync(Guid id);
        IQueryable<Contact> Query();
    }
}
