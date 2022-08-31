using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.CustomerAccounts.Commands.Create;
using AndariaFinHub.Application.CustomerAccounts.Commands.Update;
using AndariaFinHub.Application.CustomerAccounts.Queries;
using AndariaFinHub.Application.Customers.Commands.Create;
using AndariaFinHub.Application.Customers.Queries;
using AndariaFinHub.Application.Districts.Queries;
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
    public class CustomerAccountController : BaseApiController  
    {
        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("CreateAccount")]
        public async Task<ActionResult<ServiceResult<CustomerAccountDto>>> Create(CreateCustomerAccountCommand command, CancellationToken cancellationToken)   
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("CreditAccount")]
        public async Task<ActionResult<ServiceResult<CustomerAccountDto>>> CreditAccount(CreditAccountCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("DebitAccount")]
        public async Task<ActionResult<ServiceResult<CustomerAccountDto>>> DebitAccount(DebitAccountCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Create Account
        /// </summary>
        /// <param name="command"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("Fx")]
        public async Task<ActionResult<ServiceResult<CustomerAccountDto>>> FxTransaction(FxConversionCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        /// <summary>
        /// Get all customer accounts
        /// </summary>
        /// /// <param name="customerId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpGet("AllCustomerAccounts")]
        public async Task<ActionResult<ServiceResult<List<CustomerDto>>>> GetAllCustomerAccounts(int customerId, CancellationToken cancellationToken)   
        {
            //Cancellation token example.
            return Ok(await Mediator.Send(new GetAllCustomerAccountByCustomerIdQuery { CustomerId = customerId }, cancellationToken));
        }

        /// <summary>
        /// Get district by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("TransactionReport")]
        public async Task<FileResult> Get(int id, CancellationToken cancellationToken)
        {
            var vm = await Mediator.Send(new ExportCustomerAccountStatementQuery { CustomerId = id }, cancellationToken);

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        /// <summary>
        /// Get Account by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("AccountById")]
        public async Task<ActionResult<ServiceResult<CustomerDto>>> GetCustomerAccountById(int id, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new GetCustomerAccountByIdQuery { CustomerAccountId = id }, cancellationToken));
        }
    }
}
