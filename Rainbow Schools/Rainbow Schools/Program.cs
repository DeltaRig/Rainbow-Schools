using System;

namespace Rainbow_Schools
{
    class Program
    {

        static void Main(string[] args)
        {
            Studants studants = new Studants();

            string option = "";

            do
            {
                Console.ForegroundColor = ConsoleColor.Green;               
                Console.WriteLine("\n1. Retrieve Student Data from a Text File\n" +
                                  "0. Exit");
                Console.ForegroundColor = ConsoleColor.White;
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Reading the text");
                        Console.ForegroundColor = ConsoleColor.White;
                        studants.ShowStudants();
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
