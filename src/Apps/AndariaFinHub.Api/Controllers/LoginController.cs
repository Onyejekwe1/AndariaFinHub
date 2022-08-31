using System.Threading;
using System.Threading.Tasks;
using AndariaFinHub.Application.ApplicationUser.Queries.GetToken;
using AndariaFinHub.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AndariaFinHub.Api.Controllers
{
    /// <summary>
    /// Login
    /// </summary>
    public class LoginController : BaseApiController
    {
        /// <summary>
        /// Login and get JWT token email: andaria@test.com password: Matech_1850
        /// </summary>
        /// <param name="query"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<ServiceResult<LoginResponse>>> Login(GetTokenQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
