using C10_Exercises.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises
{
    public class GetProductEndpoint
    {
        public string ProductName { get; set; }
        public async Task<HttpResponseMessage> GetProductListAsync()
        {
            return await RestService.For<IProductApi>("https://dummyjson.com/").GetProductCategory();
        }
        public async Task<HttpResponseMessage> GetProducItemEmptyCategoryAsync()
        {
            return await RestService.For<IProductApi>("https://dummyjson.com/").GetProductItemEmptyCategory();
        }

        public async Task<HttpResponseMessage> GetProducItemCategoryAsync()
        {
            return await RestService.For<IProductApi>("https://dummyjson.com/").GetProductItemCategory(ProductName);
        }
    }
}
