using PiscineEtPoney.Domain.Entities;

namespace PiscineEtPoney.Application.Interfaces.Repositories
{
    public interface IChildRepository
    {
        // Récupérer un child par son ID
        Task<Child> GetByIdAsync(int id);

        // Récupérer tous les childs
        Task<List<Child>> GetAllAsync();

        // Ajouter un child
        Task<Child> AddAsync(Child child);

        // Mettre à jour un child
        Task UpdateAsync(Child child);

        // Supprimer un child
        Task DeleteAsync(int id);
    }
}