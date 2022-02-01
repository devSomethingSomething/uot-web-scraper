using CsvHelper;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace UotWebScraper
{
    public class Program
    {
        //private static string url;

        private static void Main()
        {
            IEnumerable<GSProfile> urls;

            using (var streamReader = new StreamReader("urls.csv"))
            {
                using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
                {
                    urls = csvReader.GetRecords<GSProfile>().ToList();
                }
            }

            foreach (var url in urls)
            {
                Console.WriteLine(url.Url);
            }

            //HtmlWeb htmlWeb = new HtmlWeb();

            //HtmlDocument htmlDocument = htmlWeb.Load(url);

            //var nameAndSurname = htmlDocument.DocumentNode.SelectNodes("//div[@id='gsc_prf_in']");

            //using (var streamWriter = new StreamWriter("test.csv"))
            //{
            //    using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            //    {
            //        csvWriter.WriteField(nameAndSurname[0].InnerText);
            //    }
            //}

            //Console.WriteLine(nameAndSurname[0].InnerText);

            //Console.WriteLine("Success");

            Console.ReadKey(true);
        }
    }

    public class GSProfile
    {
        public string Url { get; set; }
    }

    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Citations { get; set; }

        public int HIndex { get; set; }

        public int I10Index { get; set; }

        public override string ToString()
        {
            return $"{Name},{Surname}";
        }
    }
}
