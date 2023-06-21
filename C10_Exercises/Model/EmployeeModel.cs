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
    public partial class EmployeeModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<User> _employeeList;
        [ObservableProperty]
        private bool _isLoading;
        [ObservableProperty]
        private bool _isVisible;

        [ObservableProperty]
        private string _employeeSearch;
        private GetEmployeeEndpoint _getEmployeeEndpoint;

        public EmployeeModel()
        {
            _getEmployeeEndpoint = new GetEmployeeEndpoint();
        }

        public async Task<Result> GetEmployeeList()
        {

            if(CrossConnectivity.Current.IsConnected)
            {
                var response = await _getEmployeeEndpoint.GetEmployeeAsync();
                if(response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var employeeData = JsonConvert.DeserializeObject<EmployeeResponseModel>(data);
                    EmployeeList = new ObservableCollection<User>(employeeData.Users);
                    IsLoading = false;
                    IsVisible = true;
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
        public async Task<Result> GetSearchEmployeeList()
        {

            if (CrossConnectivity.Current.IsConnected)
            {
                _getEmployeeEndpoint.Name = EmployeeSearch;
                var response = await _getEmployeeEndpoint.GetSearchEmployeeListAsync();
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var employeeData = JsonConvert.DeserializeObject<EmployeeResponseModel>(data);
                    EmployeeList = new ObservableCollection<User>(employeeData.Users);
                    IsLoading = false;
                    IsVisible = true;
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
