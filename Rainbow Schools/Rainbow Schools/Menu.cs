using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                              "2. Search by name\n" +
                              "0. Exit");
            Console.ForegroundColor = ConsoleColor.White;
            option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    data.ShowPerson();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nWhat is the name for search?");
                    Console.ForegroundColor = ConsoleColor.White;
                    string name = Console.ReadLine();
                    data.SearchByName(name);
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
    }
}
