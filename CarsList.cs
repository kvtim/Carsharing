using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    class CarsList
    {
        public List<Car> listOfCars;

        public CarsList()
        {
            CarsToList();
        }

        private void CarsToList()
        {
            using (ApplicationContextCar db = new ApplicationContextCar())
            {
                this.listOfCars = db.Cars.ToList();
            }
        }
    }
}
