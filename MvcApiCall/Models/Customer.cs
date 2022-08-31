using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcApiCall.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public IList<CustomerAccount> CustomerAccounts { get; set; }

        public static Response AddCustomer(Customer customer)  
        {
            var apiCallTask = ApiHelper.ApiCall(customer);
            var result = apiCallTask.Result;

            var output = JsonConvert.DeserializeObject<Response>(result);
            return output;
        }

        public static CustomerListResponse.Root GetCustomers()     
        {
            var apiCallTask = ApiHelper.GetToken(new LoginRequest{email = "test@test.com", password = "Matech_1850" });
            var result = apiCallTask.Result;
            var tokenResult = apiCallTask.Result;

            var token = JsonConvert.DeserializeObject<LoginResponse>(result);

            var getCustomer = ApiHelper.GetCustomers(token);
            var customerResult = getCustomer.Result;

            var output = JsonConvert.DeserializeObject<CustomerListResponse.Root>(customerResult); 
            return output;
        }
    }
}
