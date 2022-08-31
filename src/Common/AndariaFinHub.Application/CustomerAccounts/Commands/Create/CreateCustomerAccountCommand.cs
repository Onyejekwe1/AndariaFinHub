using AndariaFinHub.Application.Common.Helpers;
using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.Dto;
using AndariaFinHub.Domain.Entities;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.CustomerAccounts.Commands.Create
{
    public class CreateCustomerAccountCommand : IRequestWrapper<CustomerAccountDto>
    {
        public string Currency { get; set; }
        public int CustomerId { get; set; }
    }

    public class CreateCustomerAccountCommandHandler : IRequestHandlerWrapper<CreateCustomerAccountCommand, CustomerAccountDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerAccountCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CustomerAccountDto>> Handle(CreateCustomerAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = new CustomerAccount
            {
                AccountNumber = AccountNumberGeneratorHelper.RandomNumString(10),
                Balance = 0,
                CustomerId = request.CustomerId,
                Currency = request.Currency,
            };

            await _context.CustomerAccounts.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success(_mapper.Map<CustomerAccountDto>(entity));
        }
    }
}
