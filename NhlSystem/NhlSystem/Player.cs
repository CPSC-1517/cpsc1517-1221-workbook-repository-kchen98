using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystem
{
    public class Player : Person
    {
        public Position Position { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int PrimaryNo { get; set; }

        // Define a read-only computed property for Points
        public int Points
        {
            get
            {
                return Goals + Assists;
            }
        }

        // Define constructor that passes fullName to base class
        public Player(string fullName, Position position, int primaryNo) : base(fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = 0;
            Assists = 0;
        }

        public Player(string fullName, Position position, int primaryNo, int goals, int assists) : base(fullName)
        {
            Position = position;
            PrimaryNo = primaryNo;
            Goals = goals;
            Assists = assists;
        }
    }
}
