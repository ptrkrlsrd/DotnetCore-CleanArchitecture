using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Items.EventHandlers
{
    public class ItemCheckedEventHandler : INotificationHandler<DomainEventNotification<ItemCheckedEvent>>
    {
        private readonly ILogger<ItemCheckedEventHandler> _logger;

        public ItemCheckedEventHandler(ILogger<ItemCheckedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<ItemCheckedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
