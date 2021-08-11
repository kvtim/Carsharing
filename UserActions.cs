using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    abstract class UserActions
    {
        public abstract void DeleteAccount();

        public abstract bool ChangePassword(PasswordBox currentPasswordBox, PasswordBox newPasswordBox, PasswordBox newPasswordBoxRepeat);
    }
}
