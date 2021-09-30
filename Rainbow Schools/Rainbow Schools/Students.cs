using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    class Students
    {
        private static string FILENAME = "..\\..\\..\\studants.txt";
        private static string path;
        private static Student[] students;

        public Students()
        {
            path = Directory.GetCurrentDirectory();
            path += FILENAME;

            ReadFile();
            if (students.Count() >= 1)
                InsertionSort();
                //SortStudantsQS(0, students.Count() - 1);
        }

        private static void ReadFile()
        {
            try
            {
                if (File.Exists(path))
                {
                    string[] lines = System.IO.File.ReadAllLines(path);
                    students = new Student[lines.Count()];

                    int i = 0;
                    foreach (string line in lines)
                    {
                        string[] temp = line.Split(',');
                        students[i] = (new Student(temp[0], temp[1].Trim()));
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

        private void InsertionSort()
        {

            int n = students.Count(), i, j, flag;
            Student val;
            for (i = 1; i < n; i++)
            {
                val = students[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val.Name.CompareTo(students[j].Name) < 0)
                    {
                        students[j + 1] = students[j];
                        j--;
                        students[j + 1] = val;
                    }
                    else flag = 1;
                }


            }
        }

        public void ShowStudants()
        {
            foreach (Student s in students)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void SearchByName(string search)
        {
            int minNum = 0;
            int maxNum = students.Length - 1;
          
            int foundElem = -1;

            while (minNum <= maxNum && foundElem == -1)
            {
                int mid = (minNum + maxNum) / 2;
                if (search.Equals(students[mid].Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    foundElem = mid;
                    break;
                }
                else if (search.CompareTo(students[mid].Name) < 0)
                {
                    maxNum = mid - 1;
                }
                else
                {
                    minNum = mid + 1;
                }
            }

            if (foundElem > -1)
            {
                Console.WriteLine("\nFound");

                int pivot = foundElem - 1;
                // if this student are in more then one class
                while (search.Equals(students[pivot].Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine(students[pivot].ToString() + "\t at line " + (pivot + 1));
                    pivot--;
                }
                Console.WriteLine(students[foundElem].ToString() + "\t at line " + (foundElem + 1));
                pivot = foundElem + 1;
                while (search.Equals(students[pivot].Name, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine(students[pivot].ToString() + "\t at line " + (pivot + 1));
                    pivot++;
                }

            } else
            {
                Console.WriteLine("Don't found any student with this name");
            }

        }


    }
}
