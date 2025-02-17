using PiscineEtPoney.Domain.Entities;

namespace PiscineEtPoney.Application.Interfaces.Repositories
{
    public interface IParentRepository
    {
        // Récupérer un parent par son ID
        Task<Parent> GetByIdAsync(int id);

        // Récupérer tous les parents
        Task<IEnumerable<Parent>> GetAllAsync();

        // Ajouter un parent
        Task AddAsync(Parent parent);

        // Mettre à jour un parent
        Task UpdateAsync(Parent parent);

        // Supprimer un parent
        Task DeleteAsync(int id);
    }
}
