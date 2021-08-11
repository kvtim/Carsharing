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
    /// Логика взаимодействия для CarsWindow.xaml
    /// </summary>
    public partial class CarsWindow : Window
    {
        public CarsWindow()
        {
            InitializeComponent();
        }

        private void CarsToWindow()
        {
            CarsList cars = new CarsList();
            foreach (Car car in cars.listOfCars) // написать сообщение если нет тачекs
            {
                if (car.Status == 1)
                {
                    CarToCarWindow(car.Mark, car.Model, car.Picture, car.Price, car.id);
                }
            }
        }

        private void CarToCarWindow(string mark, string model, string picture, int price, int id)
        {
            CarToWindow carToWindow = new CarToWindow(Button_Rent_Click); 

            this.carsStackPanel.Children.Add(carToWindow.CreateNewCarGrid(mark, model, picture, price, "rent"));

            void Button_Rent_Click(object sender, RoutedEventArgs e)
            {
                if (CurrentUser.user.Car == 0)
                {
                    RentWindow rentWindow = new RentWindow();
                    rentWindow.Tag = id;
                    rentWindow.Show();
                    this.Hide();
                }
                else
                {
                    YouHaveCarWindow youHaveCarWindow = new YouHaveCarWindow();
                    youHaveCarWindow.Owner = this;
                    youHaveCarWindow.Show();
                    this.IsEnabled = false;
                }
            }
        }

        private void Button_To_Personal_Account_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentUser.user != null)
            {
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
            }
            else
                MessageBox.Show("User doesn't exists!");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Tag = 0;
            CarsToWindow();
        }
    }
}
