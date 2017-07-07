using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// klassen för en turnering/cup
    /// </summary>
    public class TournamentData
    {
        /// <summary>
        /// Turneringen/cupens namn
        /// </summary>
        public string TournamentName { get; set; }
        /// <summary>
        /// Deltagaravgift
        /// </summary>
        public decimal EntryFee { get; set; }
        /// <summary>
        /// lista över deltagande lag
        /// </summary>
        public List<TeamData> EnteredTeams { get; set; } = new List<TeamData>();
        /// <summary>
        /// lista över priserna man kan vinna
        /// </summary>
        public List<PrizeData> Prizes { get; set; } = new List<PrizeData>();
        /// <summary>
        /// lista över omgångarna
        /// </summary>
        public List<MatchupData> Rounds { get; set; } = new List<MatchupData>();

    }
}
