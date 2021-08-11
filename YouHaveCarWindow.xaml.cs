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
    /// Логика взаимодействия для YouHaveCarWindow.xaml
    /// </summary>
    public partial class YouHaveCarWindow : Window
    {
        public YouHaveCarWindow()
        {
            InitializeComponent();
        }

        private void Button_Go_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Hide();
        }
    }
}
