using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    class Student
    {
        private string _name;
        private string _class;

        public Student(string n, string c)
        {
            this._name = n;
            this._class = c;
        }

        public string Name => _name;
        public string Class => _class;

        override
        public string ToString()
        {
            return _name + "\t|\t" + _class;
        }
    }
}
