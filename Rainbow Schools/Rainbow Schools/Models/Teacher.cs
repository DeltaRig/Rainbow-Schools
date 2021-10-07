using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    /// <summary>
    /// Class <c>Teacher</c> is derived class (child) from Person. This class is to have a specific class to teachers.
    /// </summary>
    class Teacher : Person
    {
        public Teacher(string n, string c, string s) : base(n, c, s)
        {
        }
    }
}