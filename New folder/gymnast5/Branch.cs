using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class Branch
    {
        private string _branchName = null;
        

        //************************************
        //   CONSTRUCTOR
        //************************************
        public Branch(string branchName)
        {
            _branchName = branchName;

        }

        internal string getName()
        {
            return _branchName;
        }
    }
}
