using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Data;

namespace TrackerLibrary.DataAccess.TextAssets
{
    public static class TextConnectorAssets
    {
        public static string FullFilePath(this string fileName)
        {
            //C:\Users\emirm\Desktop\C#\Projects\TournamentTracker\PrizeData.csv
            return $"{ ConfigurationManager.AppSettings["filePath"] }\\{ fileName }";
        }

        public static List<string> LoadFile(this string file)
        {
            if (!File.Exists(file))
            {
                return new List<string>();
            }

            return File.ReadAllLines(file).ToList();
        }

        public static List<PrizeData> ConvertToPrize(this List<string> lines)
        {
            List<PrizeData> output = new List<PrizeData>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PrizeData p = new PrizeData();
                p.Id = int.Parse(cols[0]);
                p.PlaceNumber = int.Parse(cols[1]);
                p.PlaceName = cols[2];
                p.PrizeAmount = decimal.Parse(cols[3]);
                p.PrizePercentage = double.Parse(cols[4]);
                output.Add(p);
            }
        
                return output;
        }

        public static List<PersonData> ConvertToPerson(this List<string> lines)
        {
            List<PersonData> output = new List<PersonData>();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                PersonData p = new PersonData();
                p.Id = int.Parse(cols[0]);
                p.FirstName = cols[1];
                p.Lastname = cols[2];
                p.EmailAddress = cols[3];
                p.PhoneNumber = cols[4];
                output.Add(p);
            }

            return output;
        }

        public static List<TeamData> ConvertToTeam(this List<string> lines, string personFileName)
        {
            List<TeamData> output = new List<TeamData>();
            List<PersonData> people = personFileName.FullFilePath().LoadFile().ConvertToPerson();

            foreach (string line in lines)
            {
                string[] cols = line.Split(',');

                TeamData t = new TeamData();
                t.Id = int.Parse(cols[0]);
                t.TeamName = cols[1];

                string[] personIds = cols[2].Split('|');

                foreach (string id in personIds)
                {
                    t.TeamMembers.Add(people.Where(x => x.Id == int.Parse(id)).First());
                }
            }

            return output;
        }

        public static void SaveToPrizeFile(this List<PrizeData> data, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PrizeData p in data)
            {
                lines.Add($"{p.Id},{p.PlaceNumber},{p.PlaceName},{p.PrizeAmount},{p.PrizePercentage}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToPersonFile(this List<PersonData> data, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (PersonData p in data)
            {
                lines.Add($"{p.Id},{p.FirstName},{p.Lastname},{p.EmailAddress},{p.PhoneNumber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        public static void SaveToTeamFile(this List<TeamData> data, string fileName)
        {
            List<string> lines = new List<string>();

            foreach (TeamData t in data)
            {
                lines.Add($"{ t.Id},{ t.TeamName },{ ConvertPersonListToString(t.TeamMembers) }");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

        private static string ConvertPersonListToString(List<PersonData> people)
        {
            string output = "";

            if(people.Count == 0)
            {
                return "";
            }

            foreach(PersonData p in people)
            {
                output += $"{ p.Id}|";
            }

            output = output.Substring(0, output.Length - 1);

            return output;

        }
    }
}
