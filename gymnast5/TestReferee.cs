using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{

    class TestReferee
    {
        DataStore _datastore;
        public TestReferee()
        {
            _datastore = new DataStore();
        }

        public void runAll()
        {
            Console.WriteLine("Test Referee:");
            testCheckPoints();
        }

        private void testCheckPoints()
        {
            Console.Write("checkPoints, ");
            RefereeMenu rm = new RefereeMenu(ref _datastore);

           
                



        }
    }
}
