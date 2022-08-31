using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcApiCall.Models
{
    public class LoginRequest
    {
        public string email { get; set; }
        public string password { get; set; }    
    }

    public class ResponseData   
    {
        public User user { get; set; }
        public string token { get; set; }
    }

    public class LoginResponse  
    {
        public ResponseData data { get; set; }
        public bool succeeded { get; set; }
        public object error { get; set; }
    }

    public class User
    {
        public string id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
    }
}
