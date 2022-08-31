using System.Threading;
using System.Threading.Tasks;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Domain.Enums;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}