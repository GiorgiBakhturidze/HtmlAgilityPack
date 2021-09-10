using HtmlAgilityPack;
using System;
using System.Linq;

namespace HTMLAgilityPackConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            GetCryptocurrency();
            GetCryptocurrencyPrice(Console.ReadLine());
        }

        static string url = "https://coinmarketcap.com/all/views/all/";

        static void GetCryptocurrency()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDocument = web.Load(url);
            var names = htmlDocument.DocumentNode.SelectNodes("//a[contains(@class, 'cmc-table__column-name--name cmc-link')]").ToList();
            var prices = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'sc-131di3y-0 cLgOOr')]/a[contains(@class, 'cmc-link')]").ToList();
            for (int i = 0; i < names.Count - 1; i++)
            {
                Console.WriteLine(names[i].InnerText + " - " + prices[i].InnerText);
            }
        }

        static void GetCryptocurrencyPrice(string cryptocurrencyname) 
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDocument = web.Load(url);
            var names = htmlDocument.DocumentNode.SelectNodes("//a[contains(@class, 'cmc-table__column-name--name cmc-link')]").ToList();
            var prices = htmlDocument.DocumentNode.SelectNodes("//div[contains(@class, 'sc-131di3y-0 cLgOOr')]/a[contains(@class, 'cmc-link')]").ToList();
            for (int i = 0; i < names.Count - 1; i++)
            {
                if(cryptocurrencyname.ToLower() == names[i].InnerText.ToLower()) 
                {
                    Console.WriteLine(names[i].InnerText + " - " + prices[i].InnerText);
                }
            }
        }
    }
}
