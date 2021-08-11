using System;
using System.Collections.Generic;
using System.Text;

namespace Carsharing
{
    class Car
    {
        private string mark;
        private string model;
        private int status;
        private int price;
        private string picture;

        public int id { get; set; }

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Picture
        {
            get { return picture; }
            set { picture = value; }
        }

        public Car() { }

        public Car(string mark, string model, int status, int price, string picture)
        {
            this.mark = mark;
            this.model = model;
            this.status = status;
            this.price = price;
            this.picture = picture;
        }
    }
}
