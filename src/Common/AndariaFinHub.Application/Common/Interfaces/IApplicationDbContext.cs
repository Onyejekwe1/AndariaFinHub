using System.Threading;
using System.Threading.Tasks;
using AndariaFinHub.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerAccount> CustomerAccounts { get; set; }   

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
