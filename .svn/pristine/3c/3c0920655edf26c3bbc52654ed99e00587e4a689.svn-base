using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Net.Mail;
using System.Xml;
using System.Collections;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;

namespace ErrorLoggerService
{
    class ErrorLoggerApp
    {
        #region Member Fields
        private EventLog _log;
        private Thread _thread;
        private int checkTime;
        private string configPath;
        private int messageID;
        private List<string> recipients;
        private List<string> logs;
        private string server;
        private string customMessage;
        private StringBuilder errors;
        private bool notified;
        private DictionaryEntry hdInfo;
        private int reminderIntervalMin;
        private string lastReminded;
        #endregion Memeber Fields


        #region Constructor
        public ErrorLoggerApp()
        {
            checkTime = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["checkTime"]);
            configPath = System.Configuration.ConfigurationManager.AppSettings["configDirectory"];
            reminderIntervalMin = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["HDReminderInterval"]);
            hdInfo = new DictionaryEntry();
            errors = new StringBuilder();
            messageID = 2;
            _log = new EventLog();

            if(!EventLog.SourceExists("ErrorLogger"))
                EventLog.CreateEventSource("ErrorLogger", "ErrorLoggerLog");
            _log.Source = "ErrorLogger";
            _log.Log = "ErrorLoggerLog";
        }
        #endregion


        #region OnStart and OnStop Methods
        public void Start()
        {
            // OnStart, Writes to the EventLog and Starts the Thread
            _log.WriteEntry("ErrorLoggerService started");
            _thread = new Thread(new ThreadStart(Execute));
            _thread.Start();
        }

        public void Stop()
        {
            // OnStop, Writes to the EventLog and terminates the Thread
            _log.WriteEntry("ErrorLoggerService stopped");

            if (_thread != null)
            {
                _thread.Abort();
                _thread.Join();
            }
        }
        #endregion


        #region Execute Method
        private void Execute()
        {
            try
            {
                while (true)
                {
                    // I wanna redo this
                    // Process logic
                    ReadConfigFile();
                    if (MissingConfig() || CheckErrors() || CheckHDSpace())
                        SendEmail(CreateEmail());
    
                    // Sleep it for 10 minutes
                    Thread.Sleep(600000);
                }
            }
            catch (ThreadAbortException)
            {
                _log.WriteEntry("Thread aborted");
            }
        }
        #endregion


        #region Config Exists
        private bool MissingConfig()
        {
            bool missing = !File.Exists(configPath);
            messageID = missing ? 2 : 1;
            return missing;
        }
        #endregion


        #region Read Config File
        private bool ReadConfigFile()
        {
            // Reads the config file and fills the member fields
            // If the config can't be found it sets the messageID appropriately
            //  so it will send out an email asking for a user to make one
            try
            {
                XmlDocument xml = new XmlDocument();
                XmlNode xn;
                xml.Load(configPath);

                xn = xml.SelectSingleNode("/Config/Recipients");
                recipients = Regex.Split(xn.InnerText.Trim(), "\n").ToList();

                xn = xml.SelectSingleNode("/Config/Logs");
                logs = Regex.Split(xn.InnerText.Trim(), "\n").ToList();

                xn = xml.SelectSingleNode("/Config/Server");
                server = xn.InnerText.Trim();

                xn = xml.SelectSingleNode("/Config/Message");
                customMessage = xn.InnerText;

                xn = xml.SelectSingleNode("/Config/Notified");
                notified = Convert.ToBoolean(xn.InnerText);
                lastReminded = xn.Attributes[0].Value;

                xn = xml.SelectSingleNode("/Config/HD");
                hdInfo.Key = xn.FirstChild.Name;
                hdInfo.Value = xn.FirstChild.InnerText;

                messageID = 1;
                return true;
            }
            catch
            {
                messageID = 2;
                return false;
            }
        }
        #endregion


        #region Check for Errors
        private bool CheckErrors()
        {
            // Checks for errors in each specified Log and creates an error message from each entry
            bool errorFound = false;

            logs.ForEach(delegate(string log)
            {
                Console.WriteLine(log.Trim());
                EventLog el = new EventLog(log);
                foreach (EventLogEntry entry in el.Entries)
                {
                    if (entry.EntryType == EventLogEntryType.Error && entry.TimeGenerated >= DateTime.Now.AddMinutes(-checkTime))
                    {
                        errorFound = true;
                        MakeErrorMessage(entry, log);
                    }
                }
            });

            return errorFound;
        }
        #endregion


        // This works but looks hideous; it needs to be rewritten badly
        #region Check HD Space
        private bool CheckHDSpace()
        {
            bool hasProblem = false;

            if (!notified)
            {
                DriveInfo disk = new DriveInfo("C:");
                if (hdInfo.Key.ToString() == "Percent")
                {
                    messageID = 3;
                    notified = true;

                    // Update the XML Config
                    XmlDocument xml = new XmlDocument();
                    xml.Load(configPath);
                    XmlNode node = xml.SelectSingleNode("/Config/Notified");
                    node.Attributes[0].Value = DateTime.Now.ToString();
                    node.InnerText = "true";
                    xml.Save(configPath);

                    // Calculates percentage of free space
                    //return (disk.AvailableFreeSpace * 1.0 / disk.TotalSize) * 100 < Convert.ToInt32(hdInfo.Value);
                    hasProblem = (disk.AvailableFreeSpace * 1.0 / disk.TotalSize) * 100 < Convert.ToInt32(hdInfo.Value);
                }
                else if (hdInfo.Key.ToString() == "MB")
                {
                    messageID = 3;
                    notified = true;

                    // Update the XML Config
                    XmlDocument xml = new XmlDocument();
                    xml.Load(configPath);
                    XmlNode node = xml.SelectSingleNode("/Config/Notified");
                    node.Attributes[0].Value = DateTime.Now.ToString();
                    node.InnerText = "true";
                    xml.Save(configPath);

                    //return disk.AvailableFreeSpace < Convert.ToInt32(hdInfo.Value) * Math.Pow(1024, 2);
                    hasProblem = disk.AvailableFreeSpace < Convert.ToInt32(hdInfo.Value) * Math.Pow(1024, 2);
                }
            }
            else
            {

                XmlDocument xml = new XmlDocument();
                xml.Load(configPath);
                XmlNode node = xml.SelectSingleNode("/Config/Notified");
                string lastNotify = node.Attributes[0].Value;

                if (DateTime.Now >= DateTime.Parse(lastNotify).AddHours(reminderIntervalMin))
                    node.InnerText = "false";

                xml.Save(configPath);
                //return false;
                hasProblem = false;
            }

            return hasProblem;
        }
        #endregion


        #region Create Email
        private MailMessage CreateEmail()
        {
            // Creates the email message based on the messageID and puts together all the pieces of the Body
            var email = new MailMessage();

            if (messageID == 1)
            {
                recipients.ForEach(delegate(String name)
                {
                    email.To.Add(new MailAddress(name.Trim()));
                });

                email.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["EmailFrom"]);
                email.Bcc.Add(new MailAddress("tyler_ewing@lord.com"));
                email.Subject = String.Format("Error in Event Log of [{0}]", server);
                email.Body = String.Format("{0}\nThere has been error(s) on [{1}]:\n\n{2}", customMessage, server, errors);
            }

            if (messageID == 2)
            {
                email.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["EmailFrom"]);
                email.To.Add(new MailAddress("tyler_ewing@lord.com"));
                email.Subject = String.Format("Error locating Configuration File on [{0}]", Environment.MachineName);
                email.Body = String.Format("The configuration file could not be found on [{0}]. No errors will be reported until there is a configuration file in {1}. To create a configuration file run the Error Logger Front End.", Environment.MachineName, configPath);
            }

            if (messageID == 3)
            {
                recipients.ForEach(delegate(String name)
                {
                    email.To.Add(new MailAddress(name.Trim()));
                });

                email.From = new MailAddress(System.Configuration.ConfigurationManager.AppSettings["EmailFrom"]);
                email.Bcc.Add(new MailAddress("tyler_ewing@lord.com"));
                email.Subject = String.Format("HD Space Warning on [{0}]", server);
                email.Body = String.Format("The HD space on [{0}] is over the limit of {1} {2} free. It is recommended that you make space.", server, hdInfo.Value, hdInfo.Key);
            }

            return email;
        }
        #endregion


        #region Send Email
        private void SendEmail(MailMessage email)
        {
            // Sends the email then clears some of the fields
            try
            {
                SmtpClient smtp = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["smtp"]);
                smtp.Send(email);
            }
            finally { ClearFields(); }
        }
        #endregion


        #region Make Error Message
        private void MakeErrorMessage(EventLogEntry entry, string log)
        {
            // Takes an entry and then formats and makes it look nice for the email
            errors.Append("Event Type: \t" + entry.EntryType + "\nEvent Log: \t\t" + log + "\nEvent Source:\t" + entry.Source
                        + "\nEvent Category:\t" + entry.Category + "\nEvent ID: \t\t" + entry.InstanceId + "\nDate: \t\t"
                        + entry.TimeGenerated + "\nUser: \t\t" + entry.UserName + "\nServer: \t\t" + server
                        + "\nDescription:\n" + entry.Message + "\n\n");
        }
        #endregion


        #region Clear Everything
        private void ClearFields()
        {
            recipients.Clear();
            errors = new StringBuilder();
            hdInfo = new DictionaryEntry();
        }
        #endregion
    }
}





