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
        private static string FILENAME = "\\studants.txt";
        private static string path;
        private static Studant[] studants;

        public Studants()
        {
            Console.WriteLine("criei a classe studants");
            path = Directory.GetCurrentDirectory();
            path += FILENAME;

            ReadFile();
            //SortStudantsQS(0, studants.Count() - 1);
        }

        private static void ReadFile()
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    studants = new Studant[lines.Count()];

                    int i = 0;
                    foreach (string line in lines)
                    {
                        string[] temp = line.Split(',');
                        studants[i] = (new Studant(temp[0], temp[1].Trim()));
                        i++;
                    }
                }
                else
                {
                    Console.WriteLine("File not found, should be in the same folder that the app with the name studants.txt");
                    Console.WriteLine("Don't delete 'studants.txt' file");
                    Console.WriteLine("Creating the file empty, the text will be updated with data offline, using a notepad or text editor.");

                    System.IO.File.Create(path);
                }
            }
            catch
            {
                Console.WriteLine("Don't found the data");
            }
        }

        private void SortStudantsQS(int left, int right)
        {
            int pivotPos;
            if (left < right)
            {
                pivotPos = partition(left, right);
                if (pivotPos > 1)
                {
                    
                    SortStudantsQS(left, pivotPos - 1);
                }
                if (pivotPos + 1 < right)
                {
                    SortStudantsQS(pivotPos + 1, right);
                }
            }
        }

        private int partition(int left, int right)
        {
            int pivotPos = left;
            while (true)
            {
                while (studants[left].Name.CompareTo(studants[pivotPos].Name) < 0)
                {
                    left++;
                }
                while (studants[right].Name.CompareTo(studants[pivotPos].Name) > 0)
                {
                    right--;
                }
                if (left < right)
                {
                    Studant temp = studants[right];
                    studants[right] = studants[left];
                    studants[left] = temp;
                }
                else
                {
                    return right;
                }
            }
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
