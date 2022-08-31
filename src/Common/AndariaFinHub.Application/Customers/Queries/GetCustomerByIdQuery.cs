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

namespace AndariaFinHub.Application.Customers.Queries
{
    public class GetCustomerByIdQuery : IRequestWrapper<CustomerDto>
    {
        public int CustomerId { get; set; } 
    }

    public class GetCustomerByIdHandler : IRequestHandlerWrapper<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomerByIdHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<ServiceResult<CustomerDto>> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                .Where(x => x.Id == request.CustomerId)
                .Include(d => d.CustomerAccounts)
                .ProjectToType<CustomerDto>(_mapper.Config)
                .FirstOrDefaultAsync(cancellationToken);

            return customer != null ? ServiceResult.Success(customer) : ServiceResult.Failed<CustomerDto>(ServiceError.NotFound);
        }
    }
}
