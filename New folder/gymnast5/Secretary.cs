using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class SecretaryMenu
    {
        private DataStore _dataStore;
       


        //**************************************
        //   CONSTRUCTOR
        //**************************************
        public SecretaryMenu(ref DataStore dataStore)
        {
           
            this._dataStore = dataStore;
        }



        //**************************************
        //   SHOW LOGIN MENU
        //**************************************
        internal bool showLogInMenu()
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("===========================");
            Console.WriteLine("=                         =");
            Console.WriteLine("=     SEKRETERARE         =");
            Console.WriteLine("=                         =");
            Console.WriteLine("===========================");
            Console.WriteLine();
            Console.ResetColor();

            string userName = LogIn("Ange användarnamn: ");
            string password = LogIn("Ange Lösenord: ");
            // Verifiera användarnamn och lösenord från datastore
            Dictionary<string, string> secs = _dataStore.getListOfSecretaries();
            if (secs.ContainsKey(userName))
            {
                if (password == secs[userName])
                {
                    return true; // lösenordet överrensstämmer
                }
            }
            return false; // ingen match med lösenordet och eller användarnamnet

        }

        //*****************************
        //  LOGIN   
        //*****************************
        private static string LogIn(string prompt)
        {
            Console.Write(prompt);
            string userName = Console.ReadLine();
            return userName;
        }

        //*****************************
        //   SHOW REFEREE MAIN MENU
        //  Användaren har loggat in
        //*****************************
        internal void showSecretaryMainMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.Clear();
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("===========================");
                Console.WriteLine("=                         =");
                Console.WriteLine("=         Inloggad        =");
                Console.WriteLine("=                         =");
                Console.WriteLine("===========================");
                Console.ResetColor();
                Console.WriteLine();

                Console.WriteLine("VÄLJ MENYVAL\n");

                Console.WriteLine("0 Avsluta");
                Console.WriteLine("1 Registrera tävling  ");
                Console.WriteLine("2 visa tävlingar");

                Console.WriteLine();
                int choise = int.Parse(Console.ReadLine());

                switch (choise)
                {

                    case 0:
                        Console.WriteLine();
                        keepRunning = false;
                        break;

                    case 1:
                        Console.WriteLine();
                        regCompetion();
                        break;

                    case 2:
                        Console.WriteLine();
                        showCompetionMenu();
                        break;
                } 
            }
        }

        private void regCompetion()
        {
          
            Console.WriteLine("Ange datum i formatet åååå-mm-dd:  ");
            string regDate =Console.ReadLine();
           DateTime inputDate = DateTime.Parse(regDate);



         
             if (compareDate(inputDate)>0)
             {
                 Competition newCompetition = null;
                 try
                 {
                     newCompetition = _dataStore.createCompetition(regDate);
                 }
                 catch(Exception ex)
                 {
                     Console.WriteLine("ERROR, {0}", ex.ToString());
                     Console.WriteLine("Tryck Enter för att fortsätta.");
                     Console.ReadKey();
                     
                     return;
                 }
                
                // sen ska man lägga till grenarna till datumet

                Console.WriteLine("Ange tre grenar som kommer ingå i tävlingen");
                for (int i = 1; i <= 3; i += 1)
                {
                    Console.WriteLine("Lägg till gren nr {0} ", i);
                    string regBranch = Console.ReadLine();
                    newCompetition.addBranch(new Branch(regBranch));                     
                }

                Console.WriteLine("Du är nu klar med registreringen av en tävling, tryck på en tangent för att återgå till menyn");
                Console.ReadKey();
                  
           }

            else if (compareDate(inputDate) < 0)
            {
               Console.WriteLine("datumet har redan passerat");
               regCompetion();
            }

            else
            {
                Console.WriteLine("Oops något gick snett. Ange datum på nytt");
                _dataStore.createCompetition(regDate);
                regCompetion();
            }
  
        }

        /// <summary>
        /// Jämför datum som skickas med som parameter med dagens datum.
        /// Returnerar:
        /// -1 när datumet är tidigare än dagens datum.
        /// 0 när det är samma som dagens datum.
        /// 1 när datumet är senare än dagens datum.
        /// </summary>
        /// <param name="inputDate">Datum som skall jämföras med dagens datum.</param>
        public int compareDate(DateTime inputDate)
        {
            DateTime nowdate = System.DateTime.Today;   
            if (inputDate > nowdate)
            {

                return 1;
            }
            else if (inputDate < nowdate)
            {
                return -1;
            }

            else
            {
               return 0;
            }
        }

        private void showCompetionMenu()
        {
          // List<string> compDates = _dataStore.getCompetitionDates();
            List<Competition> listOfCompetitions = _dataStore.getListOfCompetitions();

           foreach (Competition competition in listOfCompetitions)
           {
               Console.WriteLine("{0}", competition.getDate());
               foreach(Branch branch in competition.getListOfBranches())
               {
                   Console.WriteLine("\t{0}", branch.getName());
               }
           }
           Console.ReadKey();
           showSecretaryMainMenu();
        }

      
    }
}


