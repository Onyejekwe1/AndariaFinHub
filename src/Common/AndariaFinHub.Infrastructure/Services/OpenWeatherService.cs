using System.Threading;
using System.Threading.Tasks;
using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Common.Mapping;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.ExternalServices.OpenWeather.Request;
using AndariaFinHub.Application.ExternalServices.OpenWeather.Response;
using AndariaFinHub.Domain.Enums;

namespace AndariaFinHub.Infrastructure.Services
{
    public class OpenWeatherService : IOpenWeatherService
    {
        private readonly IHttpClientHandler _httpClient;

        private string ClientApi { get; } = "open-weather-api";

        public OpenWeatherService(IHttpClientHandler httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ServiceResult<OpenWeatherResponse>> GetCurrentWeatherForecast(OpenWeatherRequest request, CancellationToken cancellationToken)
        {
            return await _httpClient.GenericRequest<OpenWeatherRequest, OpenWeatherResponse>(ClientApi, string.Concat("weather?", StringExtensions
                .ParseObjectToQueryString(request, true)), cancellationToken, MethodType.Get, request);
        }
    }
}