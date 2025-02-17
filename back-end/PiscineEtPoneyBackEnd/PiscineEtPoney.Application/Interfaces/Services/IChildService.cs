using PiscineEtPoney.Domain.Entities;

namespace PiscineEtPoney.Application.Interfaces
{
    public interface IChildService
    {
        Task<IEnumerable<Child>> GetAllChildrenAsync();
        Task<Child> GetChildByIdAsync(int id);
        Task<Child> AddChildAsync(Child child);
        Task UpdateChildAsync(int id, Child updatedChild);
        Task DeleteChildAsync(int id);
    }
}
