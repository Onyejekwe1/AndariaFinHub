using AndariaFinHub.Application.Common.Interfaces;
using AndariaFinHub.Application.Common.Models;
using AndariaFinHub.Application.Dto;
using AndariaFinHub.Domain.Entities;
using AndariaFinHub.Domain.Event;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.Customers.Commands.Create
{
    public class CreateCustomerCommand : IRequestWrapper<CustomerDto>
    {
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }    
    }

    public class CreateCustomerCommandHandler : IRequestHandlerWrapper<CreateCustomerCommand, CustomerDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                DateOfBirth = request.DateOfBirth,
                IdNumber = request.IdNumber,
                EmailAddress = request.EmailAddress,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Password = request.Password,
                Username = request.Username,
            };

            entity.DomainEvents.Add(new CustomerCreatedEvent(entity));
            await _context.Customers.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return ServiceResult.Success(_mapper.Map<CustomerDto>(entity));
        }
    }
}
