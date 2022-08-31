using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace MvcApiCall.Models
{
    class ApiHelper
    {
        public static async Task<string> ApiCall(Customer customer)
        {
            RestClient client = new RestClient("https://localhost:44308/api/");
            RestRequest request = new RestRequest("Customer", Method.POST);
            request.AddJsonBody(customer);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> GetToken(LoginRequest loginRequest)        
        {
            RestClient client = new RestClient("https://localhost:44308/api/");
            RestRequest request = new RestRequest("login", Method.POST);
            request.AddJsonBody(loginRequest);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> GetCustomers(LoginResponse loginResponse)    
        {

            RestClient client = new RestClient("https://localhost:44308/api/");
            RestRequest request = new RestRequest("customer", Method.GET);
            request.AddHeader("Authorization", "Bearer " + loginResponse.data.token);
            var response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }
    }
}