using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class NhlTeam
    {
        // Define an auto-implemented property with a private set 
        // for the Conference of type NhlConference
        public NhlConference Conference { get; private set; }

        // Define an auto-implemented property with a private set 
        // for the Division of type NhlDivision
        public NhlDivision Division { get; private set; }

        // Define a full-implemented property for the Name of type string.
        // Validate that the new name is not null or an empty or
        // contains just whitespaces.
        // Trim all leading and trailing whitespaces
        private string _name; // data field for the Name property
        private string _city;
        private int _gamesplayed;
        private int _wins;
        private int _losses;
        private int _overtimelosses;
        private int _points;
        
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text.");
                }
                _name = value.Trim();
            }
        }

        public string City
        {
            get => _city;
            set => _city = value;
        }

        public int GamesPlayed
        {
            get => _gamesplayed;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Game played cannot be negative");
                }
                _gamesplayed = value;   
            }
        }

        public int Wins
        {
            get => _wins;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Wins cannot be negative");
                }
                _wins = value;
            }
        }

        public int Losses
        {
            get => _losses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Losses cannot be negative");
                }
                _losses = value;
            }
        }

        public int OvertimeLosses
        {
            get => _overtimelosses;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Overtime losses cannot be negative");
                }
                _overtimelosses = value;
            }
        }

        public int Points
        {
            get => (Wins * 2) + OvertimeLosses;
        }

        // Define an auto-implemented property with a private set for players
        public List<NhlRoster> players { get; private set; }
        private const int MaxPlayers = 23;

        public void AddPlayer(NhlRoster currentPlayer)
        {
            if (players.Count >= MaxPlayers)
            {
                throw new ArgumentException("Roster is full. Remove a player first");
                players.Add(currentPlayer);
            }
        }
        public void RemovePlayer(int playerNo)
        {
            // Remove from the Players list the player with the matching playerNo.
            // Throw an ArgumentException if the playerNo does not exists
            bool foundPlayer = false;
            int playerIndex = -1;
            for (int index = 0; index < players.Count; index++)
            {
                if (Players[index].No == playerNo)
                {
                    foundPlayer = true;
                    playerIndex = index;
                    index = players.Count; // stop loop
                }
            }
            if (!foundPlayer)
            {
                throw new ArgumentException($"Player ${playerNo} is not on the team");
            }
            players.RemoveAt(playerIndex);
        }
        public NhlTeam(NhlConference conference, NhlDivision division, string name, string city, List<NhlRoster> players)
        {
            if (players == null)
            {
                players = new List<NhlRoster>();
            }
            else
            {
                NhlRoster.PlayerName = players;
            }
            Conference = conference;
            Division = division;
            Name = name;
            this.City = city;

            GamesPlayed = 0;
            Wins = 0;
            Losses = 0;
            OvertimeLosses = 0;
        }

        public NhlTeam(NhlConference conference, NhlDivision division, string name, string city)
        {
            Conference = conference;
            Division = division;
            Name = name;
            this.City = city;

            GamesPlayed = 0;
            Wins = 0;
            Losses = 0;
            OvertimeLosses = 0;
        }

        public override string ToString()
        {
            //return base.ToString();
            return $"{Conference}, {Division}, {Name}, {City}, {GamesPlayed}, {Wins}, {Losses}, {OvertimeLosses}";
        }
    }
}
