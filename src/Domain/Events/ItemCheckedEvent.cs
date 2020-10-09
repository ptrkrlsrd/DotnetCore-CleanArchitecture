using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events
{
    public class ItemCheckedEvent : DomainEvent
    {
        public ItemCheckedEvent(Item item)
        {
            CheckedItem = item;
        }

        public Item CheckedItem { get; }
    }
}
