using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Events;
using System;
using System.Collections.Generic;

namespace CleanArchitecture.Domain.Entities
{
    public class Item : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }

        public String Name { get; set; }
        private bool _checked;
        public bool Checked
        {
            get => _checked;
            set
            {
                if (value && !_checked)
                {
                    DomainEvents.Add(new ItemCheckedEvent(this));
                }

                _checked = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
    }
}
