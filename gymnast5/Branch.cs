using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class Branch
    {
        private string _name = null;

        public string Name
        {
            get { return _name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                _name = value; 
            }
        }

        //************************************
        //   CONSTRUCTOR
        //************************************
        public Branch(string name)
        {
            _name = name;
        }
    }
}
