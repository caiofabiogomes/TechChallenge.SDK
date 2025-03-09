using TechChallenge.SDK.Models;

namespace TechChallenge.SDK.Persistence
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
