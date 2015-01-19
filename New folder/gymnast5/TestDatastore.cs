using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class TestDatastore
    {
        DataStore _datastore;
        public TestDatastore()
        {
            _datastore = new DataStore();
        }
        public void runAll()
        {
            Console.WriteLine("Test dataStore,");
            testIfSameDate();
        }
        private void testIfSameDate() // testar om det är möjligt att registrera samma datum två gånger vilket inte ska vara möjligt och undantag ska då kastas
        {
            Console.Write(" test för att lägga till samma tävlingsdatum ");
            DateTime date = DateTime.Today.AddDays(1); // först hämtar vi imorgon
            _datastore.createCompetition(date.ToString());  // lägger till imorgon i datastore
            try 
            {
                _datastore.createCompetition(date.ToString()); // prova att lägga till en imorgon igen
                // finns i morgon två gånger så blir det fel och exception kastas
                Console.WriteLine("FAIL");
                
            }

            catch (Exception e)
            {
                Console.WriteLine("OK");
                //annars kan vi bara ha den en gång vilket är syftet
            }
        }
    }
}
