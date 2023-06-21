using C10_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.ViewModel
{
    public partial class GetProductViewModel: ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> productsCategory;
        [ObservableProperty]
        private ObservableCollection<Product> products;
        [ObservableProperty]
        private string _product;
        [ObservableProperty]
        private bool _isLoading;
        [ObservableProperty]
        private bool _isVisible;

        private ProductModel _productModel;

        public GetProductViewModel()
        {
            _productModel = new ProductModel();
            IsLoading = true;
            IsVisible = false;
            _ = GetProductListAsync();

        }

        public async Task GetProductListAsync()
        {
            _productModel.Product = Product;
            await _productModel.GetProductList();
            ProductsCategory = _productModel.ProductCategoryList;
            Products = _productModel.ProductList;
            IsVisible = _productModel.IsVisible;
            IsLoading = _productModel.IsLoading;
        }
    }
}
