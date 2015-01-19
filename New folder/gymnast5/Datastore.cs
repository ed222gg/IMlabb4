using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
 
    class DataStore
    { 
        //  lista innehållandee namn, lösenord
        Dictionary<string, string> _listOfReferees = new Dictionary<string, string>();
        Dictionary<string, string> _listOfSecretaries = new Dictionary<string, string>();
        List<Competition> _listOfCompetitions = new List<Competition>();
        List<Branch> _listOfBranches = new List<Branch>();
        List<Team> _listOfTeams = new List<Team>();
   
        
        
        internal Competition createCompetition(string compDate) 
        {
            Competition newCompetition = null;
            if(_listOfCompetitions.
                Where(x => x.getDate() == compDate).FirstOrDefault() == null) {
                   newCompetition = new Competition(compDate);
                _listOfCompetitions.Add(newCompetition);       
            }
            else
            {
                throw new Exception("Bara en tävling får finnas på samma datum.");
              
            } // kolla om getDate är finns i compdate listan. Hittas ingen matchning så lägg till tävlingsdatumet i listan.
            //Hittas en matchning så throw new Exeption
            return newCompetition; 
        }


       /// <summary>
       /// Add a new competition to the datastore.
       /// </summary>
       /// <param name="competitionToAdd">Competition object to add to the list.</param>
   /*
    *  använd CreateCompetition istället då den har koll för duplicerade datum
    * public void addCompetition(Competition competitionToAdd) {
            _listOfCompetitions.Add(competitionToAdd);
        }
   
    */

        internal void setupDummyDataForTesting()
        {
            // Lägger till några referees med användarnamn och lösenord
            _listOfReferees.Add("kalle","123");
            _listOfReferees.Add("nisse", "123");
            _listOfReferees.Add("johan", "123");
            _listOfReferees.Add("eva", "123");
            _listOfReferees.Add("sara", "123");
            _listOfReferees.Add("marie", "123");
        
            // Lägger till några sekreterare
            _listOfSecretaries.Add("sec", "123");
            _listOfSecretaries.Add("adam", "123");


            // Lägger till lag
            _listOfTeams.Add( new Team(new string[] {"Björn","Benny","Olle"}, "Team 1") );
            _listOfTeams.Add(new Team(new string[] { "Adam", "Bertil", "Ceasar" }, "Team 2"));

            

            // Lägger till data för datum
            _listOfCompetitions.Add(new Competition("2015-12-12"));
            _listOfCompetitions.Add(new Competition("2015-12-11"));
            foreach (Competition competition in _listOfCompetitions)
        	{
                // Lägger till grenar
                competition.addBranch(new Branch("Barr") );
                competition.addBranch(new Branch("Ringar"));
              


                // Alla registrera sig för alla tävlingarna i testdatan
                competition.registerTeamForParticipating("Team 1"); // Lagnamnen ska matcha lagnamnen ovanför
                competition.registerTeamForParticipating("Team 2");
               
        	}
           
        }

        internal Dictionary<string,string> getListOfReferees()
        {
            return _listOfReferees;
        }

        internal void addReferee(string name, string password)
        {
            _listOfReferees.Add(name, password);
        } 
        
        internal Dictionary<string, string> getListOfSecretaries()
        {
            return _listOfSecretaries;
        }

        internal void addSecretary(string name, string password)
        {
            _listOfSecretaries.Add(name, password);
        } 

        internal List<Competition> getListOfCompetitions()
        {
            return _listOfCompetitions;
        }

       /* ta bort
        * internal List<Branch> getListOfBranches()
        {
            return _listOfBranches;
        }
        */

        
        internal List<string> getCompetitionDates()
        { 
            // onödigt att skapa lista av datum när competition innehåller datumet 
            //bättre att anropa getListOfCompetition();
            List<string> competitionDates = new List <string>();
            foreach (Competition competition in _listOfCompetitions)
            {
                competitionDates.Add(competition.getDate());
            }
            return competitionDates;
        }

        internal Team getTeam(string teamName)
        {
            foreach (Team team in _listOfTeams)
	        {
                if(teamName == team.getTeamName() )
                    return team;
	        }
            return null;
        }
    }

  
}
   

