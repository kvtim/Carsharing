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
    /// Логика взаимодействия для ChangePriceWindow.xaml
    /// </summary>
    public partial class ChangePriceWindow : Window
    {
        public ChangePriceWindow()
        {
            InitializeComponent();
        }

        private void Change_Button_Click(object sender, RoutedEventArgs e)
        {
            AdminActionsRealization admin = new AdminActionsRealization();

            if (admin.ChangePrice(TextBoxNewPrice))
            {
                this.Owner.IsEnabled = true;
                this.Hide();
            }
        }

        private void Go_Back_Button_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Hide();
        }
    }
}
