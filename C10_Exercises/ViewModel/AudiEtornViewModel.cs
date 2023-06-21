using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.ViewModel
{
    public partial class AudiEtornViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _securityText;
        [ObservableProperty]
        private string _buttonText;
        private bool _isEnable;
        public AudiEtornViewModel()
        {
            SecurityText = "Security is OFF";
            ButtonText = "Enable Security";
        }

        [RelayCommand]
        public async void EnableSecurity()
        {
            if (!_isEnable)
            {
                var result = await Application.Current.MainPage.DisplayPromptAsync("Enable Security", "Enter your secure PIN", "Confirm", "Cancel", keyboard: Keyboard.Numeric);
                if (!string.IsNullOrEmpty(result))
                {

                    SecurityText = "Security is ON";
                    ButtonText = "Disable Security";
                    _isEnable = true;

                }
                else
                {
                    SecurityText = "Security is OFF";
                    ButtonText = "Enable Security";
                    _isEnable = false;
                }
            }
            else
            {
                
                SecurityText = "Security is OFF";
                ButtonText = "Enable Security";
                _isEnable = false;
            }
        }

    }
}
