using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class TestBranch
    {     
           public void runAll()
        {
            Console.WriteLine("Test Branch:");
            TestEmptyBranchName();
            TestWhitespaceBranchName();
            TestNullBranchName();
            TestExceptionBranchName();
            TestValidBranchName();
        }

        
       
  


        public bool TestEmptyBranchName()
        {
            try
            {
                new Branch(string.Empty);
                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool TestWhitespaceBranchName()
        {
            try
            {
                new Branch("     ");
                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool TestNullBranchName()
        {
            try
            {
                new Branch(null);
                return false;
            }
            catch
            {
                return true;
            }
        }

        public bool TestExceptionBranchName()
        {
            try
            {
                new Branch(null);
                return false;
            }
            catch (ArgumentException)
            {
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool TestValidBranchName()
        {
            try
            {
                var branch = new Branch("Ringar");
                return branch.Name == "Ringar";
            }
            catch
            {
                return false;
            }
        }
    }
}
