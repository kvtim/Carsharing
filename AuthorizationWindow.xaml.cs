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
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string email = TextBoxEmail.Text.Trim().ToLower();
            string pass = PasswordBox.Password;

            ChecksFactory checks = new ChecksFactory();

            bool emailEmpty = checks.EmptyChecks.TextBoxEmpty(TextBoxEmail, email);

            bool passwordEmpty = checks.EmptyChecks.PasswordBoxEmpty(PasswordBox, pass);

            bool checkPasswordLength = checks.PasswordChecks.CheckPasswordLength(PasswordBox, pass);

            bool checkEmailValid = checks.CheckEmailValid.CheckEmail(TextBoxEmail, email);

            if (emailEmpty && passwordEmpty && checkPasswordLength && checkEmailValid)
            {
                AuthorizationProcess(email, pass);
            }
        }

        private void AuthorizationProcess(string email, string pass)
        {
            using (ApplicationContextUser db = new ApplicationContextUser())
            {
                CurrentUser.user = db.Users.Where(b => b.Email == email &&
                b.Password == pass).FirstOrDefault();
            }

            if (CurrentUser.user != null)
            {
                CarsWindow carsWindow = new CarsWindow();
                carsWindow.Show();
                this.Hide();
            }
            else
            {
                TextBoxEmail.ToolTip = "Email or password entered incorrectly!";
                TextBoxEmail.Background = Brushes.LightPink;

                PasswordBox.ToolTip = "Email or password entered incorrectly!";
                PasswordBox.Background = Brushes.LightPink;
            }
        }

        private void Button_SignUp_Window_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}