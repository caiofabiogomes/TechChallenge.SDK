using TechChallenge.SDK.Models;

namespace TechChallenge.SDK.Persistence
{
    public interface IContactRepository
    {
        Task AddAsync(Contact entity);
        Task UpdateAsync(Contact entity);
        Task DeleteAsync(Contact entity);
        Task<Contact?> GetByIdAsync(int id);
        IQueryable<Contact> Query();
    }
}
