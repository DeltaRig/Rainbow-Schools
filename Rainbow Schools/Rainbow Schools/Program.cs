using System;

namespace Rainbow_Schools
{
    class Program
    {

        static void Main(string[] args)
        {
            Students students = new Students();

            string option = "";
            string name = "";

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;               
                Console.WriteLine("\n1. Retrieve Student Data from a Text File\n" +
                                  "2. Search by name\n" + 
                                  "0. Exit");
                Console.ForegroundColor = ConsoleColor.White;
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        students.ShowStudants();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\nWhat is the name for search?");
                        Console.ForegroundColor = ConsoleColor.White;
                        name = Console.ReadLine();
                        students.SearchByName(name);
                        break;
                    case "0":
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Invalid option, try again");
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
            } while (!option.Equals("0"));
        }

       
    }
}
