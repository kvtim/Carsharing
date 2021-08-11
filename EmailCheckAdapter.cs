using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    class EmailCheckAdapter : EmailChecks, IEmailChecks
    {
        public new bool CheckEmail(TextBox textBoxEmail, string email)
        {
            return this.CheckEmailUnique(textBoxEmail, email);
        }
    }
}
