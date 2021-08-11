using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carsharing
{
    class UsersList
    {
        public List<User> listOfUsers;

        public UsersList()
        {
            UsersToList();
        }

        private void UsersToList()
        {
            using (ApplicationContextUser db = new ApplicationContextUser())
            {
                this.listOfUsers = db.Users.ToList();
            }
        }
    }
}
