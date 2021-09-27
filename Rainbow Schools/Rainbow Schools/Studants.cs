using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    class Studants
    {
        private static string FILENAME = "\\records.txt";
        private static string path;
        private static List<Studant> studants;

        public Studants()
        {
            path = Directory.GetCurrentDirectory();
            path += FILENAME;
            studants = new List<Studant>();

            ReadFile();
            SortStudants();
        }

        private static void ReadFile()
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);

                    foreach(string line in lines)
                    {
                        string[] temp = line.Split(',');
                        studants.Add(new Studant(temp[0], temp[1].Trim()));
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
            catch
            {
                Console.WriteLine("Don't found the data");
            }
        }

        private static void SortStudants()
        {
            return;
        }

        public void ShowStudants()
        {
            foreach(Studant s in studants)
            {
                Console.WriteLine(s.ToString());
            }
        }

    }
}
