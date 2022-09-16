using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    // Define a class name Coach that inherits from the base class Person
    public class Coach : Person
    {
        // Define an auto-implemented property for HireDate 
        public DateTime HireDate { get; set; }

        // Define constructor that passes FullName to the Person base class
        public Coach(string fullName, DateTime hireDate) : base(fullName)
        {
            HireDate = hireDate;
        }
    }
}
