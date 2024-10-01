using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangeStudent.Enitities
{
    internal class Person
    {
        private int _id;
        private string _name;
        private DateOnly _birthday;
        private string _address;
        private double _height;
        private double _weight;

        public int Id
        {
            get => _id; 
            set => _id = value;
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public DateOnly Birthday
        {
            get => _birthday;
            set => _birthday = value;
        }

        public string Address
        {
            get => _address;
            set => _address = value;
        }

        public double Height
        {
            get => _height;
            set => _height = value;
        }

       public double Weight
        {
            get => _weight;
            set => _weight = value;
        }

        public Person()
        {
        }

        public Person(int id, string name, DateOnly birthday, string address, double height, double weight)
        {
            _id = id;
            _name = name;
            _birthday = birthday;
            _address = address;
            _height = height;
            _weight = weight;
        }

        public override string ToString() => $"Person: {Id} - {Name} - {Birthday} - {Address}- {Height} - {Weight} ";

    }
}
