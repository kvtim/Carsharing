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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private void UsersToComboBox()
        {
            UsersList users = new UsersList();
            foreach (User user in users.listOfUsers)
            {
                if (user.Is_admin == 0)
                    UsersBox.Items.Add(user.Email);
            }
        }

        private void CarsToComboBox()
        {
            CarsList cars = new CarsList();
            foreach (Car car in cars.listOfCars)
            {
                if (car.Status == 1)
                {
                    CarsBox.Items.Add(car.Mark + ' ' + car.Model);
                }
            }
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

        private void Button_To_Add_Car_Window_Click(object sender, RoutedEventArgs e)
        {
            AddCarWindow addCarWindow = new AddCarWindow();
            addCarWindow.Owner = this;
            this.IsEnabled = false;

            addCarWindow.Show();
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

        private void Button_Make_Admin_Click(object sender, RoutedEventArgs e)
        {
            AdminActionsRealization admin = new AdminActionsRealization();
            admin.MakeAdmin(UsersBox);
        }

        private void Button_Delete_User_Click(object sender, RoutedEventArgs e)
        {
            AdminActionsRealization admin = new AdminActionsRealization();
            admin.DeleteUser(UsersBox);
        }

        private void Button_Delete_Car_Click(object sender, RoutedEventArgs e)
        {
            AdminActionsRealization admin = new AdminActionsRealization();
            admin.DeleteCar(CarsBox);
        }

        private void Change_Price_Button_Click(object sender, RoutedEventArgs e)
        {
            if (CarsBox.SelectedValue != null)
            {
                AdminActionsRealization.MarkWithModel = CarsBox.SelectedValue.ToString();

                ChangePriceWindow changePriceWindow = new ChangePriceWindow();
                changePriceWindow.Owner = this;
                changePriceWindow.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UsersToComboBox();
            CarsToComboBox();

            CarToUserPageWindow();
        }

        private void Button_Delete_Account_Click(object sender, RoutedEventArgs e)
        {
            AreYouSureWindow areYouSure = new AreYouSureWindow();
            areYouSure.Owner = this;
            this.IsEnabled = false;

            areYouSure.Show();
        }

        private void Button_Change_Password_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
            changePasswordWindow.Owner = this;
            this.IsEnabled = false;

            changePasswordWindow.Show();
        }
    }
}
