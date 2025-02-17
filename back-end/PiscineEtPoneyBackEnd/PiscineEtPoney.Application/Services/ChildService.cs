using System.Collections.Generic;
using System.Threading.Tasks;
using PiscineEtPoney.Application.Interfaces;
using PiscineEtPoney.Application.Interfaces.Repositories;
using PiscineEtPoney.Application.Interfaces.Services;
using PiscineEtPoney.Domain.Entities;

namespace PiscineEtPoney.Application.Services
{
    public class ChildService : IChildService
    {
        private readonly IChildRepository _childRepository;
        private readonly IParentService _parentService;

        public ChildService(IChildRepository childRepository, IParentService parentService)
        {
            _childRepository = childRepository;
            _parentService = parentService;
        }

        public async Task<Child> GetChildByIdAsync(int id)
        {
            return await _childRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Child>> GetAllChildrenAsync()
        {
            return await _childRepository.GetAllAsync();
        }

        public async Task<Child> AddChildAsync(Child child)
        {
            // Exemple : validation métier avant d'ajouter un child
            if (string.IsNullOrWhiteSpace(child.Name))
            {
                throw new ArgumentException("Child name cannot be empty.");
            }

            return await _childRepository.AddAsync(child);
        }

        public async Task UpdateChildAsync(int id, Child updatedChild)
        {
            var existingChild = await _childRepository.GetByIdAsync(id);
            if (existingChild == null) return;

            existingChild.Name = updatedChild.Name;
            existingChild.Age = updatedChild.Age;

            // MAJ des relations Many-to-Many

            /// MAJ des lieux de récupération
            existingChild.ChildPickupLocations.Clear();
            foreach (var cpl in updatedChild.ChildPickupLocations)
            {
                existingChild.ChildPickupLocations.Add(new ChildPickupLocation
                {
                    ChildId = id,
                    PickupLocationId = cpl.PickupLocationId
                });
            }

            /// MAJ des parents liés à l'enfant
            existingChild.ParentChildren.Clear();
            foreach (var pc in updatedChild.ParentChildren)
            {
                existingChild.ParentChildren.Add(new ParentChild
                {
                    ChildId = id,
                    ParentId = pc.ParentId
                });
            }

            /// MAJ des activités de l'enfant
            existingChild.ChildActivities.Clear();
            foreach (var ca in updatedChild.ChildActivities)
            {
                existingChild.ChildActivities.Add(new ChildActivity
                {
                    ChildId = id,
                    ActivityId = ca.ActivityId
                });
            }

            /// MAJ des transports de l'enfant
            existingChild.TransportChildren.Clear();
            foreach (var tc in updatedChild.TransportChildren)
            {
                existingChild.TransportChildren.Add(new TransportChild
                {
                    ChildId = id,
                    TransportId = tc.TransportId
                });
            }

            await _childRepository.UpdateAsync(existingChild);
        }

        public async Task DeleteChildAsync(int id)
        {
            await _childRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Parent>> GetParentsByChildIdAsync(int childId)
        {
            var child = await _childRepository.GetByIdAsync(childId);
            if (child == null)
            {
                throw new InvalidOperationException("Child not found.");
            }

            var parentChildren = child.ParentChildren;
            var parentIds = new List<int>();
            foreach(ParentChild parentChild in parentChildren){
                parentIds.Add(parentChild.ParentId);
            }
            var parents = new List<Parent>();
            foreach(int parentId in parentIds){
                var parent = await _parentService.GetParentByIdAsync(childId);
                if (parent == null){
                    throw new InvalidOperationException("Child not found.");
                } else {
                    parents.Add(parent);
                }
            }

            return parents;
        }
    }

        
}

