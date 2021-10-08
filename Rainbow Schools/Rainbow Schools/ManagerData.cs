using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainbow_Schools.Interfaces;

namespace Rainbow_Schools
{
    /// <summary>
    /// Class <c>ManagerData</c> store data about classes, which contain students, subjects, and teachers. 
    /// </summary>
    class ManagerData : IManagerData
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
            
        }

        public Boolean Data()
        {
            path = Directory.GetCurrentDirectory() + "..\\..\\..\\";
            STUDENTFILE = "dataStudents.txt";
            TEACHERFILE = "dataTeachers.txt";
            SUBJECTFILE = "dataSubjects.txt";

            Boolean result = ReadFiles();
            if (result)
            {
                if (students.Count() >= 1)
                    InsertionSort(students);
                if (teachers.Count() >= 1)
                    InsertionSort(teachers);
            }
            return result;
        }

        private static Boolean ReadFiles()
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
                return false;
            }
            if (students == null)
                return false;
            if (teachers == null)
                return false;
            if (subjects == null)
                return false;
            return true;
        }

        /// <summary>
        /// Method <c>ReadPersonFile</c> reads the file of any people, students or teachers.
        /// </summary>
        /// <param name="fileName">The file's name of have the list of people to convert to cache, in the file the attributes needs be separeted by ','</param>
        /// <returns>A list of people that was in the file, if returns null this means that can't be read the file</returns>
        private static Person[] ReadPersonFile(string fileName)
        {
            Person[] people = null;
            if (File.Exists(path + fileName))
            {
                string[] lines = System.IO.File.ReadAllLines(path + fileName);
                people = new Person[lines.Count()];

                int i = 0;
                foreach (string line in lines)
                {
                    string[] temp = line.Split(',');
                    people[i] = (new Person(temp[0], temp[1].Trim(), temp[2].Trim()));
                    i++;
                }
            } else
            {
                Console.WriteLine("Some file don't find.");
            }

            return people;
        }

        /// <summary>
        /// Method <c>ReadSubjectFile</c> reads the file of subjects.
        /// </summary>
        /// <returns>A list of people that was in the file, if returns null this means that can't be read the file</returns>
        private static Subject[] ReadSubjectFile()
        {
            Subject[] sub = null;
            if (File.Exists(path + SUBJECTFILE))
            {
                string[] lines = System.IO.File.ReadAllLines(path + SUBJECTFILE);
                sub = new Subject[lines.Count()];

                int i = 0;
                string[] temp;
                Teacher t;
                foreach (string line in lines)
                {
                    temp = line.Split(',');
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

        /// <summary>
        /// Sort a array of people by name using insertion sort.
        /// </summary>
        /// <param name="people">Is a array of people that will be ordenate.</param>
        private void InsertionSort(Person[] people)
        {

            int n = people.Count(), i, j, flag;
            Person val;
            for (i = 1; i < n; i++)
            {
                val = people[i];
                flag = 0;
                for (j = i - 1; j >= 0 && flag != 1;)
                {
                    if (val.Name.CompareTo(people[j].Name) < 0)
                    {
                        people[j + 1] = people[j];
                        j--;
                        people[j + 1] = val;
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
            foreach (Person t in teachers)
            {
                Console.WriteLine(t.ToString());
            }
        }

        public List<string> SearchByName(string search)
        {
            List<string> searchs = new List<string>();

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
                        searchs.Add(students[pivot].ToString() + " at position " + (pivot + 1));
                    else
                        break;
                    pivot--;
                }
                searchs.Add(students[foundElem].ToString() + " at position " + (foundElem + 1));
                pivot = foundElem + 1;
                while (pivot <= maxNum)
                {
                    if (search.Equals(students[pivot].Name, StringComparison.CurrentCultureIgnoreCase))
                        searchs.Add(students[pivot].ToString() + " at position " + (pivot + 1));
                    else
                        break;
                    pivot++;
                }

            }
            return searchs;
        }

        public List<Person> GetStudantsByClass(string classe) {
            List<Person> studentInClass = new List<Person>();

            foreach(Person s in students)
            {
                if(s.Class.Equals(classe, StringComparison.CurrentCultureIgnoreCase))
                    studentInClass.Add(s);
            }

            return studentInClass;
        }

        public List<Subject> GetSubjectsByTeacher(string teacher)
        {
            List<Subject> teachersSubjects = new List<Subject>();

            foreach (Subject s in subjects)
            {
                if (s.Teacher.Equals(teacher, StringComparison.CurrentCultureIgnoreCase))
                    teachersSubjects.Add(s);
            }

            return teachersSubjects;
        }

    }
}
