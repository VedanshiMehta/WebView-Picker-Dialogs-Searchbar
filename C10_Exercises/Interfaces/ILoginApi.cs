using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises
{
    public interface ILoginApi
    {
        [Post("/login")]
        Task<HttpResponseMessage> LoginUser([Body] LoginRequestModel loginRequestModel);

    }
}
