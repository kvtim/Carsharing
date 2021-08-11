using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    interface IOtherChecks
    {
        bool IsIntegerValue(TextBox textBoxValue, ref int value);

        bool CheckPicture(TextBox textBoxPicture, string picture);
    }
}
