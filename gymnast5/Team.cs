using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gympa
{
    class Team
    {
        private List<string> _teamMembers = new List<string>(); // Lista av alla medlemmar i laget
        private string _teamName = null; // lagets namn

        //************************************
        //   CONSTRUCTOR
        //************************************
        public Team(string[] teamMembers, string teamName)
        {
            _teamName = teamName;
            foreach (string name in teamMembers)
            {
                _teamMembers.Add(name);
            }

        }

        internal string getTeamName()
        {
            return _teamName;
        }

        internal List<string> getListOfTeamMembers()
        {
            return _teamMembers;
        }
    }
}
