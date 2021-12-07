using System;

namespace ClinicConsoleApp
{
    class Employee
    {
        public string fName; 
        public string lName;
        public string position;

        public Employee() { }
        public Employee(string _fName, string _lName, string _position)
        {
            this.fName = _fName;
            this.lName = _lName;
            this.position = _position;
        }

    }
}
