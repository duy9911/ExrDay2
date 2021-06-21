using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExrDay2
{
    class Program
    {
        static List<Member> memberList = new List<Member>(){
                        new Member(){firstName="Ngo", lastName="Duy",gender="Male",dayOfBirth=new DateTime(2001,9,15),phoneNumber=0389232053,birthPlace="Thai Nguyen", age=22,statusGraduation="Y" },
                        new Member(){firstName="Dam", lastName="Dat",gender="Male",dayOfBirth=new DateTime(1996,9,15),phoneNumber=0389232057,birthPlace="Ha Noi", age=25,statusGraduation="Y" },
                        new Member(){firstName="Nguyen", lastName="Duy",gender="Female",dayOfBirth=new DateTime(2000,9,15),phoneNumber=0389232059,birthPlace="Ha Noi", age=21,statusGraduation="N" },
                        };
        static List<Member> memberEqual2000List = new List<Member>();
        static List<Member> memberGreater2000List = new List<Member>();
        static List<Member> memberLess2000List = new List<Member>();
        static void Main(string[] args)
        {
            int selectedMainMenu;
            do
            {
                Program s = new Program();
                Console.WriteLine("Select 1 to show list of member male....");
                Console.WriteLine("Select 2 to show list of member oldest....");
                Console.WriteLine("Select 3 to match First name and last name together ....");
                Console.WriteLine("Select 4 to show a new menu....");
                Console.WriteLine("Select 5 to show the member who was born in HN (just take first member )....");
                Console.WriteLine("Select 6 to out this menu");
                selectedMainMenu = int.Parse(Console.ReadLine());
                switch (selectedMainMenu)
                {
                    case 1:
                        System.Console.WriteLine("Male Members---------------- ");
                        FindMaleGender();
                        break;

                    case 2:
                        System.Console.WriteLine("Oldest Members---------------- ");
                        GetOldestList();
                        break;
                    case 3:
                        System.Console.WriteLine("Member fullname list---------------- ");
                        GetFullNameList();
                        break;
                    case 4:
                        ComparisonList();
                        break;
                    case 5:
                        System.Console.WriteLine("First Member in list who was born in HN----------------");
                        GetMemberInHN();
                        break;
                }
                Console.WriteLine(" ");
                Console.Write("Press any key to continue....");
                Console.ReadKey();
            } while (selectedMainMenu != 6);
            
        }
        static public void FindMaleGender()
        {
            var result = from item in memberList
                         where item.gender == "Male"
                         select item;
            foreach (var item in result)
            {
                Console.WriteLine("Member {0} {1} is male gender ", item.firstName, item.lastName);
            }
        }
        static public void GetOldestList()
        {
            int maxAge = memberList.Max(a => a.age); // return int type only
            foreach (var item in memberList)
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
            var fullName = from item in memberList
                           select item.firstName + " " + item.lastName;
            foreach (var a in fullName)
            {
                Console.WriteLine(a, " ");
            }
        }
        static public void ComparisonList() // comparing with 200
        {

            foreach (var item in memberList)
            {

                switch (item.dayOfBirth.Year)
                {
                    case 2000:
                        memberEqual2000List.Add(item);
                        break;
                    case var expression when item.dayOfBirth.Year > 2000:
                        memberGreater2000List.Add(item);
                        break;
                    default:
                        memberLess2000List.Add(item);
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
                        foreach (var item in memberEqual2000List)
                        {
                            Console.WriteLine("List of members who has birth year is 2000 ");
                            item.printMember();
                        }
                        break;

                    case 2:
                        foreach (var item in memberGreater2000List)
                        {
                            Console.WriteLine("List of members who has birth year greater than 2000 ");
                            item.printMember();
                        }
                        break;
                    case 3:
                        foreach (var item in memberLess2000List)
                        {
                            Console.WriteLine("List of members who has birth year less than 2000 ");
                            item.printMember();
                        }
                        break;
                    default:
                        break;
                }
                Console.WriteLine(" ");
                Console.Write("Press any key to continue....");
                Console.ReadKey();
            } while (selectedMiniMenu !=4);
        }
        static public void GetMemberInHN() // Born in HN, and print first guy.
        {
            var birthPlaceInHN = from item in memberList where item.birthPlace == "Ha Noi" select item;
            foreach (var item in birthPlaceInHN)
            {
                item.printMember();
            }
        }
    }
}
