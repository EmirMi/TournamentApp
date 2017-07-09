using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Data
{
    /// <summary>
    /// Klassen för ett lag i ett möte
    /// </summary>
    public class MatchupEntryData
    {
        /// <summary>
        /// ett av lagen som deltar i matchen
        /// </summary>
        public TeamData TeamCompeting { get; set; }
        /// <summary>
        /// Lagets resultat i den specifika matchen (gjorda mål osv...)
        /// </summary>
        public double Score { get; set; }
        /// <summary>
        /// visar från vilket tidigare möte detta lag kom ut som segrare 
        /// </summary>
        public MatchupData ParentMatchUp { get; set; }
    }
}
