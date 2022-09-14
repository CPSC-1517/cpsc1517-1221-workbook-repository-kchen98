using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class NhlRoster
    {
        // define data fields
        private int _playernumber;
        private string _playername;
        private const int MinNo = 0;
        private const int MaxNo = 98;

        // define properties
        public NhlPosition Position { get; private set; }

        public int PlayerNumber
        {
            get => _playernumber;
            set
            {
                if (value < MinNo || value > MaxNo)
                {
                    throw new ArgumentOutOfRangeException("Player number must be between 0 and 98");
                }
                _playernumber = value;
            }
        }

        public string PlayerName
        {
            get => _playername;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must contain text");
                }
                _playername= value.Trim();
            }
        }

        // Define a greedy constructor with parameters for no, name, and position
        public NhlRoster(int playernumber, string playername, NhlPosition position)
        {
            Position = position;
            PlayerNumber = playernumber;
            PlayerName = playername;
        }

        // Define ToString method
        public override string ToString()
        {
            return $"{PlayerNumber}, {PlayerName}, {Position}";
        }
    }
}
