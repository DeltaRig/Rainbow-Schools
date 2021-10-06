using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.IO;

namespace Rainbow_Schools
{
    class Menu
    {
        private ManagerData data;

        public Menu()
        {
            data = new ManagerData();
        }

        public string ShowMenu()
        {
            string option = "";

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n1. Retrieve Student Data from a Text File\n" +
                               "2. Retrieve teacher Data from a Text File\n" +
                              "3. Search student by name\n" +
                              "4. See students in a class\n"  +
                              "0. Exit");
            Console.ForegroundColor = ConsoleColor.White;
            option = Console.ReadLine();
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
                    data.SearchByName(name);
                    break;
                case "4":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nWhat is the class's name?");
                    Console.ForegroundColor = ConsoleColor.White;
                    string classe = Console.ReadLine();
                    PrintList(data.getStudantsByClass(classe), "No one studants in this class");
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
    }
}
