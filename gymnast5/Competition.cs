using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class Competition
    {
        private List<Branch> _listOfBranches = new List<Branch>(); // En lista med alla grenarna som ingår i tävlingen
    

        private string _competitionDate; // Datum för när tävlingen kommer att hållas   
        List<string> _listOfparticipatingTeams = new List<string>(); // Håller vilka lag som har registrerat sig för tävlingen

       
        // konstruktor
        public Competition(string competitionDate)
        {
            _competitionDate = competitionDate;
        }



        internal string getDate()
        {
            return _competitionDate;
        }


        internal void registerTeamForParticipating(string teamName)
        {
            _listOfparticipatingTeams.Add(teamName);
        }


        internal List<Branch> getListOfBranches()
        {
            return _listOfBranches;
        }

        internal void addBranch(Branch branch)
        {
            _listOfBranches.Add(branch);
        }

        // returnera item x i listan av grenar, 1 är först i listan.
        internal Branch getBranch(int x)
        {
           return _listOfBranches[x-1];
        }

        internal List<string> getListOfCompetingTeams()
        {
            return _listOfparticipatingTeams;
        }
    }
}