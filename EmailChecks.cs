using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Carsharing
{
    class EmailChecks : IEmailChecks
    {
        public bool CheckEmail(TextBox textBoxEmail, string email)
        {
            if (!IsValidEmail(email) && email.Length != 0)
            {
                textBoxEmail.ToolTip = "Email entered incorrectly!";
                textBoxEmail.Background = Brushes.LightPink;
                return false;
            }
            else if (email.Length != 0)
            {
                textBoxEmail.ToolTip = null;
                textBoxEmail.Background = Brushes.White;
                return true;
            }
            return false;
        }

        public bool CheckEmailUnique(TextBox textBoxEmail, string email)
        {
            if (CheckEmail(textBoxEmail, email) && !IsUniqueEmail(email) && email.Length != 0)
            {
                textBoxEmail.ToolTip = "User with such email is already registered!";
                textBoxEmail.Background = Brushes.LightPink;
                return false;
            }
            else if (email.Length != 0 && CheckEmail(textBoxEmail, email))
            {
                textBoxEmail.ToolTip = null;
                textBoxEmail.Background = Brushes.White;
                return true;
            }
            return false;
        }

        private static bool IsUniqueEmail(string email)
        {
            UsersList users = new UsersList();
            foreach (User user in users.listOfUsers)
            {
                if (user.Email == email)
                {
                    return false;
                }
            }
            return true;
        }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }
    }
}
