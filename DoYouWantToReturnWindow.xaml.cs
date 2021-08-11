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
    /// Логика взаимодействия для DoYouWantToReturnWindow.xaml
    /// </summary>
    public partial class DoYouWantToReturnWindow : Window
    {
        public DoYouWantToReturnWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DateTime now = DateTime.Now;

            if (DateTime.TryParse(CurrentUser.user.End_date, out DateTime endDateTime))
            {
                var diffEndAndNow = endDateTime.Subtract(now);

                int diff = (int)Math.Ceiling((diffEndAndNow.TotalDays));

                if (diff > 0)
                {
                    TextBlock.Text = $"You still have {diff} days!\nDo you really want to return the car?";
                }
                else if (diff == 0)
                {
                    TextBlock.Text = "Do you want to return the car?";
                }
                else
                {
                    TextBlock.Text = $"You are {-diff} days late\nand will have to pay a fine!";
                    TextBlock.Foreground = Brushes.Red;
                }
            }
            else
                MessageBox.Show("Incorrect end date!");
        }

        private void Button_Go_Back_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Hide();
        }

        private void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            CarReturn.Return();

            if (CurrentUser.user.Is_admin == 1)
            {
                AdminPage adminPage = new AdminPage();
                adminPage.Show();
                this.Hide();
            }
            else
            {
                UserPageWindow userPageWindow = new UserPageWindow();
                userPageWindow.Show();
                this.Hide();
            }

            this.Owner.Hide();
            this.Hide();
        }
    }
}
