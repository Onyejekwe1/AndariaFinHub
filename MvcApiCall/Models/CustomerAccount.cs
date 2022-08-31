using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiCall.Models
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
    }
}
