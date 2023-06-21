using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.Interfaces
{
    public interface IProductApi
    {
        [Get("/products/categories")]
        Task<HttpResponseMessage> GetProductCategory();

        [Get("/products")]
        Task<HttpResponseMessage> GetProductItemEmptyCategory();


        [Get("/products/category/{category}")]
        Task<HttpResponseMessage> GetProductItemCategory(string category);
    }

}
