using PiscineEtPoney.Application.Interfaces;
using PiscineEtPoney.Application.Interfaces.Repositories;
using PiscineEtPoney.Application.Interfaces.Services;
using PiscineEtPoney.Domain.Entities;

namespace PiscineEtPoney.Application.Services
{
    public class ParentService : IParentService
    {
        private readonly IParentRepository _parentRepository;

        public ParentService(IParentRepository parentRepository)
        {
            _parentRepository = parentRepository;
        }

        public async Task<Parent> GetParentByIdAsync(int id)
        {
            return await _parentRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Parent>> GetAllParentsAsync()
        {
            return await _parentRepository.GetAllAsync();
        }

        public async Task AddParentAsync(Parent parent)
        {
            // Exemple : validation métier avant d'ajouter un parent
            if (string.IsNullOrWhiteSpace(parent.Name))
            {
                throw new ArgumentException("Parent name cannot be empty.");
            }

            await _parentRepository.AddAsync(parent);
        }

        public async Task UpdateParentAsync(int id, Parent updatedParent)
        {
            var existingParent = await _parentRepository.GetByIdAsync(id);
            if (existingParent == null)
            {
                throw new InvalidOperationException("Parent not found.");
            }

            // Exemple : Mettre à jour seulement certains champs
            existingParent.Name = updatedParent.Name;
            existingParent.Email = updatedParent.Email;
            existingParent.Phone = updatedParent.Phone;

            await _parentRepository.UpdateAsync(existingParent);
        }

        public async Task DeleteParentAsync(int id)
        {
            await _parentRepository.DeleteAsync(id);
        }

        
    }
}
