using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Figure
    {
        private bool colored = false;
        /*public Figure(bool colored)
        {
            this.colored = colored;
        }*/

        public bool Colored
        {
            get
            {
                return colored;
            }
            set
            {
                colored = value;
            }
        }
    }
}
