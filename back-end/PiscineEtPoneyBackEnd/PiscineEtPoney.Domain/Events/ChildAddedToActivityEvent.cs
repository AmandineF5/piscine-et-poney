using PiscineEtPoney.Domain.Entities;

namespace PiscineEtPoney.Domain.Events
{
    public class ChildAddedToActivityEvent
    {
        public int ChildId { get; private set; }
        public int ActivityId { get; private set; }
        public DateTime Timestamp { get; private set; }

        public ChildAddedToActivityEvent(Child child, int activityId)
        {
            ChildId = child.Id;
            ActivityId = activityId;
            Timestamp = DateTime.UtcNow;
        }
    }
}
