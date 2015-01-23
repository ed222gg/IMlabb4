using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class Program
    {
        private RefereeMenu _referee = null;
        private SecretaryMenu _secretary = null;
        private DataStore _dataStore = null;

        //*******************************
        //   CONSTRUKTOR
        //*******************************
        public Program()
        {
            _dataStore = new DataStore();
            _referee = new RefereeMenu(ref _dataStore);
            _secretary = new SecretaryMenu(ref _dataStore);

        }

        //*******************************
        //   MAIN 
        //*******************************
        static void Main(string[] args)
        {
            Program theProgram = new Program();
            theProgram.showMenu();

        }

        public void RunAllTests()
        {
            TestSecretary ts =  new TestSecretary();
            ts.runAll();
            TestDatastore ds =  new TestDatastore();
            ds.runAll();
            TestBranch tb = new TestBranch();
            tb.runAll();
        }

        //******************************
        //  SHOW MENU
        //******************************
        private void showMenu()
        {

            do
            {
                Boolean SuccessfulResponse = false;

                Console.Clear();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========================");
                Console.WriteLine("=                         =");
                Console.WriteLine("=      Logga in som       =");
                Console.WriteLine("=                         =");
                Console.WriteLine("===========================");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("0. Avsluta");
                Console.WriteLine("1. Domare");
                Console.WriteLine("2. Sekreterare");
                Console.WriteLine("3. Kör alla enhetstester");
                Console.WriteLine();
                Console.WriteLine("===========================");
                Console.WriteLine();
                Console.Write("Ange menyval 0-2: ");

                switch (Console.ReadLine())
                {
                    case "0":
                        return;

                    case "1": // referee inlogg

                        SuccessfulResponse = _referee.showLogInMenu();
                        if (SuccessfulResponse == false)
                        {
                            ViewErrorMessage("Fel lösenord");
                        }
                        else
                        {
                            _referee.showRefereeMainMenu();
                        }
                        break;

                    case "2": // secretary inlogg
                        SuccessfulResponse = _secretary.showLogInMenu();
                        if (SuccessfulResponse == false)
                        {
                            ViewErrorMessage("Fel lösenord");
                        }
                        else
                        {
                            _secretary.showSecretaryMainMenu();
                        }
                        break;
                    case "3":
                        RunAllTests();
                        break;
                    case "99":
                        Console.WriteLine("Setting up system with fake data used for testing");
                        _dataStore.setupDummyDataForTesting();
                        break;

                    default:
                        ViewErrorMessage("FEL! Ange ett nummer mellan 0 och 2");
                        break;
                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("För att avsluta tryck Escape. Fortsätt genom att trycka på valfri tangent");
                Console.ResetColor();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }




        //***************************
        //  VIEW ERROR MESSAGE
        //  visar Röda felmeddelanden
        //***************************
        private static void ViewErrorMessage(string prompt)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(prompt);
            Console.ResetColor();
        }
    }
}