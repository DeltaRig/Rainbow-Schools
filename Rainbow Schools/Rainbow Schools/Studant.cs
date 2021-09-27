using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainbow_Schools
{
    class Studant
    {
        private string name;
        private string _class;

        public Studant(string n, string c)
        {
            this.name = n;
            this._class = c;
        }


        public string ToString()
        {
            return name + "\t|\t" + _class;
        }
    }
}
