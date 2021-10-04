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
            path = Directory.GetCurrentDirectory() + "..\\..\\..\\";
            STUDENTFILE = "dataStudents.txt";
            TEACHERFILE = "dataTeachers.txt";
            SUBJECTFILE = "dataSubjects.txt";

            ReadFiles();
            if (students.Count() >= 1)
                InsertionSort(students);
            if (teachers.Count() >= 1)
                InsertionSort(teachers);
        }

        private static void ReadFiles()
        {
            try
            {
                students = ReadPersonFile(STUDENTFILE);
                teachers = ReadPersonFile(TEACHERFILE);
                subjects = ReadSubjectFile();
            }
            catch
            {
                Console.WriteLine("Don't found the data");
            }
        }

        private static Person[] ReadPersonFile(string fileName)
        {
            Person[] persons = null;
            if (File.Exists(path + fileName))
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
            } else
            {
                Console.WriteLine("Some file don't find.");
            }

            return persons;
        }

        private static Subject[] ReadSubjectFile()
        {
            Subject[] sub = null;
            if (File.Exists(path + SUBJECTFILE))
            {
                string[] lines = System.IO.File.ReadAllLines(path + SUBJECTFILE);
                subjects = new Subject[lines.Count()];

                int i = 0;
                foreach (string line in lines)
                {
                    string[] temp = line.Split(',');
                    sub[i] = (new Subject(temp[0], temp[1].Trim(), temp[2].Trim()));
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Subjects file don't find.");
            }
            return sub;
        }

        // sort by name
        private void InsertionSort(Person[] persons)
        {

            int n = persons.Count(), i, j, flag;
            Person val;
            for (i = 1; i < n; i++)
            {
                val = persons[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val.Name.CompareTo(persons[j].Name) < 0)
                    {
                        persons[j + 1] = persons[j];
                        j--;
                        persons[j + 1] = val;
                    }
                    else flag = 1;
                }
            }
        }

        public void ShowStudants()
        {
            foreach (Person s in students)
            {
                Console.WriteLine(s.ToString());
            }
        }

        public void ShowTeachers()
        {
            foreach (Person s in teachers)
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
                        Console.WriteLine(students[pivot].ToString() + "\t at position " + (pivot + 1));
                    else
                        break;
                    pivot--;
                }
                Console.WriteLine(students[foundElem].ToString() + "\t at position " + (foundElem + 1));
                pivot = foundElem + 1;
                while (pivot <= maxNum)
                {
                    if (search.Equals(students[pivot].Name, StringComparison.CurrentCultureIgnoreCase))
                        Console.WriteLine(students[pivot].ToString() + "\t at position " + (pivot + 1));
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
