using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Data;
using TrackerLibrary.DataAccess.TextAssets;

namespace TrackerLibrary.DataAccess
{
    public class TextConnector : IDataConnection
    {
        private const string PrizesFile = "PrizeData.csv";
        /// <summary>
        /// sparar priset i en textfil
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Info om priset</returns>
        public PrizeData CreatePrize(PrizeData data)
        {
            //Laddar in filen
            //Konvertera texten till en lista
            List<PrizeData> prizes = PrizesFile.FullFilePath().LoadFile().ConvertToPrize();
            //Hitta högsta ID
            int currentId = 1;

            if (prizes.Count > 0)
            {
                currentId = prizes.OrderByDescending(x => x.Id).First().Id + 1;
            }

            data.Id = currentId;
            //Lägga till nya data med ett nytt ID (+1)
            prizes.Add(data);
            //konvertera till list<string>
            //spara list<string> till textfilen
            prizes.SaveToPrizeFile(PrizesFile);

            return data;
        }
    }
}
