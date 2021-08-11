using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    interface IEmailChecks
    {
        bool CheckEmail(TextBox textBoxEmail, string email);

        //bool CheckEmailValid(TextBox textBoxEmail, string email);

        //bool CheckEmailUnique(TextBox textBoxEmail, string email);
    }
}
