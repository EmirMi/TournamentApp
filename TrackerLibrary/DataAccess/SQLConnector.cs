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
        /// sparar personen i databasen
        /// </summary>
        /// <param name="data"></param>
        /// <returns>Info om en person/medlem</returns>
        public PersonData CreatePerson(PersonData data)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@FirstName", data.FirstName);
                p.Add("@LastName", data.Lastname);
                p.Add("@EmailAddress", data.EmailAddress);
                p.Add("@PhoneNumber", data.PhoneNumber);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spPeople_Insert", p, commandType: CommandType.StoredProcedure);

                data.Id = p.Get<int>("@id");

                return data;
            }
        }

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

        public TeamData CreateTeam(TeamData data)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                var p = new DynamicParameters();
                p.Add("@TeamName", data.TeamName);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spTeams_Insert", p, commandType: CommandType.StoredProcedure);

                data.Id = p.Get<int>("@id");

                foreach (PersonData tm in data.TeamMembers)
                {
                    p = new DynamicParameters();
                    p.Add("@TeamID", data.Id);
                    p.Add("@PersonId", tm.Id);

                    connection.Execute("dbo.spTeamMembers_Insert", p, commandType: CommandType.StoredProcedure);

                }

                return data;
            }
        }

        public List<PersonData> GetPerson_All()
        {
            List<PersonData> output;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString("Tournaments")))
            {
                output = connection.Query<PersonData>("dbo.spPeople_GetAll").ToList();
            }

            return output;
        }

    }
}
