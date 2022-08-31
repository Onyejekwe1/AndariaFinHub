using AndariaFinHub.Application.Common.Helpers;
using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Domain.Entities;
using AndariaFinHub.Domain.Event;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.Customers.EventHandler
{
    public class CustomerCreatedEventHandler : INotificationHandler<DomainEventNotification<CustomerCreatedEvent>>
    {
        private readonly ILogger<CustomerCreatedEventHandler> _logger;
        private readonly IApplicationDbContext _context;

        public CustomerCreatedEventHandler(IIdentityService identityService, ILogger<CustomerCreatedEventHandler> logger, IApplicationDbContext context)
        {
            _identityService = identityService;
            _logger = logger;
            _context = context;
        }

        private readonly IIdentityService _identityService;

        public async Task Handle(DomainEventNotification<CustomerCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("AndariaFinHub AndariaFinHub.Domain Event: {DomainEvent}", domainEvent.GetType().Name);
            
            if (domainEvent.Customer != null)
            {
                var createdUser = await _identityService.CreateUserAsync(domainEvent.Customer.Username, domainEvent.Customer.EmailAddress, domainEvent.Customer.Password);

                if (createdUser.Result.Succeeded)
                {
                    var customerAccountEntity = new CustomerAccount
                    {
                        CustomerId = domainEvent.Customer.Id,
                        AccountNumber = AccountNumberGeneratorHelper.RandomNumString(10),
                        Balance = 0,
                        Currency = "EUR",
                        CreateDate = DateTime.UtcNow,
                        Customer = _context.Customers.FirstOrDefault(x => x.Id == domainEvent.Customer.Id)
                    };

                    await _context.CustomerAccounts.AddAsync(customerAccountEntity, cancellationToken);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
        }
    }
}
