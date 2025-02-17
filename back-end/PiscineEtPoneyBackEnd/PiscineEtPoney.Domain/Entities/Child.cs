namespace PiscineEtPoney.Domain.Entities
{
    public class Child
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }

        // Liste des lieux où l'enfant peut être récupéré
        public virtual List<ChildPickupLocation> ChildPickupLocations { get; set; } = new();

        // Relation avec des Parent
        public virtual List<ParentChild> ParentChildren { get; set; } = new List<ParentChild>();

        // Relation Many-to-Many avec Activities
        public virtual List<ChildActivity> ChildActivities { get; set; } = new List<ChildActivity>();

        public virtual List<TransportChild> TransportChildren { get; set; } = new();

    }
}
