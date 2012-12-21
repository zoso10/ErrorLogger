using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Xml;
using System.Text.RegularExpressions;

namespace HD_Space_Tests
{
    class Tests
    {
        static void Main(string[] args)
        {
            // Good stuff in here 
            /*DriveInfo disk = new DriveInfo("C:");
            StringBuilder b = new StringBuilder("There is ");
            b.Append(disk.AvailableFreeSpace);
            b.Append(" bytes available out of ");
            b.Append(disk.TotalSize);
            b.Append(" bytes.\nMeaning ");
            b.Append((disk.TotalSize - disk.AvailableFreeSpace) / (Math.Pow(1024.0, 3)));
            b.Append(" GB used");
            Console.WriteLine(b);*/

            // Lets play with loading the XML
            DictionaryEntry hdSpace = new DictionaryEntry();
            XmlDocument xmlDoc = new XmlDocument();
            XmlNodeList xnList;
            xmlDoc.Load(@"C:\ErrorLogger\config.xml");
            XmlNode xn = xmlDoc.SelectSingleNode("/Config/HD");
            string type;
            string cap;

            type = xn.FirstChild.Name;
            cap = xn.FirstChild.InnerText;
            Console.WriteLine(type);
            Console.WriteLine(cap);


            // Got this one figured out
            // Maybe we can get all the recipients in a list in one line
            /*XmlDocument xml = new XmlDocument();
            xml.Load(@"C:\ErrorLogger\config.xml");
            XmlNodeList xn = xml.SelectNodes("/Config/Recipients");
            List<string> recips = Regex.Split(xn[0].InnerText, "\n").ToList();
            foreach (var s in recips)
            {
                Console.WriteLine(s);
            }*/

            


            Console.ReadLine();
        }
    }
}
