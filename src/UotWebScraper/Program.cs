using CsvHelper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace UotWebScraper
{
    public class Program
    {
        private static List<User> users = new List<User>();

        private static List<Profile> profiles = new List<Profile>();

        private const string PROFILES_FILENAME = "profiles.csv";

        private const string USERS_FILENAME = "users.csv";

        private static void GetProfiles()
        {
            using (var streamReader = new StreamReader(PROFILES_FILENAME))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    profiles = csvReader.GetRecords<Profile>().ToList();
                }
            }
        }

        private static void GetUsers()
        {
            foreach (var profile in profiles)
            {
                HtmlWeb htmlWeb = new HtmlWeb();

                HtmlDocument htmlDocument = htmlWeb.Load(profile.Url);

                User user = new User();

                user.Name = htmlDocument.DocumentNode.SelectNodes("//div[@id='gsc_prf_in']")[0].InnerText.Split(" ").First();

                user.Surname = htmlDocument.DocumentNode.SelectNodes("//div[@id='gsc_prf_in']")[0].InnerText.Split(" ").Last();

                user.Citations = Convert.ToInt32(htmlDocument.DocumentNode.SelectNodes("//table[@id='gsc_rsb_st']/tbody/tr[1]/td[2]")[0].InnerText);

                user.HIndex = Convert.ToInt32(htmlDocument.DocumentNode.SelectNodes("//table[@id='gsc_rsb_st']/tbody/tr[2]/td[2]")[0].InnerText);

                user.I10Index = Convert.ToInt32(htmlDocument.DocumentNode.SelectNodes("//table[@id='gsc_rsb_st']/tbody/tr[3]/td[2]")[0].InnerText);

                users.Add(user);

                Console.WriteLine(user.ToString());

                Thread.Sleep(30000);
            }
        }

        private static void WriteUsers()
        {
            using (var streamWriter = new StreamWriter(USERS_FILENAME))
            {
                using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
                {
                    csvWriter.WriteRecords(users);
                }
            }
        }

        private static void Main()
        {
            GetProfiles();

            GetUsers();

            WriteUsers();

            Console.WriteLine("Success");

            Console.ReadKey(true);
        }
    }
}
