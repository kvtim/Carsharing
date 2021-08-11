using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    static class CarRental
    {
        static public void Rent(int id, string startDate, string endDate)
        {
            using (ApplicationContextCar dbCars = new ApplicationContextCar())
            {
                CarsList carsList = new CarsList();
                foreach (Car car in carsList.listOfCars)
                {
                    if (car.id == id)
                    {
                        dbCars.Cars.Attach(car);
                        car.Status = 0;
                        dbCars.SaveChanges();

                        using (ApplicationContextUser dbUsers = new ApplicationContextUser())
                        {
                            dbUsers.Users.Attach(CurrentUser.user);
                            CurrentUser.user.Car = id;
                            CurrentUser.user.Start_date = startDate;
                            CurrentUser.user.End_date = endDate;
                            dbUsers.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
