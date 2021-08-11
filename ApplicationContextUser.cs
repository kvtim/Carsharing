using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Carsharing
{
    class ApplicationContextUser : DbContext
    {
        public DbSet<User> Users { get; set; }
        public ApplicationContextUser() : base("DefaultConnection") { }
    }
}
