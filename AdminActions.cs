using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Carsharing
{
    abstract class AdminActions
    {
        public abstract void MakeAdmin(ComboBox usersBox);

        public abstract void DeleteUser(ComboBox usersBox);

        public abstract void DeleteCar(ComboBox carsBox);

        public abstract bool ChangePrice(TextBox textBoxNewPrice);
    }
}
