using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    interface IListFactory
    {
        UsersList Users { get; }

        CarsList Cars { get; }
    }
}
