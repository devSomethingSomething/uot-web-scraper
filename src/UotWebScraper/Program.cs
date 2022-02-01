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
        private static void Main()
        {
            string url = "https://scholar.google.com/citations?user=1OyvitkAAAAJ&hl=en&oi=ao";

            //IEnumerable<GSProfile> urls;

            //using (var streamReader = new StreamReader("urls.csv"))
            //{
            //    using (var csvReader = new CsvReader(streamReader, CultureInfo.InvariantCulture))
            //    {
            //        urls = csvReader.GetRecords<GSProfile>().ToList();
            //    }
            //}

            //foreach (var url in urls)
            //{
            //    Console.WriteLine(url.Url);
            //}

            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlDocument htmlDocument = htmlWeb.Load(url);

            var nameAndSurname = htmlDocument.DocumentNode.SelectNodes("//div[@id='gsc_prf_in']");

            var citations = htmlDocument.DocumentNode.SelectNodes("//table[@id='gsc_rsb_st']/tbody/tr[1]/td[2]");

            var hIndex = htmlDocument.DocumentNode.SelectNodes("//table[@id='gsc_rsb_st']/tbody/tr[2]/td[2]");

            var i10Index = htmlDocument.DocumentNode.SelectNodes("//table[@id='gsc_rsb_st']/tbody/tr[3]/td[2]");

            //using (var streamWriter = new StreamWriter("test.csv"))
            //{
            //    using (var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture))
            //    {
            //        csvWriter.WriteField(nameAndSurname[0].InnerText);
            //    }
            //}

            Console.WriteLine(nameAndSurname[0].InnerText);

            Console.WriteLine(citations[0].InnerText);

            Console.WriteLine(hIndex[0].InnerText);

            Console.WriteLine(i10Index[0].InnerText);

            Console.WriteLine("Success");

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
