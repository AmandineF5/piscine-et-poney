
namespace PiscineEtPoney.Domain.Entities;
public class ChildPickupLocation
{
    public int ChildId { get; set; }
    public virtual Child Child { get; set; }

    public int PickupLocationId { get; set; }
    public virtual PickupLocation PickupLocation { get; set; }
}