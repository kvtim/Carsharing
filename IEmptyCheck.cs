using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    interface IEmptyChecks
    {
        bool TextBoxEmpty(TextBox textBoxData, string strData);

        bool PasswordBoxEmpty(PasswordBox passwordBoxData, string strData);
    }
}
