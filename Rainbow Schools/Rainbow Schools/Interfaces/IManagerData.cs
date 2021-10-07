using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools.Interfaces
{
    interface IManagerData
    {
        /// <summary>
        /// Method <c>Data</c> get all data from the text files and generate lists with students, subjects, and teachers. 
        /// Sort by name studants and teachers.
        /// </summary>
        /// <returns>True if all data was got and organized and False if something fail in the process</returns>
        Boolean Data();

        /// <summary>
        /// Method <c>ShowStudents</c> shows all students order by name
        /// </summary>
        void ShowStudants();

        /// <summary>
        /// Method <c>ShowTeachers</c> shows all teachers order by name
        /// </summary>
        void ShowTeachers();

        /// <summary>
        /// Method <c>SearchByName</c> will search the people by name
        /// </summary>
        /// <param name="search"> is the name that will be search</param>
        /// <returns>A list of strings, with person to string contac with the position</returns>
        /// <example>If search = "Daniela" and a studant with "Daniela" name is in position one will return:
        /// {Daniela |       Math    |       Math II  at position 1}</example>
        List<string> SearchByName(string search);

        /// <summary>
        /// Method <c>getStudantsByClass</c> get all studants by class
        /// </summary>
        /// <param name="classe"> is the class that will be search</param>
        /// <returns>A list of Person that have this class</returns>
        List<Person> GetStudantsByClass(string classe);

        /// <summary>
        /// Method <c>GetSubjectsByTeacher</c> get all subjects that have this teacher, will check the teacher's name
        /// </summary>
        /// <param name="teacher"> is the teacher's name that will be search</param>
        /// <returns>A list of Subjects that have this teacher</returns>
        List<Subject> GetSubjectsByTeacher(string teacher);
    }
}
