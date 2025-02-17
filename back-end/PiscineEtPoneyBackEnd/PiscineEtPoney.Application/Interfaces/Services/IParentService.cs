using PiscineEtPoney.Domain.Entities;

namespace PiscineEtPoney.Application.Interfaces.Services
{
    public interface IParentService
    {
        // Récupérer un parent par son ID
        Task<Parent> GetParentByIdAsync(int id);

        // Récupérer tous les parents
        Task<IEnumerable<Parent>> GetAllParentsAsync();

        // Ajouter un nouveau parent
        Task AddParentAsync(Parent parent);

        // Mettre à jour un parent
        Task UpdateParentAsync(int id, Parent updatedParent);

        // Supprimer un parent
        Task DeleteParentAsync(int id);

        
    }
}
