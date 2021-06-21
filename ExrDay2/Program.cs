using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExrDay2
{
    class Program
    {
        static List<Member> studentList = new List<Member>(){
                        new Member(){firstName="Ngo", lastName="Duy",gender="Male",dayOfBirth=new DateTime(2001,9,15),phoneNumber=0389232053,birthPlace="Thai Nguyen", age=22,statusGraduation="Y" },
                        new Member(){firstName="Dam", lastName="Dat",gender="Male",dayOfBirth=new DateTime(1996,9,15),phoneNumber=0389232057,birthPlace="Ha Noi", age=25,statusGraduation="Y" },
                        new Member(){firstName="Nguyen", lastName="Duy",gender="Female",dayOfBirth=new DateTime(2000,9,15),phoneNumber=0389232059,birthPlace="Ha Noi", age=21,statusGraduation="N" },
                        };
        static List<Member> studentEqual2000List = new List<Member>();
        static List<Member> studentGreater2000List = new List<Member>();
        static List<Member> studentLess2000List = new List<Member>();
        static void Main(string[] args)
        {
            int selectedMainMenu;
            do
            {
                Program s = new Program();
                Console.WriteLine("Select 1 to show list of students male....");
                Console.WriteLine("Select 2 to show list of students oldest....");
                Console.WriteLine("Select 3 to match First name and last name together ....");
                Console.WriteLine("Select 4 to show a new menu....");
                Console.WriteLine("Select 5 to show the student who was born in HN(just take first student )....");
                Console.WriteLine("Select 6 to out this menu");
                selectedMainMenu = int.Parse(Console.ReadLine());
                switch (selectedMainMenu)
                {
                    case 1:
                        System.Console.WriteLine("Male Students---------------- ");
                        FindMaleGender();
                        break;

                    case 2:
                        System.Console.WriteLine("Oldest Students---------------- ");
                        GetOldestList();
                        break;
                    case 3:
                        System.Console.WriteLine("Student fullname list---------------- ");
                        GetFullNameList();
                        break;
                    case 4:
                        ComparisonList();
                        break;
                    case 5:
                        System.Console.WriteLine("First Student in list who was born in HN----------------");
                        GetMemberInHN();
                        break;
                }
            } while (selectedMainMenu != 6);
            Console.ReadLine();
        }
        static public void FindMaleGender()
        {
            var result = from item in studentList
                         where item.gender == "Male"
                         select item;
            foreach (var item in result)
            {
                Console.WriteLine("Student {0} {1} is male gender ", item.firstName, item.lastName);
            }
        }
        static public void GetOldestList()
        {
            int maxAge = studentList.Max(a => a.age); // return int type only
            foreach (var item in studentList)
            {
                if (item.age == maxAge)
                {
                    item.printMember();
                    break; // make sure that only one is display
                }
            }
        }
        static public void GetFullNameList()
        {
            var fullName = from item in studentList
                           select item.firstName + " " + item.lastName;
            foreach (var a in fullName)
            {
                Console.WriteLine(a, " ");
            }
        }
        static public void ComparisonList() // comparing with 200
        {

            foreach (var item in studentList)
            {

                switch (item.dayOfBirth.Year)
                {
                    case 2000:
                        studentEqual2000List.Add(item);
                        break;
                    case var expression when item.dayOfBirth.Year > 2000:
                        studentGreater2000List.Add(item);
                        break;
                    default:
                        studentLess2000List.Add(item);
                        break;
                }
            }
            int selectedMiniMenu;
            do
            {
                System.Console.WriteLine("Select one---------------- ");
                System.Console.WriteLine("+ Select 1 to show who is 2000 ");
                System.Console.WriteLine("+ Select 2 to show who is greater than 2000 ");
                System.Console.WriteLine("+ Select 3 to show who is less than 2000 ");
                System.Console.WriteLine("+ Select 4 key to close this menu ");
                selectedMiniMenu = int.Parse(Console.ReadLine());
                switch (selectedMiniMenu)
                {
                    case 1:
                        foreach (var item in studentEqual2000List)
                        {
                            Console.WriteLine("List of members who has birth year is 2000 ");
                            item.printMember();
                        }
                        break;

                    case 2:
                        foreach (var item in studentGreater2000List)
                        {
                            Console.WriteLine("List of members who has birth year greater than 2000 ");
                            item.printMember();
                        }
                        break;
                    case 3:
                        foreach (var item in studentLess2000List)
                        {
                            Console.WriteLine("List of members who has birth year less than 2000 ");
                            item.printMember();
                        }
                        break;
                    default:
                        break;
                }
            } while (selectedMiniMenu !=4);
        }
        static public void GetMemberInHN() // Born in HN, and print first guy.
        {
            var birthPlaceInHN = from item in studentList where item.birthPlace == "Ha Noi" select item;
            foreach (var item in birthPlaceInHN)
            {
                item.printMember();
            }
        }
    }
}
