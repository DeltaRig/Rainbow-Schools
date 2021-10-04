using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    class ManagerData
    {
        private static string STUDENTFILE;
        private static string TEACHERFILE;
        private static string SUBJECTFILE;
        private static string path;
        private static Person[] students;
        private static Person[] teachers;
        private static Subject[] subjects;

        public ManagerData()
        {
            path = "..\\..\\..\\" + Directory.GetCurrentDirectory();
            STUDENTFILE = "studants.txt";
            TEACHERFILE = "teachers.txt";
            SUBJECTFILE = "subjects.txt";

            ReadFiles();
            if (students.Count() >= 1)
                InsertionSort();
        }

        private static void ReadFiles()
        {
            try
            {
                if (File.Exists(path))
                {
                    ReadPersonFile(students, STUDENTFILE);
                    ReadPersonFile(teachers, TEACHERFILE);
                    ReadSubjectFile();
                }
                else
                {
                    Console.WriteLine("Some file don't find.");
                }
            }
            catch
            {
                Console.WriteLine("Don't found the data");
            }
        }

        private static void ReadPersonFile(Person[] persons, string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(path + fileName);
            persons = new Person[lines.Count()];

            int i = 0;
            foreach (string line in lines)
            {
                string[] temp = line.Split(',');
                persons[i] = (new Person(temp[0], temp[1].Trim(), temp[2].Trim()));
                i++;
            }
        }

        private static void ReadSubjectFile()
        {
            string[] lines = System.IO.File.ReadAllLines(path + SUBJECTFILE);
            subjects = new Subject[lines.Count()];

            int i = 0;
            foreach (string line in lines)
            {
                string[] temp = line.Split(',');
                subjects[i] = (new Subject(temp[0], temp[1].Trim(), temp[2].Trim()));
                i++;
            }
        }

        private void InsertionSort()
        {

            int n = students.Count(), i, j, flag;
            Person val;
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

                minNum = 0;
                maxNum = students.Length - 1;

                int pivot = foundElem - 1;
                // if this student are in more then one class
                while (pivot >= minNum)
                {
                    if (search.Equals(students[pivot].Name, StringComparison.CurrentCultureIgnoreCase))
                        Console.WriteLine(students[pivot].ToString() + "\t at line " + (pivot + 1));
                    else
                        break;
                    pivot--;
                }
                Console.WriteLine(students[foundElem].ToString() + "\t at line " + (foundElem + 1));
                pivot = foundElem + 1;
                while (pivot <= maxNum)
                {
                    if (search.Equals(students[pivot].Name, StringComparison.CurrentCultureIgnoreCase))
                        Console.WriteLine(students[pivot].ToString() + "\t at line " + (pivot + 1));
                    else
                        break;
                    pivot++;
                }

            } else
            {
                Console.WriteLine("Don't found any student with this name");
            }

        }


    }
}
