using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.Model
{
    public partial class ProductModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> _productCategoryList;
        [ObservableProperty]
        private ObservableCollection<Product> _productList;
        [ObservableProperty]
        private string _product;
        [ObservableProperty]
        private bool _isLoading;
        [ObservableProperty]
        private bool _isVisible;
        private GetProductEndpoint _productEndpoint;
        public ProductModel() 
        { 
               _productEndpoint = new GetProductEndpoint();
        }

        public async Task<Result> GetProductList()
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                var response = await _productEndpoint.GetProductListAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var productData = JsonConvert.DeserializeObject<List<string>>(data);
                    ProductCategoryList = new ObservableCollection<string>(productData);
                    if (Product == null)
                    {
                        var responseEmptyCategory = await _productEndpoint.GetProducItemEmptyCategoryAsync();
                        if(responseEmptyCategory.IsSuccessStatusCode)
                        {
                            var dataEmptyCategory = await responseEmptyCategory.Content.ReadAsStringAsync();
                            var productEmptyItem = JsonConvert.DeserializeObject<GetProductCategory>(dataEmptyCategory);
                            ProductList = new ObservableCollection<Product>(productEmptyItem.Products);
                            IsLoading = false;
                            IsVisible = true;

                        }
                    }
                    else
                    {
                        _productEndpoint.ProductName = Product;
                        var responseItemCategory = await _productEndpoint.GetProducItemCategoryAsync();
                        if(responseItemCategory.IsSuccessStatusCode)
                        {
                            var dataCatergory = await responseItemCategory.Content.ReadAsStringAsync();
                            var productCategory = JsonConvert.DeserializeObject<GetProductCategory>(dataCatergory);
                            ProductList = new ObservableCollection<Product>( productCategory.Products);
                            IsLoading = false;
                            IsVisible = true;
                            
                        }
                    }
                        
                    
                    return new Result()
                    {
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new Result()
                    {
                        IsSuccess = false,
                        Message = "Something went wrong"

                    };
                }
            }
            else
            {

                return new Result()
                {
                    IsSuccess = false,
                    IsInternetError = true,
                    Message = "No Internet Connection"
                };
            }
        }
    }
}
