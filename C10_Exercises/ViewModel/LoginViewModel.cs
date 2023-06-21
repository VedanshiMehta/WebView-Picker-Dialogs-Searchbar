
using C10_Exercises.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _username;
        [ObservableProperty]
        private string _password;
        [ObservableProperty]
        private string _message;
        [ObservableProperty]
        private bool _isValid;
        [ObservableProperty]
        private LoginResponseModel _responseModel;
        [ObservableProperty]
        private bool _isPasswordHidden;
        [ObservableProperty]
        private ImageSource _passwordImage;

        private LoginModel _loginModel;
        public event EventHandler<Result> ResultEvent;
        public LoginViewModel() 
        { 
            _loginModel = new LoginModel();
            IsPasswordHidden = false;
            PasswordImage = "show";

        }
        [RelayCommand]
        public async void LoginUser()
        {
            _loginModel.Username = Username;
            _loginModel.Password = Password;
            var result = await _loginModel.PerformAction();
            ResultEvent?.Invoke(this, result);
            
        }
        [RelayCommand]
        public void HidePassword()
        {
            if(!IsPasswordHidden)
            {
                IsPasswordHidden = true;
                PasswordImage = "hide";
            }
            else
            {
                IsPasswordHidden = false;
                PasswordImage = "show";
            }
        }
    }
}
