using System;

namespace ClinicConsoleApp
{
    class Doctor : Employee, IComparable
    {
        public int numberOfPatients;   
        public int birthYear;

        public Doctor() { } 
        public Doctor(int _numberOfPatients, int _birthYear, string _fName, string _lName, string _position)
            : base(_fName, _lName, _position)
        {
            this.numberOfPatients = _numberOfPatients;
            this.birthYear = _birthYear;
        }
        public int CompareTo(object? obj)
        {
            Doctor d = (Doctor) obj;
            if(this.numberOfPatients < d.numberOfPatients) return -1;
            if(this.numberOfPatients > d.numberOfPatients) return 1;
            return 0;
        }

    }
}
