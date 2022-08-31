using AndariaFinHub.Application.Dto;
using AndariaFinHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface ICustomerAccountService
    {
        Task<CustomerAccountDto> CreateAccountAsync(CustomerAccount customerAccount);
    }
}
