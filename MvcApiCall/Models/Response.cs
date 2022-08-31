using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiCall.Models
{

    public class ApiResponse
    {   
        public int id { get; set; }
        public string idNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime dateOfBirth { get; set; }
        public string emailAddress { get; set; }
        public string username { get; set; }
        public string createDate { get; set; }
        public bool active { get; set; }
        public List<CustomerAccount> customerAccounts { get; set; }
    }

    public class Response
    {
        public ApiResponse data { get; set; }
        public bool succeeded { get; set; }
        public object error { get; set; }
    }

}
