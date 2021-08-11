using System;
using System.Collections.Generic;
using System.Text;

namespace Carsharing
{
    class User
    {
        private string name;
        private string password;
        private string email;
        private int car;
        private string start_date;
        private string end_date;
        private int is_admin;

        public int id { get; set; }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public int Car
        {
            get { return car; }
            set { car = value; }
        }
        public string Start_date
        {
            get { return start_date; }
            set { start_date = value; }
        }
        public string End_date
        {
            get { return end_date; }
            set { end_date = value; }
        }
        public int Is_admin
        {
            get { return is_admin; }
            set { is_admin = value; }
        }

        public User() { }

        public User(string name, string password, string email, int car, int is_admin)
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.car = car;
            this.is_admin = is_admin;
        }

        public User(string name, string password, string email, int car, string start_date, string end_date, int is_admin)
        {
            this.name = name;
            this.password = password;
            this.email = email;
            this.car = car;
            this.start_date = start_date;
            this.end_date = end_date;
            this.is_admin = is_admin;
        }
    }
}
