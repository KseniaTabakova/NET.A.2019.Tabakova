using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlsToXml;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            string url1 = "https://github.com/AnzhelikaKravchuk?tab=repositories";
            string url2 = "https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU";          
            string url3 = "https://vk.com";
            string url4 = "https://github.com/AnzhelikaKravchuk?tab=repositories&hhh=u&";
            string url5 = "https://github.com/AnzhelikaKravchuk?tab=repositories&hhh=u&ggg&jjj=g";

            string[] urls = new string[] { url1, url2,url3, url4, url5 };

            File.WriteAllLines("urls.txt", urls);
            Console.WriteLine("URLs from file: ");

            foreach (string url in File.ReadAllLines("urls.txt"))
            {
                Console.WriteLine(url);
            }
    
            Console.WriteLine("Converting URL strings to XML...");
            UrlStringsToXml urlStringsToXml = new UrlStringsToXml("urls.txt", new Logs());

            var doc = urlStringsToXml.UrlsToXml();

            Console.WriteLine();
            Console.WriteLine("XML content:");
            Console.WriteLine(doc);
            urlStringsToXml.SaveUrlsToXml("urls.xml");

            Console.ReadLine();
        }
    }
}
