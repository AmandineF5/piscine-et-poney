namespace PiscineEtPoney.Domain.Entities
{
    public class ParentChild
    {
        public int ParentId { get; set; }
        public virtual Parent Parent { get; set; } = new Parent();

        public int ChildId { get; set; }
        public virtual Child Child { get; set; } = new Child();
    }
}
