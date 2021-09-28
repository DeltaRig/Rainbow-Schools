using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    class Studant
    {
        private string _name;
        private string _class;

        public Studant(string n, string c)
        {
            this._name = n;
            this._class = c;
        }

        public string Name => _name;

        public string ToString()
        {
            return _name + "\t|\t" + _class;
        }
    }
}
