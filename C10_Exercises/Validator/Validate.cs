using C10_Exercises.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace C10_Exercises
{
    class Validate
    {
        private string _message;
        private Regex _userName = new Regex(@"^(?!.*\S[MG]O\b)[a-zA-Z0-9]+(?: [a-zA-Z0-9]+)*$");
        public string Message { get; set; }
        public bool IsValid { get; set; }
        public void ValidateLoginClass(LoginModel model)
        {
            if (IsValidUserName(model.Username) && IsValidPassword(model.Password))
            {
                IsValid = true;
            }
            else if (!IsValidUserName(model.Username) || !IsValidPassword(model.Password))
            {
                IsValid = false;
                Message = _message;
            }

        }
        private bool IsValidPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                _message = "Enter Password";
                return false;
            }
            else if (password.Length <= 6)
            {
                _message = "Password must contains atleast 8 characters";
                return false;
            }
            else if(!password.Equals("0lelplR"))
            {
                _message = "Your password does not match";
                return false;
            }
            _message = string.Empty;
            return true;
        }

        private bool IsValidUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                _message = "Enter Username";
                return false;
            }
            else if (!IsMatchUserName(userName))
            {
                _message = "Enter Valid Username";
                return false;
            }
            else if(!userName.Equals("kminchelle"))
            {
                _message = "Your username does not match";
                return false;
            }
            _message = string.Empty;
            return true;

        }

        private bool IsMatchUserName(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return false;
            return _userName.IsMatch(userName);
        }
    }
}
