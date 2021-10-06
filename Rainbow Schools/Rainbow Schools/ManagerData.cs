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
                        searchs.Add(students[pivot].ToString() + "\t at position " + (pivot + 1));
                    else
                        break;
                    pivot--;
                }
                searchs.Add(students[foundElem].ToString() + "\t at position " + (foundElem + 1));
                pivot = foundElem + 1;
                while (pivot <= maxNum)
                {
                    if (search.Equals(students[pivot].Name, StringComparison.CurrentCultureIgnoreCase))
                        searchs.Add(students[pivot].ToString() + "\t at position " + (pivot + 1));
                    else
                        break;
                    pivot++;
                }

            }
            return searchs;
        }

        public List<Person> getStudantsByClass(string classe) {
            List<Person> studentInClass = new List<Person>();

            foreach(Person s in students)
            {
                if(s.Class.Equals(classe, StringComparison.CurrentCultureIgnoreCase))
                    studentInClass.Add(s);
            }

            return studentInClass;
        }

        public List<Subject> getSubjectsByTeacher(string teacher)
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
