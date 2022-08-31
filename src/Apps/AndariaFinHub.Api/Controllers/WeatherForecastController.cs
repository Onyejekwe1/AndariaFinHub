using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.Dto;
using AndariaFinHub.Application.WeatherForecasts.Queries.GetCurrentWeatherForecastQuery;
using AndariaFinHub.Application.WeatherForecasts.Queries.GetWeatherForecastQuery;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AndariaFinHub.Api.Controllers
{
    /// <summary>
    /// Weather Forecast
    /// </summary>
    public class WeatherForecastController : BaseApiController
    {
        /// <summary>
        /// Basic and static weather forecast
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }

        /// <summary>
        /// Get current forecast from open weather services.
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("current")]
        public async Task<ActionResult<ServiceResult<CurrentWeatherForecastDto>>> GetCurrentWeather([FromQuery] GetCurrentWeatherForecastQuery query, CancellationToken cancellationToken)
        {
            return await Mediator.Send(query, cancellationToken);
        }
    }
}
