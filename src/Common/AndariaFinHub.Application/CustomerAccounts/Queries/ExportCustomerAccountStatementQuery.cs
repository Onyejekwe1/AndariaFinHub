using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Common.Security;
using AndariaFinHub.Application.Dto;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AndariaFinHub.Application.Districts.Queries
{
    [Authorize(Roles = "Administrator")]
    public class ExportCustomerAccountStatementQuery : IRequest<ExportDto>
    {
        public int CustomerId { get; set; } 
    }

    public class ExportCustomerAccountStatementQueryHandler : IRequestHandler<ExportCustomerAccountStatementQuery, ExportDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ICsvFileBuilder _fileBuilder;

        public ExportCustomerAccountStatementQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
        {
            _context = context;
            _mapper = mapper;
            _fileBuilder = fileBuilder;
        }

        public async Task<ExportDto> Handle(ExportCustomerAccountStatementQuery request, CancellationToken cancellationToken)
        {
            var result = new ExportDto();

            var records = await _context.CustomerAccounts
                .Where(t => t.CustomerId == request.CustomerId)
                .ProjectToType<CustomerAccountDto>(_mapper.Config)
                .ToListAsync(cancellationToken);

            result.Content = _fileBuilder.BuildAccountTransactionsFile(records);
            result.ContentType = "text/csv";
            result.FileName = "Transactions.csv";

            return await Task.FromResult(result);
        }
    }
}
