namespace PiscineEtPoney.Domain.Entities
{
    public class Parent
    {
        public int Id { get; set; }
        public string Name { get; set; } = "default";
        public string Email { get; set; } = "default";
        public string Phone { get; set; } = "default";
        public virtual List<Transport> Transports { get; set; } = new();
        public virtual List<ParentChild> ParentChildren { get; set; } = new List<ParentChild>();
    }
}
