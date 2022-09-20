using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Team
    {
        // Define a read only property for the Coach
        // The Coach property is known as Aggregation/Composition when the field is an object
        public Coach Coach { get; private set; } = null!;

        // Define a auto-implemented read only property for Players
        public List<Player> Players { get; } = new List<Player>();

        // Define a method used to add a new Player to the Team
        public void AddPlayer(Player newPlayer)
        {
            // Validate that the newPlayer is not null
            if(newPlayer == null)
            {
                throw new ArgumentNullException("Player is required");
            }
            // Validate that the team size (23) is not full
            if (Players.Count >= 3)
            {
                throw new ArgumentException("Team is full. Cannot add any more players");
            }    
            // Validate that the newPlayer PrimaryNo is not already in use
            bool primaryNoFound = false;
            foreach (Player currentPlayer in Players)
            {
                if (currentPlayer.PrimaryNo == newPlayer.PrimaryNo)
                {
                    primaryNoFound = true;
                    break; // exit foreach statement
                }
            }
            if (primaryNoFound)
            {
                throw new ArgumentException("PrimaryNo is already in use by another player.");
            }

            // Add the newPlayer to the team
            Players.Add(newPlayer);

        }

        // Define a computed-property to return the total of Points of all players
        public int TotalPlayerPoints
        {
            get 
            {
                int totalPoints = 0;
                foreach (Player currentPlayer in Players)
                {
                    totalPoints += currentPlayer.Points;
                }
                return totalPoints;
            }
        }

        // Define a fully-implemented property with a backing field for TeamName
        private string _teamName = string.Empty;

        public string TeamName
        {
            get { return _teamName; }
            set
            {
                // Validate the new value is not null, an empty, or only whitespaces
                if(string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("TeamName is required");
                }
                // Validate the new value contains at least 5 or more characters
                if(value.Trim().Length < 5)
                {
                    throw new ArgumentException("TeamName must contain 5 or more characters");
                }
                _teamName = value;
            }
        }

        public Team(string teamName, Coach coach)
        {
            if (coach == null)
            {
                throw new ArgumentNullException("A Team requires a Coach.");
            }
            Coach = coach;
            TeamName = teamName;
        }

        public override string ToString()
        {
            return $"{TeamName},{Coach}";
        }
    }
}
