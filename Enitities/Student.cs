using ProjectMangeStudent.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMangeStudent.Enitities
{
    internal class Student : Person
    {

        public string _code;
        public string _school;
        public int _startDate;
        public double _average;
        public @enum Performance { get; set; }


        public Student()
        {
        }

        public Student(string code, string school, int startDate, double average) : base()
        {
            _code = code;
            _school = school;
            _startDate = startDate;
            _average = average;
        }

        public Student(int id, string name, DateOnly birthday, string address, double height, double weight,
            string code, string school, int startDate, double average) : base(id, name, birthday, address, height, weight)
        {
            _code = code;
            _school = school;
            _startDate = startDate;
            _average = average;
        }

        public string Code
        {
            get => _code; set => _code = value;
        }

        public string School
        {
            get => _school; set => _school = value;
        }

        public int StartDate
        {
            get => _startDate; set => _startDate = value;
        }

        public double Average
        {
            get => _average; set => _average = value;
        }

        public override string ToString()
        {
            return base.ToString() + "Student: " + Code + " - " + School + " - " + StartDate + " - " + Average;
        }

        public void UpdatePerformance()
        {
            if (Average < 3)
                Performance = @enum.Poor;
            else if (Average < 5)
                Performance = @enum.Weak;
            else if (Average < 6.5)
                Performance = @enum.Average;
            else if(Average < 7.5)
                Performance = @enum.Good;
            else if(Average < 9)
                Performance = @enum.Excellent;
            else 
                Performance = @enum.Outstanding;
        }
    }
}
