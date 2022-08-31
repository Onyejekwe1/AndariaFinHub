﻿using AndariaFinHub.Application.Common.Exceptions;
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

namespace AndariaFinHub.Application.CustomerAccounts.Commands.Update
{
    public class CreditAccountCommand : IRequestWrapper<CustomerAccountDto>
    {
        public int CustomerId { get; set; }
        public int CustomerAccountId { get; set; }  
        public decimal Amount { get; set; } 
    }

    public class CreditAccountCommandHandler : IRequestHandlerWrapper<CreditAccountCommand, CustomerAccountDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreditAccountCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ServiceResult<CustomerAccountDto>> Handle(CreditAccountCommand request, CancellationToken cancellationToken)
        {
            var entity = _context.CustomerAccounts.FirstOrDefault(x => x.Id == request.CustomerAccountId && x.CustomerId == request.CustomerId);

            if (entity == null)
            {
                throw new NotFoundException(nameof(CustomerAccount), request.CustomerId);
            }
            
            entity.Balance += request.Amount;

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CustomerAccountDto>(entity));
        }
    }
}
