using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Data
{
    /// <summary>
    /// Klassen för ett lag
    /// </summary>
    public class TeamData
    {
        /// <summary>
        /// lista över lagets deltagare
        /// </summary>
        public List<PersonData> TeamMembers { get; set; } = new List<PersonData>();
        /// <summary>
        /// lagets namn
        /// </summary>
        public string TeamName { get; set; }

    }
}
