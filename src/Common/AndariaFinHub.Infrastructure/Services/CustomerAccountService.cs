using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Dto;
using AndariaFinHub.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace AndariaFinHub.Infrastructure.Services
{
    public class CustomerAccountService : ICustomerAccountService
    {
        public Task<CustomerAccountDto> CreateAccountAsync(CustomerAccount customerAccount)
        {
            throw new NotImplementedException();
        }
    }
}
