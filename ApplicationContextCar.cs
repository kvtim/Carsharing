using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Carsharing
{
    class ApplicationContextCar : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public ApplicationContextCar() : base("DefaultConnection") { }
    }
}
