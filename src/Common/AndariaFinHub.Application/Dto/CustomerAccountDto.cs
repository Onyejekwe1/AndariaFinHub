using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndariaFinHub.Application.Dto
{
    public class CustomerAccountDto
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        public CustomerDto CustomerDto { get; set; }    
    }
}
