using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Domain.Events
{
    public class ItemCreatedEvent : DomainEvent
    {
        public ItemCreatedEvent(Item item)
        {
            CreatedItem = item;
        }

        public Item CreatedItem { get; }
    }
}
