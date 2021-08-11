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
    /// Логика взаимодействия для UserPageWindow.xaml
    /// </summary>
    public partial class UserPageWindow : Window
    {
        public UserPageWindow()
        {
            InitializeComponent();
        }

        private void CarToUserPageWindow()
        {
            CarToUserPageWindow carToUserPageWindow = new CarToUserPageWindow(Button_Return_Click);

            this.UsersCarStackPanel.Children.Add(carToUserPageWindow.DoesUserHaveCar());
        }

        public void Button_Return_Click(object sender, RoutedEventArgs e)
        {
            DoYouWantToReturnWindow doYouWantToReturnWindow = new DoYouWantToReturnWindow();
            doYouWantToReturnWindow.Owner = this;
            this.IsEnabled = false;

            doYouWantToReturnWindow.Show();
        }

        private void Button_To_Cars_Window_Click(object sender, RoutedEventArgs e)
        {
            CarsWindow carsWindow = new CarsWindow();
            carsWindow.Show();
            this.Hide();
        }

        private void Button_Log_Out_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Hide();
        }

        private void Button_Change_Password_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
            changePasswordWindow.Owner = this;
            this.IsEnabled = false;

            changePasswordWindow.Show();
        }

        private void Button_Delete_Account_Click(object sender, RoutedEventArgs e)
        {
            AreYouSureWindow areYouSure = new AreYouSureWindow();
            areYouSure.Owner = this;
            this.IsEnabled = false;

            areYouSure.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CarToUserPageWindow();
        }
    }
}
