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
        private const string PersonFile = "PersonData.csv";

        /// <summary>
        /// sparar personen i en textfil
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Info om en person</returns>
        public PersonData CreatePerson(PersonData data)
        {
            //Laddar in filen
            //Konvertera texten till en lista
            List<PersonData> people = PersonFile.FullFilePath().LoadFile().ConvertToPerson();
            //Hitta högsta ID
            int currentId = 1;

            if (people.Count > 0)
            {
                currentId = people.OrderByDescending(x => x.Id).First().Id + 1;
            }

            data.Id = currentId;
            //Lägga till nya data med ett nytt ID (+1)
            people.Add(data);
            //konvertera till list<string>
            //spara list<string> till textfilen
            people.SaveToPersonFile(PersonFile);

            return data;
        }

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

        public List<PersonData> GetPerson_All()
        {
            return PersonFile.FullFilePath().LoadFile().ConvertToPerson();
        }
    }
}
