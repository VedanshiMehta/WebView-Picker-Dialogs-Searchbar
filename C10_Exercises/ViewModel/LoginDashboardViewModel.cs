using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C10_Exercises.ViewModel
{
     public partial class LoginDashboardViewModel : ObservableObject
     {
        [ObservableProperty]
        private LoginResponseModel loginResponseModel;
     }
}
