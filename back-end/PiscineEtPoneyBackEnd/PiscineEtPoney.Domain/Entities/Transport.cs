using PiscineEtPoney.Domain.Enums;

namespace PiscineEtPoney.Domain.Entities
{
    public class Transport
    {
        public int Id { get; set; }

        public TransportType type { get; set; }
        
        // Relation avec Parent
        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; }

        // Relation avec Activity
        public int ActivityId { get; set; }
        public virtual Activity Activity { get; set; }

        // Relation Many-to-Many avec Child via une table intermédiaire
        public virtual List<TransportChild> TransportChildren { get; set; } = new();
    }
}