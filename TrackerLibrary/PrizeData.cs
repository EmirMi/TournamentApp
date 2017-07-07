using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Klassen som samlar all data om priserna
    /// </summary>
    public class PrizeData
    {
        /// <summary>
        /// prisets "nummer/siffra" i rangordningen
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// prisets benäming
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// prisets storlek
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// priset i procentform
        /// </summary>
        public double PrizePercentage { get; set; }
    }
}
