using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Carsharing
{
    class OtherChecks : IOtherChecks
    {
        public bool IsIntegerValue(TextBox textBoxValue, ref int value)
        {
            if (int.TryParse(textBoxValue.Text.Trim(), out value) == false && textBoxValue.Text.Length != 0)
            {
                textBoxValue.ToolTip = "The value must be an integer!";
                textBoxValue.Background = Brushes.LightPink;
                return false;
            }
            else if (textBoxValue.Text.Length != 0)
            {
                textBoxValue.ToolTip = null;
                textBoxValue.Background = Brushes.White;
                return true;
            }
            return false;
        }

        public bool CheckPicture(TextBox textBoxPicture, string picture)
        {
            if (picture.Length != 0 && picture.Contains('.'))
            {
                textBoxPicture.ToolTip = null;
                textBoxPicture.Background = Brushes.White;
                return true;
            }
            else
            {
                textBoxPicture.ToolTip = "Picture entered incorrectly!";
                textBoxPicture.Background = Brushes.LightPink;
                return false;
            }
        }
    }
}
