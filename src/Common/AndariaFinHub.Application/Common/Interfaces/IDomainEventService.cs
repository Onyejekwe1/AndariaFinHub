using System.Threading.Tasks;
using AndariaFinHub.Domain.Common;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
