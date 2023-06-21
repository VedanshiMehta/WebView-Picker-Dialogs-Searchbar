using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises
{
    public class LoginEndPoints
    {
        public LoginRequestModel LoginRequest { get; set; } 

        public async Task<HttpResponseMessage> LoginUserAsync()
        {
            return await RestService.For<ILoginApi>("https://dummyjson.com/auth").LoginUser(LoginRequest);
        }
    }
}
