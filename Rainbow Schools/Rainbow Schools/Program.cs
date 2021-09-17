using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    class Program
    {
        private static string FILENAME = "\\records.txt";
        private static string path;

        static void Main(string[] args)
        {
            path = Directory.GetCurrentDirectory();
            path += FILENAME;

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
                        ReadFile();
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

        private static void ReadFile() {

            if (File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    Console.WriteLine("\t" + line);
                }
            }
            else
            {
                Console.WriteLine("File not found, should be in the same folder that the app with the name records.txt");
                Console.WriteLine("Don't delete 'records.txt' file");
                Console.WriteLine("Creating the file empty, the text will be updated with data offline, using a notepad or text editor.");

                System.IO.File.Create(path);
            }
        }
    }
}
