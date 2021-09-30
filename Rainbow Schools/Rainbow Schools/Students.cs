﻿using System;
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

        /**
         * Quick Sort algorithm adapted to receive names from students, is not being used as it does not correctly order repeated names.
         */
        private void SortStudantsQS(int left, int right)
        {
            int pivotPos;
            if (left < right)
            {
                pivotPos = partitionQS(left, right);
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

        private int partitionQS(int left, int right)
        {
            int pivotPos = left;
            while (true)
            {
                if (students[right].Name.CompareTo(students[pivotPos].Name) == 0)
                {
                    while (students[left].Class.CompareTo(students[pivotPos].Class) < 0)
                    {
                        left++;
                    }
                    while (students[right].Class.CompareTo(students[pivotPos].Class) > 0)
                    {
                        right--;
                    }
                }
                while (students[left].Name.CompareTo(students[pivotPos].Name) < 0)
                {
                    left++;
                }
                while (students[right].Name.CompareTo(students[pivotPos].Name) > 0)
                {
                    right--;
                }
                if (left < right)
                {
                    Student temp = students[right];
                    students[right] = students[left];
                    students[left] = temp;
                }
                else
                {
                    return right;
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
                if (search.Equals(students[mid].Name))
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
                while (search.Equals(students[pivot].Name))
                {
                    Console.WriteLine(students[pivot].ToString() + "\t at line " + pivot + 1);
                    pivot--;
                }
                Console.WriteLine(students[foundElem].ToString() + "\t at line " + foundElem + 1);
                pivot = foundElem + 1;
                while (search.Equals(students[pivot].Name))
                {
                    Console.WriteLine(students[pivot].ToString() + "\t at line " + pivot + 1);
                    pivot++;
                }

            } else
            {
                Console.WriteLine("Don't found any student with this name");
            }

        }


    }
}
