using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    class AdminActionsRealization : AdminActions
    {
        public static string MarkWithModel { get; set; }

        public override void MakeAdmin(ComboBox usersBox)
        {
            using (ApplicationContextUser db = new ApplicationContextUser())
            {
                UsersList users = new UsersList();
                foreach (User user in users.listOfUsers)
                {
                    if (usersBox.SelectedValue != null && user.Email == usersBox.SelectedValue.ToString())
                    {
                        db.Users.Attach(user);
                        user.Is_admin = 1;
                        db.SaveChanges();
                        usersBox.Items.Remove(usersBox.SelectedItem);
                    }
                }
            }
        }

        public override void DeleteUser(ComboBox usersBox)
        {
            ListFactory factory = new ListFactory();
            foreach (User user in factory.Users.listOfUsers)
            {
                if (usersBox.SelectedValue != null && user.Email == usersBox.SelectedValue.ToString())
                {
                    if (user.Car != 0)
                    {
                        using (ApplicationContextCar dbCars = new ApplicationContextCar())
                        {
                            foreach (Car car in factory.Cars.listOfCars)
                            {
                                if (car.id == user.Car)
                                {
                                    dbCars.Cars.Attach(car);
                                    car.Status = 1;
                                    dbCars.SaveChanges();
                                }
                            }
                        }
                    }

                    using (ApplicationContextUser dbUsers = new ApplicationContextUser())
                    {
                        dbUsers.Users.Attach(user);
                        dbUsers.Users.Remove(user);
                        dbUsers.SaveChanges();
                        usersBox.Items.Remove(usersBox.SelectedItem);
                    }
                }
            }
        }

        public override void DeleteCar(ComboBox carsBox)
        {
            using (ApplicationContextCar db = new ApplicationContextCar())
            {
                CarsList cars = new CarsList();
                foreach (Car car in cars.listOfCars)
                {
                    if (carsBox.SelectedValue != null && (car.Mark + ' ' + car.Model) == carsBox.SelectedValue.ToString())
                    {
                        db.Cars.Attach(car);
                        db.Cars.Remove(car);
                        db.SaveChanges();
                        carsBox.Items.Remove(carsBox.SelectedItem);
                    }
                }
            }
        }

        public override bool ChangePrice(TextBox textBoxNewPrice)
        {
            int newPrice = 0;

            ChecksFactory checks = new ChecksFactory();

            bool isEmpty = checks.EmptyChecks.TextBoxEmpty(textBoxNewPrice, textBoxNewPrice.Text.Trim());
            bool checkPrice = checks.OtherChecks.IsIntegerValue(textBoxNewPrice, ref newPrice);


            if (isEmpty && checkPrice)
            {
                using (ApplicationContextCar db = new ApplicationContextCar())
                {
                    CarsList cars = new CarsList();
                    foreach (Car car in cars.listOfCars)
                    {
                        if ((car.Mark + ' ' + car.Model) == MarkWithModel)
                        {
                            db.Cars.Attach(car);
                            car.Price = newPrice;
                            db.SaveChanges();
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
