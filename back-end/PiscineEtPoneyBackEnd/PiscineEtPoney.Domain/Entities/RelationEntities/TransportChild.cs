namespace PiscineEtPoney.Domain.Entities
{
    public class TransportChild
    {
        public int TransportId { get; set; }
        public virtual Transport Transport { get; set; }

        public int ChildId { get; set; }
        public virtual Child Child { get; set; }
    }
}