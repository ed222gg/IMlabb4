using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class TestSecretary
    {
        DataStore _dataStore;
        public TestSecretary()
        {
            _dataStore = new DataStore();

        }
        public void runAll()
        {
            Console.WriteLine("Test Secretary:");
            testCompareDate();
        }
        private void testCompareDate() //testar att själva funktionen compareDate funkar
        {
            Console.Write("CompareDate, ");
            SecretaryMenu sm = new SecretaryMenu(ref _dataStore); // skapar en ny secretaryMenu (sm) för vi måste göra ett objekt av klassen

            if (sm.compareDate(DateTime.Today) == 0 && // compareDate ger noll när det är dagens datum
                sm.compareDate(DateTime.Today.AddDays(-1)) == -1 && // compareDate ger -1 när det är tidigare än dagensdatum
                sm.compareDate(DateTime.Today.AddDays(1)) == 1) // ger 1 när det är efter dagens datum
            {
                Console.WriteLine("OK\n");
                
            }

            else
            {
                Console.WriteLine("FAILED\n");
            }
        }

        private bool test2()
        { 
            if (true)
            {
                return true;
            }
            else
            {
                return false; // funkar inte
            }
            
        }

        
    }
}


