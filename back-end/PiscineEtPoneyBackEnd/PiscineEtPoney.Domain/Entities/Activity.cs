namespace PiscineEtPoney.Domain.Entities
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "default";
        public DateTime Schedule { get; set; }
        public string Address { get; set; } = "default";
        public virtual List<ChildActivity> ChildActivities { get; set; } = new List<ChildActivity>();
        public virtual List<Transport> Transports { get; set; } = new();
    }
}



