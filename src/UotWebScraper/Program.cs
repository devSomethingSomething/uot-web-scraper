using HtmlAgilityPack;
using System;

namespace UotWebScraper
{
    public class Program
    {
        private static string url = "url";

        private static void Main()
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            HtmlDocument htmlDocument = htmlWeb.Load(url);

            var nameAndSurname = htmlDocument.DocumentNode.SelectNodes("//div[@id='gsc_prf_in']");

            Console.WriteLine(nameAndSurname[0].InnerText);

            Console.ReadKey(true);
        }
    }

    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Citations { get; set; }

        public int HIndex { get; set; }

        public int I10Index { get; set; }
    }
}
