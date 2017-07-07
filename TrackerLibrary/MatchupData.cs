using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Klassen för en specifik match 
    /// </summary>
    public class MatchupData
    {
        /// <summary>
        /// lagen som deltar i den specifika matchen
        /// </summary>
        public List<MatchupEntryData> Entries { get; set; } = new List<MatchupEntryData>();
        /// <summary>
        /// matchen vinnare
        /// </summary>
        public TeamData Winner { get; set; }
        /// <summary>
        /// visar vilken omgång denna mcth tillhör
        /// </summary>
        public int MatchupRound { get; set; }

    }
}
