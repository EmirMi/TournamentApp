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
                p.Email = cols[3];
                p.PhoneNumber = cols[4];
                output.Add(p);
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
                lines.Add($"{p.Id},{p.FirstName},{p.Lastname},{p.Email},{p.PhoneNumber}");
            }

            File.WriteAllLines(fileName.FullFilePath(), lines);
        }

    }
}
