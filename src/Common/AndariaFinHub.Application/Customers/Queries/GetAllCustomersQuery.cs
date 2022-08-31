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
    public class GetAllCustomersQuery : IRequestWrapper<List<CustomerDto>>
    {
    }

    public class GetCustomersQueryHandler : IRequestHandlerWrapper<GetAllCustomersQuery, List<CustomerDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCustomersQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<CustomerDto>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            List<CustomerDto> result = await _context.Customers
                .Include(x => x.CustomerAccounts)
                .ProjectToType<CustomerDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            return result.Count > 0 ? ServiceResult.Success(result) : ServiceResult.Failed<List<CustomerDto>>(ServiceError.NotFound);
        }
    }
}
