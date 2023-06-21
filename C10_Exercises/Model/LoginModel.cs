using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace C10_Exercises.Model
{
    public partial class LoginModel : ObservableObject
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
        private LoginResponseModel _loginResponseData;

        private LoginEndPoints _endPoints;
        private Validate _validate;

        public LoginModel()
        {
            _endPoints = new LoginEndPoints();
            _validate = new Validate();
        }
        public async Task<Result> PerformAction()
        {
            _validate.ValidateLoginClass(this);
            if (_validate.IsValid)
            {
                if (CrossConnectivity.Current.IsConnected)
                {

                    var requestModel = new LoginRequestModel()
                    {
                        Username = Username,
                        Password = Password,
                    };
                    _endPoints.LoginRequest = requestModel;
                       var response = await _endPoints.LoginUserAsync();
                        if (response.IsSuccessStatusCode)
                        {
                            var data = await response.Content.ReadAsStringAsync();
                            var responseData = JsonConvert.DeserializeObject<LoginResponseModel>(data);
                            LoginResponseData = responseData;
                            return new Result()
                            {
                                IsSuccess = true,
                                Message = "Login Successfull",
                                LoginResponse= LoginResponseData,
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
            else
            {
                return new Result()
                {
                    IsSuccess = _validate.IsValid,
                    Message = _validate.Message,

                };
            }
        }
    }
}
