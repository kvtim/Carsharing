using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для ChangePasswordWindow.xaml
    /// </summary>
    public partial class ChangePasswordWindow : Window
    {
        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        private void Change_Button_Click(object sender, RoutedEventArgs e)
        {
            UserActionsRealization user = new UserActionsRealization();
            if (user.ChangePassword(CurrentPasswordBox, NewPasswordBox, NewPasswordBoxRepeat))
            {
                this.Owner.IsEnabled = true;
                this.Hide();
            }
        }

        private void Return_To_Personal_Page_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Hide();
        }
    }
}
