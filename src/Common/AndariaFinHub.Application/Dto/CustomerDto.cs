using AndariaFinHub.Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.Dto
{
    public class CustomerDto : IRegister
    {
        public CustomerDto()
        {
            CustomerAccounts = new List<CustomerAccountDto>();
        }

        public int Id { get; set; }

        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }

        public string CreateDate { get; set; }

        public bool Active { get; set; }

        public IList<CustomerAccountDto> CustomerAccounts { get; set; }    

        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Customer, CustomerDto>()
            .Map(dest => dest.CreateDate,
                src => $"{src.CreateDate.ToShortDateString()}");
        }
    }
}
