using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Data;

namespace TrackerLibrary.DataAccess
{
    public class SQLConnector : IDataConnection
    {
        /// <summary>
        /// sparar priset i databasen
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Info om priset</returns>
        public PrizeData CreatePrize(PrizeData data)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@PlaceNumber", data.PlaceNumber);
                p.Add("@PlaceName", data.PlaceNumber);
                p.Add("@PrizeAmount", data.PrizeAmount);
                p.Add("@PrizePercentage", data.PrizePercentage);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPrizes_Insert", p, commandType: CommandType.StoredProcedure);

                data.Id = p.Get<int>("@id");

                return data;
            }
        }
    }
}
