namespace PiscineEtPoney.Domain.Entities
{
    public class PickupLocation
    {
        public int Id { get; set; }
        public string Name { get; set; } = "default";
        public string Address { get; set; } = "default";
        public virtual List<ChildPickupLocation> ChildPickupLocations { get; set; } = new();

    }
}