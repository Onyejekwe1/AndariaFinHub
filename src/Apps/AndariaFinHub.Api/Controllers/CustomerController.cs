using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.Customers.Commands.Create;
using AndariaFinHub.Application.Customers.Queries;
using AndariaFinHub.Application.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AndariaFinHub.Api.Controllers
{
    /// <summary>
    /// Customers
    /// </summary>
    [Authorize]
    public class CustomerController : BaseApiController
    {
        /// <summary>
        /// Create Customer
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<ServiceResult<CustomerDto>>> Create(CreateCustomerCommand command, CancellationToken cancellationToken)   
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Get all customers
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ServiceResult<List<CustomerDto>>>> GetAllCustomers(CancellationToken cancellationToken)  
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllCustomersQuery(), cancellationToken));
        }

        /// <summary>
        /// Get customer by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResult<CustomerDto>>> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { CustomerId = id }, cancellationToken));
        }
    }
}
