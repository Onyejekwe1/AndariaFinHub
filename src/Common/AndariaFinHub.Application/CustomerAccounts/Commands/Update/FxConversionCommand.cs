using AndariaFinHub.Application.Common.Exceptions;
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
    public class FxConversionCommand : IRequestWrapper<CustomerAccountDto>
    {
        //I'm assuming that the source account will always be EUR
        public int SourceCustomerAccountId { get; set; }
        public int DestinationCustomerAccountId { get; set; }  
        public decimal Amount { get; set; } 
    }

    public class FxConversionCommandHandler : IRequestHandlerWrapper<FxConversionCommand, CustomerAccountDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IFXConversionService _fXConversionService; 
        private readonly IMapper _mapper;

        public FxConversionCommandHandler(IApplicationDbContext context, IMapper mapper, IFXConversionService fXConversionService)
        {
            _context = context;
            _mapper = mapper;
            _fXConversionService = fXConversionService;
        }


        public async Task<ServiceResult<CustomerAccountDto>> Handle(FxConversionCommand request, CancellationToken cancellationToken)
        {
            var sourceAccount = _context.CustomerAccounts.FirstOrDefault(x => x.Id == request.SourceCustomerAccountId);

            var destinationAccount = _context.CustomerAccounts.FirstOrDefault(x => x.Id == request.DestinationCustomerAccountId);
            if (sourceAccount == null || destinationAccount == null)
            {
                throw new NotFoundException(nameof(CustomerAccount));
            }
            
            sourceAccount.Balance -= request.Amount;

            destinationAccount.Balance += destinationAccount.Currency == "USD" 
                ? _fXConversionService.EuroToUsd(request.Amount) 
                : _fXConversionService.EuroToGbp(request.Amount);

            await _context.SaveChangesAsync(cancellationToken);

            return ServiceResult.Success(_mapper.Map<CustomerAccountDto>(destinationAccount));
        }
    }
}
