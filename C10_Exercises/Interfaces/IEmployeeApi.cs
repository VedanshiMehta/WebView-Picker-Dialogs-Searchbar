using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises
{
    public interface IEmployeeApi
    {
        [Get("/users")]
        Task<HttpResponseMessage> GetEmployeeList();

        [Get("/users/search?q={name}")]
        Task<HttpResponseMessage> GetSearchEmployeeList(string name);
    }
}
