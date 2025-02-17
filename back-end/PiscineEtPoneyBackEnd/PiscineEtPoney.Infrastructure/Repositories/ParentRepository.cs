
using Microsoft.EntityFrameworkCore;
using PiscineEtPoney.Application.Interfaces.Repositories;
using PiscineEtPoney.Domain.Entities;
using PiscineEtPoney.Infrastructure.Persistence;

namespace PiscineEtPoney.Infrastructure.Repositories
{
    public class ParentRepository : IParentRepository
    {
        private readonly ApplicationDbContext _context;

        public ParentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Parent> GetByIdAsync(int id)
        {
            return await _context.Parents
                .Include(p => p.Transports)
                .FirstAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Parent>> GetAllAsync()
        {
            return await _context.Parents
                .Include(p => p.Transports)
                .ToListAsync();
        }

        public async Task AddAsync(Parent parent)
        {
            await _context.Parents.AddAsync(parent);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Parent parent)
        {
            _context.Parents.Update(parent);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var parent = await GetByIdAsync(id);
            if (parent != null)
            {
                _context.Parents.Remove(parent);
                await _context.SaveChangesAsync();
            }
        }

    }
}
