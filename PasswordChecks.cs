using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Carsharing
{
    class PasswordChecks : IPasswordChecks
    {
        public bool CheckTheSamePasswords(PasswordBox passwordBoxRepeat, string password, string passwordRepeat)
        {
            if (password != passwordRepeat && passwordRepeat.Length != 0)
            {
                passwordBoxRepeat.ToolTip = "Passwords mismatch!";
                passwordBoxRepeat.Background = Brushes.LightPink;
                return false;
            }
            else if (passwordRepeat.Length != 0)
            {
                passwordBoxRepeat.ToolTip = null;
                passwordBoxRepeat.Background = Brushes.White;
                return true;
            }
            return false;
        }

        public bool CheckPasswordLength(PasswordBox passwordBox, string password)
        {
            if (password.Length < 6 && password.Length != 0)
            {
                passwordBox.ToolTip = "Passwords must be more than 6 characters!";
                passwordBox.Background = Brushes.LightPink;
                return false;
            }
            else if (password.Length != 0)
            {
                passwordBox.ToolTip = null;
                passwordBox.Background = Brushes.White;
                return true;
            }
            return false;
        }

        public bool IsValidPassword(PasswordBox passwordBox, string password)
        {
            if (CurrentUser.user.Password == password)
            {
                passwordBox.ToolTip = null;
                passwordBox.Background = Brushes.White;
                return true;
            }
            else if (password.Length != 0 && CheckPasswordLength(passwordBox, password))
            {
                passwordBox.ToolTip = "Invalid password!";
                passwordBox.Background = Brushes.LightPink;
                return false;

            }
            return false;
        }
    }
}
