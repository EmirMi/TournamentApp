using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Data;

namespace TrackerLibrary.DataAccess
{
    public interface IDataConnection
    {
        PrizeData CreatePrize(PrizeData data);
        PersonData CreatePerson(PersonData data);
    }
}
