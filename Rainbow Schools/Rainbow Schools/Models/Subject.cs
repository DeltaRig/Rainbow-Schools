using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    /// <summary>
    /// Class <c>Subject</c> is to store the subject data.
    /// </summary>
    class Subject
    {
        private string _name;
        private string _cod;
        private string _teacher;

        public Subject(string n, string c, string t)
        {
            this._name = n;
            this._cod = c;
            this._teacher = t;
        }

        public string Teacher => _teacher;

        override
        public string ToString()
        {
            return _cod + "," + _name;
        }
    }
}

