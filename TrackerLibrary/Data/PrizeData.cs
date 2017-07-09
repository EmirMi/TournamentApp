using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Data
{
    /// <summary>
    /// Klassen som samlar all data om priserna
    /// </summary>
    public class PrizeData
    {
        /// <summary>
        /// Idenifierare för priset
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// nummerisk identifiering för platsen i 
        /// tävlingen(tex 2 för andra plats osv...)
        /// </summary>
        public int PlaceNumber { get; set; }
        /// <summary>
        /// prisets benäming
        /// </summary>
        public string PlaceName { get; set; }
        /// <summary>
        /// prisets storlek, dvs hur mycket man får
        /// för den specifika platsen, 0 om den inte
        /// används
        /// </summary>
        public decimal PrizeAmount { get; set; }
        /// <summary>
        /// priset i procentform (tex 0,4 för 40%) 
        /// </summary>
        public double PrizePercentage { get; set; }

        public PrizeData()
        {

        }

        public PrizeData(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumberValue = 0;
            int.TryParse(placeNumber, out placeNumberValue);
            PlaceNumber = placeNumberValue;

            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;
        }
    }
}
