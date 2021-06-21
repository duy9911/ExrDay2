using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExrDay2
{
    class Member:Person
    {
        public string statusGraduation { get; set; }
        public void printMember()
        {
            Console.WriteLine("Member FirstName is: {0} , LastName: {1} , Gender: {2} , BirthPlace: {3} , DateOfBirth: {4} ,Phone Number: {5}, Age: {6} , status: {7}", firstName, lastName, gender, dayOfBirth, phoneNumber, birthPlace, age, statusGraduation);
        }
    }
}
