using C10_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.ViewModel
{
    public partial class GetEmployeeViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<User> _employeeLists;
        [ObservableProperty]
        private bool _isLoading;
        [ObservableProperty]
        private bool _isVisible;
        private EmployeeModel _employeeModel;
        [ObservableProperty]
        private string _employeeSearch;

        public GetEmployeeViewModel()
        {

            _employeeModel = new EmployeeModel();
            IsLoading = true;
            IsVisible = false;
            _ = GetEmployeeListAsync();
            
            
        }

        public async Task GetEmployeeListAsync()
        {
            
            await Task.Delay(1000);
            await _employeeModel.GetEmployeeList();
            EmployeeLists = _employeeModel.EmployeeList;
            IsVisible = _employeeModel.IsVisible;
            IsLoading = _employeeModel.IsLoading;

        }

        [RelayCommand]
        public async Task GetSearchEmployee(string employee)
        {
            EmployeeSearch = employee;
            _employeeModel.IsLoading = IsLoading;
            _employeeModel.IsVisible = IsVisible;
            _employeeModel.EmployeeSearch = employee;
            if(!string.IsNullOrEmpty(EmployeeSearch))
            {
                await Task.Delay(1000);
                await _employeeModel.GetSearchEmployeeList();
                EmployeeLists = _employeeModel.EmployeeList;
                IsVisible = _employeeModel.IsVisible;
                IsLoading = _employeeModel.IsLoading;
            }
           

        }
    }
}
