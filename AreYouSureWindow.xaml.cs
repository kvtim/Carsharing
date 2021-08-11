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
    /// Логика взаимодействия для AreYouSureWindow.xaml
    /// </summary>
    public partial class AreYouSureWindow : Window
    {
        public AreYouSureWindow()
        {
            InitializeComponent();
        }

        private void Button_No_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Hide();
        }

        private void Button_Yes_Click(object sender, RoutedEventArgs e)
        {
            UserActionsRealization user = new UserActionsRealization();
            user.DeleteAccount();
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Hide();
        }
    }
}
