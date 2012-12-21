using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Net.NetworkInformation;
using System.IO;
using Lord.ActiveDirectoryTools;
using System.Threading;
using System.Data.SqlClient;
using System.Collections;
using System.Text.RegularExpressions;


namespace ErrorLoggerFrontEnd
{
    public partial class Form1 : Form
    {
        #region Member Fields
        private bool isApplied;
        private List<String> servers;
        private CheckBox[] checkBoxes;
        private ADUser adUser;
        private string dirName;
        private string connectionStr;
        private bool isImpersonating;
        private Impersonator impersonatedUser;
        private DictionaryEntry userCredentials;
        #endregion


        #region Constructor
        public Form1()
        {
            InitializeComponent();
            servers = new List<string>();
            dirName = System.Configuration.ConfigurationManager.AppSettings["configDirectory"];
            connectionStr = System.Configuration.ConfigurationManager.ConnectionStrings["localServersDB"].ConnectionString;
            userCredentials = new DictionaryEntry();
            isImpersonating = false;
            addUserButton.Enabled = false;
            removeUserButton.Enabled = false;
            setHDComponents(false);
            isApplied = false;
            checkBoxes = new CheckBox[3] { applicationCheckBox, securityCheckBox, systemCheckBox };
            RefreshComboBox();
        }
        #endregion


        #region Button Activations
        private void recipientsListViewSelectedIndexChanged(object sender, EventArgs e)
        {
            removeUserButton.Enabled = recipientsListView.SelectedItems.Count == 0 ? false : true;
        }

        private void usernameTextBoxTextChanged(object sender, EventArgs e)
        {
            // Each time a letter is typed it checks AD for the user and updates the Status message and button availability
            ADManager ad = new ADManager(LordDomains.LORD);

            // I only use a try if someone in case someone enters crazy characters *^#$^&
            try
            {
                adUser = usernameTextBox.Text != string.Empty ? ad.GetUserByAccountName(usernameTextBox.Text) : null;
            }
            catch (Exception exc) { Console.WriteLine(exc.Message); }

            bool userExists = adUser != null;
            addUserButton.Enabled = userExists;
            statusMessage.Text = userExists ? adUser.AccountName.Replace('_', ' ') + " is a valid user" : usernameTextBox.Text == string.Empty ? string.Empty : "That username does not exist in AD";
        }
        #endregion


        #region Button Clicks
        private void applyButtonClick(object sender, EventArgs e)
        {
            // Creates the XML config file and pushes it to the server
            // Maybe add some Threading here
            CreateConfigFile();
            SendConfigFile();
        }

        private void clearButtonClick(object sender, EventArgs e)
        {
            // Clear the form
            recipientsListView.Clear();
            customMessageTextBox.Text = string.Empty;
            usernameTextBox.Text = string.Empty;
        }

        private void removeUserButtonClick(object sender, EventArgs e)
        {
            // Removes a user from the Recipients list
            if (recipientsListView.SelectedItems.Count == 0)
                statusMessage.Text = "Please select a user from the list to remove";
            else
                recipientsListView.SelectedItems[0].Remove();
        }

        private void addUserButtonClick(object sender, EventArgs e)
        {
            // Adds the user's email to recipients List
            recipientsListView.Items.Add(adUser.Email);
            usernameTextBox.Text = string.Empty;
        }

        private void usernameTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            // Who actually clicks buttons with the mouse these days?
            if (e.KeyCode == Keys.Return && usernameTextBox.Text != string.Empty)
                addUserButton.PerformClick();
        }
        #endregion


