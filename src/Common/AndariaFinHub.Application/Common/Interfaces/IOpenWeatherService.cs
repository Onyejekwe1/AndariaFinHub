using System.Threading;
using System.Threading.Tasks;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.ExternalServices.OpenWeather.Request;
using AndariaFinHub.Application.ExternalServices.OpenWeather.Response;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface IOpenWeatherService
    {
        Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request,
            CancellationToken cancellationToken);
    }
}