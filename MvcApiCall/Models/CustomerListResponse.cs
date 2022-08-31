using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiCall.Models
{
    public class CustomerListResponse
    {
        public class Root
        {
            public List<Customer> data { get; set; }
            public bool succeeded { get; set; }
            public object error { get; set; }
        }
        public class CustomerAccount
        {
            public int id { get; set; }
            public string accountNumber { get; set; }
            public string currency { get; set; }
            public int balance { get; set; }
            public int customerId { get; set; }
            public object customerDto { get; set; }
        }
    }
}
