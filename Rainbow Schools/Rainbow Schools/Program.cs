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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The program Retrieve Student Data from a Text File");
            Console.ForegroundColor = ConsoleColor.White;
            ReadFile();

            do
            {

            } while (true);
        }

        private static void ReadFile() {

            if (File.Exists(path))
            {
                string[] lines = System.IO.File.ReadAllLines(path);

                foreach (string line in lines)
                {
                    string[] lineToTeacher = line.Split(';');

                    long currentID = long.Parse(lineToTeacher[0]);

                    //teachers.Add(new Teacher(currentID, lineToTeacher[1], lineToTeacher[2], lineToTeacher[3]));

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
