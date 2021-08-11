using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    static class CarReturn
    {
        static public void Return()
        {
            using (ApplicationContextUser dbUsers = new ApplicationContextUser())
            {
                using (ApplicationContextCar dbCars = new ApplicationContextCar())
                {
                    CarsList carsList = new CarsList();
                    foreach (Car car in carsList.listOfCars)
                    {
                        if (CurrentUser.user.Car == car.id)
                        {
                            dbCars.Cars.Attach(car);
                            car.Status = 1;
                            dbCars.SaveChanges();

                            dbUsers.Users.Attach(CurrentUser.user);
                            CurrentUser.user.Car = 0;
                            CurrentUser.user.Start_date = null;
                            CurrentUser.user.End_date = null;
                            dbUsers.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
