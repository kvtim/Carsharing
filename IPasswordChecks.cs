using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    interface IPasswordChecks
    {
        bool CheckTheSamePasswords(PasswordBox passwordBoxRepeat, string password, string passwordRepeat);

        bool CheckPasswordLength(PasswordBox passwordBox, string pass);

        bool IsValidPassword(PasswordBox passwordBox, string password);
    }
}
