using System.Collections.Generic;
using AndariaFinHub.Application.Dto;

namespace AndariaFinHub.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildAccountTransactionsFile(IEnumerable<CustomerAccountDto> customerAccounts);  
    }
}
