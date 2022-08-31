using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.Dto;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.CustomerAccounts.Queries
{
    public class GetAllCustomerAccountByCustomerIdQuery : IRequestWrapper<List<CustomerAccountDto>>
    {
        public int CustomerId { get; set; }  
    }

    public class GetAllCustomerAccountByCustomerIdQueryHandler : IRequestHandlerWrapper<GetAllCustomerAccountByCustomerIdQuery, List<CustomerAccountDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllCustomerAccountByCustomerIdQueryHandler(IMapper mapper, IApplicationDbContext context)    
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResult<List<CustomerAccountDto>>> Handle(GetAllCustomerAccountByCustomerIdQuery request, CancellationToken cancellationToken)
        {
                
            var customerAccount = await _context.CustomerAccounts
                .Where(x => x.CustomerId == request.CustomerId)
                .ProjectToType<CustomerAccountDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return customerAccount != null ? ServiceResult.Success(customerAccount) : ServiceResult.Failed<List<CustomerAccountDto>>(ServiceError.NotFound);
        }
    }
}