        #region Keyboard Shortcuts
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.E):
                    editServerToolStripMenuItem.PerformClick();
                    return true;
                case (Keys.Control | Keys.A):
                    addServerToolStripMenuItem.PerformClick();
                    return true;
                case (Keys.Control | Keys.P):
                    checkPermissionsToolStripMenuItem.PerformClick();
                    return true;
                case (Keys.Control | Keys.S):
                    applyButton.PerformClick();
                    return true;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }
        #endregion


        #region MenuBar Actions
        private void aboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // About the application
            MessageBox.Show("Server Error Event Log Control Panel\nCreated by Super Fellow Intern Tyler Ewing", "About");
        }

        private void exitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Exit the application
            this.Close();
        }

        private void addServerToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Opens up an EditAdd Servers form with the Add Servers tab selected
            this.Cursor = Cursors.WaitCursor;
            EditAddServers f2 = new EditAddServers(0, servers);
            f2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            f2.ShowDialog();
            this.Cursor = Cursors.Default;
            servers = f2.Servers;
            RefreshComboBox();
            customMessageTextBox.Text = f2.customMessage;
            statusMessage.Text = f2.Message;
            Refresh();
        }

        private void editServerToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Opens up an EditAdd Servers form with the Edit Servers tab selected
            this.Cursor = Cursors.WaitCursor;
            EditAddServers f2 = new EditAddServers(1, servers);
            f2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            f2.ShowDialog();
            this.Cursor = Cursors.Default;
            servers = f2.Servers;
            RefreshComboBox();
            customMessageTextBox.Text = f2.customMessage;
            statusMessage.Text = f2.Message;
            Refresh();
        }

        private void checkPermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens up an EditAdd Servers form with the Check Permissions tab selected
            this.Cursor = Cursors.WaitCursor;
            EditAddServers f2 = new EditAddServers(2, servers);
            f2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            f2.ShowDialog();
            this.Cursor = Cursors.Default;
            servers = f2.Servers;
            RefreshComboBox();
            customMessageTextBox.Text = f2.customMessage;
            statusMessage.Text = f2.Message;
            Refresh();
        }

        private void keyboardShortcutsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(("Ctrl+E        Brings up the Edit Servers window\n" +
                             "Ctrl+A       Brings up the Add Servers window\n" +
                             "Ctrl+P        Brings up the Check Permissions window\n" +
                             "Ctrl+S        Send the Config File to the server"), "Keyboard Shortcuts");
        }
        #endregion


        // Holy crap that looks awful, this needs reworked later on
        #region Impersonate button
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            if (userCredentials.Key != null && userCredentials.Value != null)
            {
                isImpersonating = !isImpersonating;
                try
                {
                    if (isImpersonating)
                    {

                        impersonatedUser = new Impersonator(userCredentials.Key.ToString(), userCredentials.Value.ToString());
                        impersonatedUser.Impersonate();
                        toolStripSplitButton1.BackColor = Color.LightGreen;
                        statusMessage.Text = "Impersonating user: " + userCredentials.Key.ToString();

                    }
                    else
                    {
                        impersonatedUser.EndImpersonating();
                        toolStripSplitButton1.BackColor = Color.IndianRed;
                        statusMessage.Text = "Ended impersonation of user: " + userCredentials.Key.ToString();
                    }
                }
                catch { statusMessage.Text = "Invalid username or password"; }
            }
            else
            {
                ShowImpersonateDialog();
            }
        }

        // I may need a different method
        private void toolStripSplitButton1_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ShowImpersonateDialog();
        }
        #endregion


        #region Impersonate User Dialog
        private void ShowImpersonateDialog()
        {
            ImpersonateDialog loginDialog = new ImpersonateDialog();
            loginDialog.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            loginDialog.ShowDialog();
            // This needs reworked
            userCredentials.Key = loginDialog.username == String.Empty ? null : loginDialog.username;
            userCredentials.Value = loginDialog.password == String.Empty ? null : loginDialog.password;
            toolStripSplitButton1.Text = loginDialog.username == String.Empty ? "Impersonate" : loginDialog.username;
            Refresh();
        }
        #endregion


        #region Create XML Config File
        private void CreateConfigFile()
        {
            try
            {
                // creates the XML config file and returns a string path to it
                XmlTextWriter configFile = new XmlTextWriter("configFile.xml", null);
                configFile.WriteStartDocument();

                // Just some boring comments in the XML config file
                configFile.WriteComment("Configuration File for Error Event Logger Console and Service Application");
                configFile.WriteComment("Created by: Super Fellow Intern Tyler Ewing");
                configFile.WriteStartElement("Config");

                // Put the emails in a tag
                configFile.WriteStartElement("Recipients");
                foreach (ListViewItem i in recipientsListView.Items)
                {
                    // It looks a little silly but theres weird whitespace with ListViewItems
                    configFile.WriteString(i.Text.Trim() + "\n");
                }
                configFile.WriteEndElement();

                // Put the different logs selected in a tag
                configFile.WriteStartElement("Logs");
                foreach (var c in checkBoxes)
                {
                    configFile.WriteString(c.Checked ? c.Text + "\n" : string.Empty);
                }
                configFile.WriteEndElement();

                // Put the server in a tag
                configFile.WriteStartElement("Server");
                configFile.WriteString(serversComboBox.Text);
                configFile.WriteEndElement();

                // Put the custom message in a tag
                configFile.WriteStartElement("Message");
                configFile.WriteString(customMessageTextBox.Text);
                configFile.WriteEndElement();

                // Put the HD Space Monitoring in a tag
                if (checkBox1.Checked)
                {
                    configFile.WriteStartElement("HD");
                    configFile.WriteStartElement(percentFreeRadioButton.Checked ? "Percent" : "MB");
                    configFile.WriteString(percentFreeRadioButton.Checked ? percentFreeTextBox.Text : mbFreeTextBox.Text);
                    configFile.WriteEndElement();
                    configFile.WriteEndElement();

                    // I put in a tag that signifies if the users have already been emailed once about HD Space
                    //  if this weren't in here then the users would get emailed every 10 min until there was more space
                    // It is also important to know the time that the notification was given so that the person can be reminded
                    configFile.WriteStartElement("Notified");
                    configFile.WriteAttributeString("time", DateTime.Now.ToString());
                    configFile.WriteString("false");
                    configFile.WriteEndElement();
                }

                // I need to make more custom attributes n' stuff here

                // Close it up
                configFile.WriteEndElement();
                configFile.WriteEndDocument();
                configFile.Close();
            }
            catch { }
        }

        // I shouldnt be using this method
        //private void CreateServersFile()
        //{
        //    // creates the XML servers file and returns a string path to it
        //    XmlTextWriter newServers = new XmlTextWriter("servers.xml", null);
        //    newServers.WriteStartDocument();

        //    // Just some boring comments in the XML server file
        //    newServers.WriteComment("Servers XML file used to populate the drop down box in the Error Logger FrontEnd");
        //    newServers.WriteComment("Created by: Super Fellow Intern Tyler Ewing");
        //    newServers.WriteStartElement("Servers");

        //    // Put the servers in a tag
        //    servers.ForEach(delegate(String server)
        //    {
        //        newServers.WriteStartElement("ServerName");
        //        newServers.WriteString(server);
        //        newServers.WriteEndElement();
        //    });

        //    // Close it up
        //    newServers.WriteEndElement();
        //    newServers.WriteEndDocument();
        //    newServers.Close();
        //}
        #endregion


        #region Ping
        private bool PingServer(string server, int timeout)
        {
            // Pings the specified server with the specified timeout 
            // Returns a bool based on succcess
            Ping p = new Ping();
            PingReply reply = null;
            try
            {
                reply = p.Send(server, timeout);
            }
            catch { }

            return reply != null ? (reply.Status == IPStatus.Success ? true : false) : false;
        }
        #endregion


        #region Send Config File
        private void SendConfigFile()
        {
            // Sends the config file and changes 'isApplied' based on the success
            string path = "\\\\" + serversComboBox.Text + "\\c$\\" + dirName + "\\config.xml";

            // Check to see if server is alive
            // If not then just set the Status and leave
            if (!PingServer(serversComboBox.Text, 3000))
            {
                statusMessage.Text = "Server not found, send failed";
                isApplied = false;
                return;
            }

            try
            {
                Stream inStream = File.Open("configFile.xml", FileMode.Open);
                Stream outStream = File.Create(path);
                while (inStream.Position < inStream.Length)
                    outStream.WriteByte((byte)inStream.ReadByte());
                inStream.Close();
                outStream.Close();

                // Check to see if it transferred correctly
                if (File.Exists(path))
                {
                    statusMessage.Text = "Settings applied and sent successfully";
                    isApplied = true;
                    // Delete the local config file created
                    File.Delete("configFile.xml");
                }
            }
            catch (UnauthorizedAccessException)
            {
                isApplied = false;
                statusMessage.Text = "You do NOT have the correct permissions";
                ShowImpersonateDialog();
            }
            catch (DirectoryNotFoundException)
            {
                isApplied = false;
                statusMessage.Text = "Directory on server could not be found, creating Directory now";
                Directory.CreateDirectory("\\\\" + serversComboBox.Text + "\\" + dirName);
            }
            catch
            {
                isApplied = false;
                statusMessage.Text = "Problem pushing config file to server, try again";
            }
        }
        #endregion


        #region ComboBox Actions and helping Methods
        private void serversComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            // Grabs the XML config file form the remote server and fills out the fields
            recipientsListView.Items.Clear();
            usernameTextBox.Text = string.Empty;
            customMessageTextBox.Text = string.Empty;
            foreach (CheckBox c in checkBoxes)
            {
                c.Checked = false;
            }
            this.Cursor = Cursors.WaitCursor;
            LoadConfigXML(serversComboBox.Text);
            this.Cursor = Cursors.Default;
        }

        private void RefreshComboBox()
        {
            // Refreshes the ComboBox Items according to the servers List
            // If the List is empty it parses the servers XML file and fills the list then refreshes 
            if (servers.Count == 0)
                QueryDB();
            // Using XML for servers has been deprecated and replaced with a local DB
            //LoadServersXML();

            servers.Sort();
            serversComboBox.Items.Clear();

            servers.ForEach(delegate(string s)
            {
                serversComboBox.Items.Add(s);
            });

            if (servers.Contains(Environment.MachineName))
                serversComboBox.SelectedIndex = servers.IndexOf(Environment.MachineName);
            else { }
            //servers_comboBox.SelectedIndex = 0;
        }

        // Using XML for the servers is deprectaed and has been replaced with a local DB
        // This method should not be used anywhere anymore and will be taken out later
        /*private void LoadServersXML()
        {
            // Loads the servers XML file and fills the servers List
            XmlDocument doc = new XmlDocument();

            if (!File.Exists("servers.xml"))
            {
                servers.Add(Environment.MachineName);
                CreateServersFile();
            }
            else
            {
                doc.Load("servers.xml");
                XmlNodeList xnList = doc.SelectNodes("/Servers/ServerName");

                foreach (XmlNode xn in xnList)
                {
                    servers.Add(xn.InnerText);
                }
            }
        }*/
        #endregion


        #region DB Methods
        private void QueryDB()
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT Name FROM Server", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                try
                {
                    while (reader.Read())
                        servers.Add(reader[0].ToString());
                }
                finally { reader.Close(); }

                if (!servers.Contains(Environment.MachineName))
                    servers.Add(Environment.MachineName);
            }
        }

        private void InsertDataIntoDB()
        {
            using (SqlConnection conn = new SqlConnection(connectionStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Server", conn);
                cmd.ExecuteNonQuery();

                foreach (string s in servers)
                {
                    cmd = new SqlCommand("INSERT INTO [Server] (Name) VALUES (@Name)", conn);
                    cmd.Parameters.AddWithValue("@Name", s);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }
        #endregion


        #region Load Server Config XML
        private void LoadConfigXML(string remoteServer)
        {
            // Loads the XML config file from the specified remote server and fills out the fields on the Form
            XmlDocument doc = new XmlDocument();
            XmlNode xn;

            try
            {
                doc.Load("\\\\" + remoteServer + "\\c$\\" + dirName + "\\config.xml");

                // Grab the Recipients
                xn = doc.SelectSingleNode("/Config/Recipients");
                string[] tempRecips = Regex.Split(xn.InnerText.Trim(), "\n");
                foreach (string s in tempRecips)
                {
                    recipientsListView.Items.Add(s);
                }

                // Grab the Logs
                xn = doc.SelectSingleNode("/Config/Logs");
                string[] tempLogs = Regex.Split(xn.InnerText.Trim(), "\n");
                foreach (string s in tempLogs)
                {
                    switch (s)
                    {
                        case "Application":
                            applicationCheckBox.Checked = true;
                            break;
                        case "System":
                            systemCheckBox.Checked = true;
                            break;
                        case "Security":
                            securityCheckBox.Checked = true;
                            break;
                        default:
                            break;
                    }
                }

                // Grab the Custom Message
                xn = doc.SelectSingleNode("/Config/Message");
                customMessageTextBox.Text = xn.InnerText;

                // Grab the HD Space Monitoring Info
                xn = doc.SelectSingleNode("/Config/HD");
                switch (xn.FirstChild.Name)
                {
                    case "Percent":
                        checkBox1.Checked = true;
                        percentFreeRadioButton.Checked = true;
                        percentFreeTextBox.Text = xn.FirstChild.InnerText;
                        break;
                    case "MB":
                        checkBox1.Checked = true;
                        mbFreeRadioButton.Checked = true;
                        mbFreeTextBox.Text = xn.FirstChild.InnerText;
                        break;
                    default:
                        checkBox1.Checked = false;
                        break;
                }

                statusMessage.Text = "Config file loaded, settings not applied";
            }
            catch (UnauthorizedAccessException)
            {
                statusMessage.Text = "Could not load config file, you do not have correct permissions";
            }
            catch (DirectoryNotFoundException)
            {
                statusMessage.Text = "Could not load config file, may need to install Error Logger";
            }
            catch
            {
                statusMessage.Text = "Could not load config file, something went wrong";
            }
        }
        #endregion


        #region Application Closing
        private void Form1FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isImpersonating)
                toolStripSplitButton1.PerformButtonClick();

            // Using XML for storing the servers is deprecated
            //CreateServersFile();
            InsertDataIntoDB();

            if (isApplied)
                return;
            else
            {
                DialogResult r = MessageBox.Show("You haven't applied the settings.  Do you still want to exit?", "Warning", MessageBoxButtons.YesNo);
                if (r == System.Windows.Forms.DialogResult.Yes)
                    return;
                else
                    e.Cancel = true;
            }
        }
        #endregion


        #region HD Space Monitoring
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            setHDComponents(checkBox1.Checked);
        }

        private void setHDComponents(bool enabled)
        {
            percentFreeRadioButton.Enabled = enabled;
            percentFreeTextBox.Enabled = enabled;
            mbFreeRadioButton.Enabled = enabled;
            mbFreeTextBox.Enabled = enabled;
        }
        #endregion
    }
}