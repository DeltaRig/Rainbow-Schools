using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.IO;
using Rainbow_Schools.Interfaces;

namespace Rainbow_Schools
{
    /// <summary>
    /// Class <c>Menu</c> is a class to show the menu to user, to interact with ManagerData and show what the user choose in menu.
    /// </summary>
    class Menu : IMenu
    {
        private ManagerData data;

        public Menu()
        {
            data = new ManagerData();
        }

        public Boolean CanOpenMenu()
        {
            return data.Data();
        }

        public string ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n1. Retrieve Student Data from a Text File\n" +
                               "2. Retrieve teacher Data from a Text File\n" +
                              "3. Search student by name\n" +
                              "4. See students in a class\n"  +
                              "5. Subjects taught by a teacher\n" + 
                              "0. Exit");
            Console.ForegroundColor = ConsoleColor.White;
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    data.ShowStudants();
                    break;
                case "2":
                    data.ShowTeachers();
                    break;
                case "3":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nWhat is the name for search?");
                    Console.ForegroundColor = ConsoleColor.White;
                    string name = Console.ReadLine();
                    PrintList(data.SearchByName(name), "No one student with this name");
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nWhat is the class's name?");
                    Console.ForegroundColor = ConsoleColor.White;
                    string classe = Console.ReadLine();
                    PrintList(data.GetStudantsByClass(classe), "No one studants in this class");
                    break;
                case "5":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nWhat is the teacher's name?");
                    Console.ForegroundColor = ConsoleColor.White;
                    string teacher = Console.ReadLine();
                    PrintList(data.GetSubjectsByTeacher(teacher), "No one subjects with this teacher");
                    break;
                case "0":
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Invalid option, try again");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
            return option;
        }

        private void PrintList(List<Person> list, String noData)
        {
            foreach (Person i in list)
            {
                Console.WriteLine(i);
            }
            if(list.Count() == 0)
            {
                Console.WriteLine(noData);
            }
        }

        private void PrintList(List<Subject> list, String noData)
        {
            foreach (Subject i in list)
            {
                Console.WriteLine(i);
            }
            if (list.Count() == 0)
            {
                Console.WriteLine(noData);
            }
        }

        private void PrintList(List<string> list, String noData)
        {
            foreach (string i in list)
            {
                Console.WriteLine(i);
            }
            if (list.Count() == 0)
            {
                Console.WriteLine(noData);
            }
        }
    }
}
