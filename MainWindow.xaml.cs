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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Carsharing
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Reg_Click(object sender, RoutedEventArgs e)
        {
            string name = TextBoxName.Text;
            string pass = PasswordBox.Password;
            string pass_2 = PasswordBox_2.Password;
            string email = TextBoxEmail.Text.Trim().ToLower();

            ChecksFactory checks = new ChecksFactory();

            bool isEmpty = IsEmpty();

            bool checkPasswordLength = checks.PasswordChecks.CheckPasswordLength(PasswordBox, pass);

            bool checkTheSamePasswords = checks.PasswordChecks.CheckTheSamePasswords(PasswordBox_2, pass, pass_2);

            bool checkEmailValid = checks.CheckEmailValid.CheckEmail(TextBoxEmail, email);

            bool checkEmailUnique = checks.CheckEmailUnique.CheckEmail(TextBoxEmail, email);

            if (isEmpty && checkPasswordLength && checkTheSamePasswords && checkEmailValid && checkEmailUnique)
            {
                RegistrationProcess(name, pass, email);
            }

            bool IsEmpty()
            {
                bool nameEmpty = checks.EmptyChecks.TextBoxEmpty(TextBoxName, name);
                bool passwordEmpty = checks.EmptyChecks.PasswordBoxEmpty(PasswordBox, pass);
                bool password_2Empty = checks.EmptyChecks.PasswordBoxEmpty(PasswordBox_2, pass_2);
                bool emailEmpty = checks.EmptyChecks.TextBoxEmpty(TextBoxEmail, email);
                if (nameEmpty && passwordEmpty && password_2Empty && emailEmpty)
                    return true;
                else
                    return false;
            }
        }

        private void RegistrationProcess(string name, string pass, string email)
        {
            using (ApplicationContextUser db = new ApplicationContextUser())
            {
                CurrentUser.user = new User(name, pass, email, 0, 0);
                db.Users.Add(CurrentUser.user);
                db.SaveChanges();
            }

            CarsWindow carsWindow = new CarsWindow();
            carsWindow.Show();
            this.Hide();
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new AuthorizationWindow();
            authorizationWindow.Show();
            this.Hide();
        }
    }
}
