using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Person
    {
        // Define a fully-implemented property for FullName with a private set

        private string _fullname = string.Empty; // Define a backing field for the FullName property
        public string FullName
        {
            get { return _fullname; }
            private set 
            { 
                // Validate new value is not null or empty string or whitespaces only 
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("FullName value is required");
                }
                // Validate new value contains at minimum 3 or more characters
                else if (value.Trim().Length < 3)
                { 
                    throw new ArgumentException("FullName must contain 3 or more characters");
                }
                _fullname = value.Trim(); // Remove leading and trailing whitespaces 
            }
        }

        // Create a greedy constructor with a parameter for the fullName
        public Person(string fullName)
        {
            FullName = fullName;
        }

        public override string ToString()
        {
            return (FullName);
        }
    }
}
