using System.Threading.Tasks;
using AndariaFinHub.Application.Common.Models;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(EmailRequest request);
    }
}
