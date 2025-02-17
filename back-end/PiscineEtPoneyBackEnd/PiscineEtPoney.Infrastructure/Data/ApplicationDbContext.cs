
using PiscineEtPoney.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace PiscineEtPoney.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Déclarer les DbSets pour chaque entité
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<ParentChild> ParentChildren { get; set; }
        public DbSet<Transport> Transports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration des relations et des contraintes via Fluent API

            modelBuilder.Entity<ParentChild>()
                .HasKey(pc => new { pc.ParentId, pc.ChildId });

            modelBuilder.Entity<ParentChild>()
                .HasOne(pc => pc.Child)
                .WithMany(c => c.ParentChildren)
                .HasForeignKey(pc => pc.ChildId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChildPickupLocation>()
                .HasKey(cpl => new { cpl.ChildId, cpl.PickupLocationId });

             modelBuilder.Entity<ChildPickupLocation>()
                .HasOne(cpl => cpl.Child)
                .WithMany(c => c.ChildPickupLocations)
                .HasForeignKey(cpl => cpl.ChildId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChildPickupLocation>()
                .HasOne(cpl => cpl.PickupLocation)
                .WithMany(pl => pl.ChildPickupLocations)
                .HasForeignKey(cpl => cpl.PickupLocationId)
                .OnDelete(DeleteBehavior.Cascade);

            // 🔹 Relation Many-to-Many entre Child et Activity via ChildActivity
            modelBuilder.Entity<ChildActivity>()
                .HasKey(ca => new { ca.ChildId, ca.ActivityId });

            modelBuilder.Entity<ChildActivity>()
                .HasOne(ca => ca.Child)
                .WithMany(c => c.ChildActivities)
                .HasForeignKey(ca => ca.ChildId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ChildActivity>()
                .HasOne(ca => ca.Activity)
                .WithMany(a => a.ChildActivities)
                .HasForeignKey(ca => ca.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relation One-to-Many : Un Parent a plusieurs Transports
            modelBuilder.Entity<Transport>()
                .HasOne(t => t.Parent)
                .WithMany(p => p.Transports)
                .HasForeignKey(t => t.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation One-to-Many : Une Activity a plusieurs Transports
            modelBuilder.Entity<Transport>()
                .HasOne(t => t.Activity)
                .WithMany(a => a.Transports)
                .HasForeignKey(t => t.ActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relation Many-to-Many entre Transport et Child via TransportChild
            modelBuilder.Entity<TransportChild>()
                .HasKey(tc => new { tc.TransportId, tc.ChildId });

            modelBuilder.Entity<TransportChild>()
                .HasOne(tc => tc.Transport)
                .WithMany(t => t.TransportChildren)
                .HasForeignKey(tc => tc.TransportId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransportChild>()
                .HasOne(tc => tc.Child)
                .WithMany(c => c.TransportChildren)
                .HasForeignKey(tc => tc.ChildId)
                .OnDelete(DeleteBehavior.Cascade);
                }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
