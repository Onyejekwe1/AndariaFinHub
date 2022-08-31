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
    public class GetCustomerAccountByIdQuery : IRequestWrapper<CustomerAccountDto>
    {
        public int CustomerAccountId { get; set; }  
    }

    public class GetCustomerAccountByIdQueryHandler : IRequestHandlerWrapper<GetCustomerAccountByIdQuery, CustomerAccountDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerAccountByIdQueryHandler(IMapper mapper, IApplicationDbContext context)    
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResult<CustomerAccountDto>> Handle(GetCustomerAccountByIdQuery request, CancellationToken cancellationToken)
        {
                
            var customerAccount = await _context.CustomerAccounts
                .Where(x => x.Id == request.CustomerAccountId)
                .Include(c => c.Customer)
                .ProjectToType<CustomerAccountDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return customerAccount != null ? ServiceResult.Success(customerAccount) : ServiceResult.Failed<CustomerAccountDto>(ServiceError.NotFound);
        }
    }
}
