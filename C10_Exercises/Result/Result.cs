using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public bool IsInternetError { get; set; }
        public LoginResponseModel LoginResponse { get; set; }
    }
}
