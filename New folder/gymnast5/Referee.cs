using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
   class RefereeMenu
    {
        private DataStore _dataStore = null; // referens till dataStore;
       

        //**************************************
        //   CONSTRUCTOR
        //**************************************
        public RefereeMenu(ref DataStore dataStore)
        {
            _dataStore = dataStore;
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
            Console.WriteLine("=        DOMARE           =");
            Console.WriteLine("=                         =");
            Console.WriteLine("===========================");
            Console.WriteLine();
            Console.ResetColor();

            string userName = LogIn("Ange användarnamn: ");
            string password = LogIn("Ange Lösenord: ");
            // verifiera användarnamn och lösenord från datastore
            Dictionary<string, string> refs = _dataStore.getListOfReferees();
            if (refs.ContainsKey(userName))
            {
                if (password == refs[userName])
                {
                    return true; // rätt lösenord
                }
            }
            return false; // ingen träff gällande lösenord och/eller användarnamn

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
        internal void showRefereeMainMenu()
        {
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
            Console.WriteLine("1 Se förfrågningar  ");
            Console.WriteLine("2 Välj aktuell tävling att dömma i");

            Console.WriteLine();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {

                case 0:
                    Console.WriteLine();
                    break;

                case 1:
                    Console.WriteLine();
                    break;

                case 2:
                    showDate();
                    break;
            }



        }
        //***************************************
        //  SHOW DATE
        //***************************************
        private void showDate()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=======================================");
            Console.WriteLine("=  Du är registrerad att dömma        =");
            Console.WriteLine("=  i följande tävlingar.              =");
            Console.WriteLine("=  Var vänlig välj aktuell tävling    =");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            List<Competition> listOfCompetitions = _dataStore.getListOfCompetitions();
            int i = 1;
            foreach (Competition competition in listOfCompetitions)
            {
                Console.WriteLine("[{0}] {1}", i, competition.getDate());
                i++;
            }

            Console.WriteLine();
            int chosenDate = int.Parse(Console.ReadLine());
           
            switch (chosenDate)
            {
                case 0:
                    break;

                default:
                     chosenDate--; // listand index startar på noll men visas som om den har positionen 1. 
                    chooseBranch(chosenDate);
                    break;
                
            }
        }

        //***********************************
        //  CHOOSE BRANCH
        //***********************************
        private void chooseBranch(int chosenDate)
        {
            List<Competition> competitions = _dataStore.getListOfCompetitions();
            string date = competitions[chosenDate].getDate();
            Console.WriteLine("Du valde tävlingen för datum {0}", date);
            Console.WriteLine();  
            Branch branchToJudge = competitions[chosenDate].getBranch(1);// hardcoded to judge in first branch defined in list
            Console.WriteLine("Du ska döma i grenen {0}", branchToJudge.getName());
            judgingMenu(competitions[chosenDate], branchToJudge);
          // competition[id].ListAllEventsAndBranches()
            // output 
            //#1 event1.branch1
            //#2 event1.branch2
            //#3 event2.branch1
            // competition[id].getEventWithID[id2].getBranchWithId[id3]
            //Console.WriteLine(DataStore.ListOfBranches);
           // Console.WriteLine(DataStore._listOfBranches);

        }

        private void judgingMenu(Competition competition, Branch branch)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("=======================================");
            Console.WriteLine("=                                     =");
            Console.WriteLine("=         Sätt dina poäng             =");
            Console.WriteLine("=                                     =");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            foreach (String teamName in competition.getListOfCompetingTeams())
            {
                Team team = _dataStore.getTeam(teamName);
                foreach(string name in team.getListOfTeamMembers() )
                {
                    Console.Write("Poäng för {0} i grenen {1} : ", name, branch.getName());
                    string points = Console.ReadLine();
                   
                }
            }
        }
    }
}



