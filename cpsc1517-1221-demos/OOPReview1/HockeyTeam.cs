using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPReview1
{
    public class HockeyTeam
    {
        public enum HockeyConference
        {
            Eastern,
            Western
        }

        public enum HockeyDivision
        {
            Metropolitan,
            Atlantic,
            Central,
            Pacific
        }

        // Define data fields for storing data
        private HockeyConference _conference;
        private HockeyDivision _division;
        // Define fully-implemented properties for the data fields
        public HockeyConference Conference
        {
            get
            {
                return _conference; 
            }
        }

        public HockeyDivision Division
        {
            get
            {
                return _division;
            }
            set
            {
                _division = value;
            }
        }
    }    
}
