using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using System.Collections;
using Lord.ActiveDirectoryTools;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            // 180 doesnt have proper permissions
            // 181 doesnt have the directory
            // 182 is just great
            string path = "\\\\VMSRVGVS182\\c$\\ErrorLogger\\config.xml";

            /*try
            {
                Stream inStream = File.Open(path, FileMode.Open);
                inStream.Close();
            }
            catch (UnauthorizedAccessException authEx)
            {
                Console.WriteLine(String.Format("You do not have proper permissions: {0}", authEx.Message));
            }
            catch (DirectoryNotFoundException dirEx)
            {
                Console.WriteLine(String.Format("Directory not found: {0}", dirEx.Message));
            }
            catch
            {
                Console.WriteLine("Something went wrong, you just suck");
            }*/
            /*try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(path);
            }
            catch (UnauthorizedAccessException authEx)
            {
            }
            catch (DirectoryNotFoundException dirEx)
            {

            }*/
            //DictionaryEntry d = new DictionaryEntry();
            //d.Key = "hi";
            //d.Value = "everyone";

            // Just checking to see if the new AD Tools plays nicely
            ADManager manager = new ADManager(LordDomains.LORD);
            ADUser user = manager.GetUserByAccountName("tyler_ewing");
            Console.WriteLine(user.Email);


            Console.ReadLine();
        }
    }
}
