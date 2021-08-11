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
    /// Логика взаимодействия для RentWindow.xaml
    /// </summary>
    public partial class RentWindow : Window
    {
        public RentWindow()
        {
            InitializeComponent();
        }

        private void CarToRentWindow(string mark, string model, string picture, int price)
        {
            CarToWindow carToRentWindow = new CarToWindow(Button_Rent_Click);

            this.CarToRentStackPanel.Children.Add(carToRentWindow.CreateNewCarGrid(mark, model, picture, price, "rent"));
        }

        private void Button_Rent_Click(object sender, RoutedEventArgs e)
        {
            if (Calendar.SelectedDate == null)
            {
                Calendar.ToolTip = "Select the date of car delivery!";
                Calendar.Background = Brushes.LightPink;
            }
            else
            {
                string startDate = DateTime.Now.ToShortDateString();

                string endDate = Calendar.SelectedDate.Value.ToShortDateString();

                CarRental.Rent((int)this.Tag, startDate, endDate);

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
        }

        private void Button_Go_Back_Click(object sender, RoutedEventArgs e)
        {
            CarsWindow carsWindow = new CarsWindow();
            carsWindow.Show();
            this.Hide();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Calendar.DisplayDateStart = DateTime.Now.AddDays(1);
            Calendar.DisplayDateEnd = DateTime.Now.AddMonths(1).AddDays(1);

            CarsList carsList = new CarsList();

            foreach (Car car in carsList.listOfCars)
            {
                if ((int)this.Tag == car.id)
                {
                    CarToRentWindow(car.Mark, car.Model, car.Picture, car.Price);
                    break;
                }
            }
        }
    }
}
