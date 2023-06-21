using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises
{
    public class GetEmployeeEndpoint
    {
        public string Name { get; set; }
        public async Task<HttpResponseMessage> GetEmployeeAsync()
        {
            return await RestService.For<IEmployeeApi>("https://dummyjson.com").GetEmployeeList();
        }
        public async Task<HttpResponseMessage> GetSearchEmployeeListAsync()
        {
            return await RestService.For<IEmployeeApi>("https://dummyjson.com").GetSearchEmployeeList(Name);
        }
    }
}
