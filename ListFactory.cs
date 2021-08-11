using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    class ListFactory : IListFactory
    {
        public UsersList Users => new UsersList();

        public CarsList Cars => new CarsList();
    }
}
