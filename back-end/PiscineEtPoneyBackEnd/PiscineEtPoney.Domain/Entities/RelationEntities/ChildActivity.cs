namespace PiscineEtPoney.Domain.Entities;
public class ChildActivity
{
    public int ChildId { get; set; }
    public virtual Child Child { get; set; }

    public int ActivityId { get; set; }
    public virtual Activity Activity { get; set; }
}