using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace ErrorLoggerFrontEnd
{
    class AdminShareTest
    {
        public string report { get; set; }

        public AdminShareTest()
        {
            report = String.Empty;
        }

        public void DiscoverPermissions(string server)
        {
            string directory = "\\\\" + server + "\\c$";
            string createDirectory = directory + "\\AnotherTestDir";
            string file = createDirectory + "\\testFile.txt";
            report += Directory.Exists(directory) ? "Permission to view C:\n" : "NO permissions to view C:\n";

            try { Directory.CreateDirectory(createDirectory); }
            catch { }
            report += Directory.Exists(createDirectory) ? "Permission to create directory\n" : "NO permissions to create directory\n";

            try
            {
                using (Stream outStream = File.Create(file))
                {
                    outStream.WriteByte(63);
                }
            }
            catch { }

            report += File.Exists(file) ? "Permissions to write to created directory\n" : "NO permissions to write to created directory\n";

            try
            {
                File.Delete(file);
                report += "Permissions to delete file from created directory\n";
                Directory.Delete(createDirectory);
            }
            catch { report += "NO permissions to delete file from created directory\n"; }
        }
    }
}
