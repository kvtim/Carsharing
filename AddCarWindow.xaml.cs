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
    /// Логика взаимодействия для AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public AddCarWindow()
        {
            InitializeComponent();
        }

        private void Button_Add_Click(object sender, RoutedEventArgs e)
        {
            string mark = TextBoxMark.Text.Trim();
            string model = TextBoxModel.Text.Trim();
            string picture = TextBoxPicture.Text.Trim();
            int price = 0;

            ChecksFactory checks = new ChecksFactory();

            bool isEmpty = IsEmpty();

            bool checkCoast = checks.OtherChecks.IsIntegerValue(TextBoxPrice, ref price);

            bool incorrectPicture = checks.OtherChecks.CheckPicture(TextBoxPicture, picture);

            if (isEmpty && checkCoast && incorrectPicture)
            {
                using (ApplicationContextCar db = new ApplicationContextCar())
                {
                    Car car = new Car(mark, model, 1, price, picture);
                    db.Cars.Add(car);
                    db.SaveChanges();
                }

                this.Owner.Hide();

                CarsWindow carsWindow = new CarsWindow();
                carsWindow.Show();

                this.Hide();
            }

            bool IsEmpty()
            {
                bool emptyMark = checks.EmptyChecks.TextBoxEmpty(TextBoxMark, mark);
                bool emptyModel = checks.EmptyChecks.TextBoxEmpty(TextBoxModel, model);
                bool emptyPicture = checks.EmptyChecks.TextBoxEmpty(TextBoxPicture, picture);
                bool emptyCoast = checks.EmptyChecks.TextBoxEmpty(TextBoxPrice, TextBoxPrice.Text.Trim());
                if (emptyMark && emptyModel && emptyPicture && emptyCoast)
                    return true;
                else
                    return false;
            }
        }

        private void Button_To_Admin_Page_Click(object sender, RoutedEventArgs e)
        {
            this.Owner.IsEnabled = true;
            this.Hide();
        }
    }
}
