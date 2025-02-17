using Microsoft.EntityFrameworkCore;
using PiscineEtPoney.Application.Interfaces.Repositories;
using PiscineEtPoney.Domain.Entities;
using PiscineEtPoney.Infrastructure.Persistence;

public class ChildRepository : IChildRepository
{
    private readonly ApplicationDbContext _context;

    public ChildRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    // Récupérer tous les enfants avec leurs relations associées
    public async Task<List<Child>> GetAllAsync()
    {
        return await _context.Children
            .Include(c => c.ChildPickupLocations)
                .ThenInclude(cpl => cpl.PickupLocation)
            .Include(c => c.ParentChildren)
                .ThenInclude(pc => pc.Parent)
            .Include(c => c.ChildActivities)
                .ThenInclude(ca => ca.Activity)
            .Include(c => c.TransportChildren)
                .ThenInclude(tc => tc.Transport)
            .ToListAsync();
    }

    // Récupérer un enfant par son ID avec ses relations associées
    public async Task<Child?> GetByIdAsync(int id)
    {
        return await _context.Children
            .Include(c => c.ChildPickupLocations)
                .ThenInclude(cpl => cpl.PickupLocation)
            .Include(c => c.ParentChildren)
                .ThenInclude(pc => pc.Parent)
            .Include(c => c.ChildActivities)
                .ThenInclude(ca => ca.Activity)
            .Include(c => c.TransportChildren)
                .ThenInclude(tc => tc.Transport)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    // Ajouter un nouvel enfant
    public async Task<Child> AddAsync(Child child)
    {
        await _context.Children.AddAsync(child);
        await _context.SaveChangesAsync();
        return child;
    }

    // Mettre à jour un enfant
    public async Task UpdateAsync(Child child)
    {
        _context.Children.Update(child);
        await _context.SaveChangesAsync();
    }

    // Supprimer un enfant par son ID
    public async Task DeleteAsync(int id)
    {
        var child = await _context.Children.FindAsync(id);
        if (child != null)
        {
            _context.Children.Remove(child);
            await _context.SaveChangesAsync();
        }
    }
}
