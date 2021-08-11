using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Carsharing
{
    class EmptyChecks : IEmptyChecks
    {
        public bool TextBoxEmpty(TextBox textBoxData, string strData)
        {
            if (strData.Length == 0)
            {
                textBoxData.ToolTip = "This field connot be empty!";
                textBoxData.Background = Brushes.LightPink;
                return false;
            }
            else
            {
                textBoxData.ToolTip = null;
                textBoxData.Background = Brushes.White;
                return true;
            }
        }
        public bool PasswordBoxEmpty(PasswordBox passwordBoxData, string strData)
        {
            if (strData.Length == 0)
            {
                passwordBoxData.ToolTip = "This field connot be empty!";
                passwordBoxData.Background = Brushes.LightPink;
                return false;
            }
            else
            {
                passwordBoxData.ToolTip = null;
                passwordBoxData.Background = Brushes.White;
                return true;
            }
        }
    }
}
