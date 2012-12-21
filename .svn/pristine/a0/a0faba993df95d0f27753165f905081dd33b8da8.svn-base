using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Security.Principal;
using System.IO;

namespace ErrorLoggerFrontEnd
{
    public partial class EditAddServers : Form
    {
        #region Member Fields
        public List<String> Servers { get; set; }
        public int Additions { get; set; }
        public int Edits { get; set; }
        public string Message { get; set; }
        public string customMessage { get; set; }
        #endregion


        #region Constructor
        public EditAddServers(int tabIndex, List<String> servers)
        {
            InitializeComponent();
            this.Servers = servers;
            Additions = 0;
            Edits = 0;
            editAddTabControl.SelectedIndex = tabIndex;
            refreshComboBox(serverEditComboBox);
            refreshComboBox(comboBox1);
            addButton.Enabled = false;
            pingButton.Enabled = false;
            applyButton.Enabled = false;
            deleteButton.Enabled = false;
        }
        #endregion


        #region Create Message
        private void CreateMessage()
        {
            Message = string.Empty;
            // Proper grammar is important
            Message += Additions + (Additions == 1 ? " server added and " : " servers added and ");
            Message += Edits + (Edits == 1 ? " server edited" : " servers edited");
        }
        #endregion


        #region Form Button Clicks
        private void okButtonClick(object sender, EventArgs e)
        {
            // OK Button
            if (serverNameAddTextBox.Text.ToUpper() != string.Empty && !isDuplicate(serverNameAddTextBox.Text.ToUpper()))
            {
                Servers.Add(serverNameAddTextBox.Text.ToUpper());
                ++Additions;
            }
            customMessage += nicknameAddTextBox.Text + "\n" + applicationAddTextBox.Text + "\n" + groupAddTextBox.Text;
            this.Close();
        }

        private void cancelButtonClick(object sender, EventArgs e)
        {
            // Cancel Button
            this.Close();
        }
        #endregion


        #region Add Tab
        private void serverNameAddTextBoxTextChanged(object sender, EventArgs e)
        {
            // Activates the Button only if there is text in the TextBox
            addButton.Enabled = serverNameAddTextBox.Text != String.Empty ? true : false;
            pingButton.Enabled = serverNameAddTextBox.Text != String.Empty ? true : false;
        }

        private void addButtonClick(object sender, EventArgs e)
        {
            // Add server button
            if (!isDuplicate(serverNameAddTextBox.Text.ToUpper()) && serverNameAddTextBox.Text != string.Empty)
            {
                Servers.Add(serverNameAddTextBox.Text.ToUpper());
                customMessage += nicknameAddTextBox.Text + "\n" + applicationAddTextBox.Text + "\n" + groupAddTextBox.Text;
                statusAddMessage.Text = "[" + serverNameAddTextBox.Text.ToUpper() + "] was added";
                ++Additions;
                serverNameAddTextBox.Clear();
                nicknameAddTextBox.Clear();
                groupAddTextBox.Clear();
                applicationAddTextBox.Clear();
                refreshComboBox(serverEditComboBox);
                refreshComboBox(comboBox1);
            }
            else
            {
                statusAddMessage.Text = "[" + serverNameAddTextBox.Text.ToUpper() + "] is a duplicate and was not added";
            }
        }

        private void pingButtonClick(object sender, EventArgs e)
        {
            // Ping server Button
            statusAddMessage.Text = "Pinging server...";
            this.Cursor = Cursors.WaitCursor;
            try
            {
                Ping p = new Ping();
                PingReply r = p.Send(serverNameAddTextBox.Text.ToUpper(), 3000);
                if (r.Status == IPStatus.Success) { }
                statusAddMessage.Text = "[" + serverNameAddTextBox.Text.ToUpper() + "] is alive";
            }
            catch
            {
                statusAddMessage.Text = "[" + serverNameAddTextBox.Text.ToUpper() + "] did not respond";
            }

            this.Cursor = Cursors.Default;
        }

        private void serverNameAddTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            // Hit the Enter key instead of having to click Add Button
            if (e.KeyCode == Keys.Return)
                addButton.PerformClick();
        }
        #endregion


        #region Edit Tab
        private void serverEditComboBoxTextChanged(object sender, EventArgs e)
        {
            // Activates the Button only if there is text in the TextBox
            if (serverEditComboBox.Text == string.Empty)
            {
                deleteButton.Enabled = false;
                applyButton.Enabled = false;
            }
            else
            {
                deleteButton.Enabled = true;
                applyButton.Enabled = true;
            }
        }

        private void applyButtonClick(object sender, EventArgs e)
        {
            // Apply settings to server button
            statusEditMessage.Text = "[" + serverEditComboBox.Text.ToUpper() + "] was edited";
            ++Edits;
        }

        private void deleteButtonClick(object sender, EventArgs e)
        {
            // Delete server button
            if (Servers.Remove(serverEditComboBox.Text.ToUpper()))
                statusEditMessage.Text = "[" + serverEditComboBox.Text.ToUpper() + "] has been deleted";
            else
                statusEditMessage.Text = "[" + serverEditComboBox.Text.ToUpper() + "] has been deleted";
            refreshComboBox(serverEditComboBox);
            refreshComboBox(comboBox1);
            serverEditComboBox.Text = string.Empty;
            ++Edits;
        }

        private void serverEditComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            // Hit the Enter key instead of having to click the Apply Button
            if (e.KeyCode == Keys.Return)
                applyButton.PerformClick();
        }
        #endregion


        #region Permissions Tab
        private void permissionsButton_Click(object sender, EventArgs e)
        {
            // Impersonates the specific user and reports back with permissions
            // If left blank then it uses the current user
            var test = new AdminShareTest();

            try
            {
                if (textBox1.Text != String.Empty && textBox2.Text != String.Empty)
                {
                    Impersonator user = new Impersonator(textBox1.Text, textBox2.Text);
                    user.Impersonate();
                    test.DiscoverPermissions(comboBox1.Text);
                    user.EndImpersonating();
                }
                else
                {
                    test.DiscoverPermissions(comboBox1.Text);
                }
                permissions.Text = test.report;
            }
            catch { permissions.Text = "Incorrect username or password"; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            permissions.Text = String.Empty;
        }
        #endregion


        #region Duplicate Check and ComboBox Refresh
        private bool isDuplicate(string newServer)
        {
            bool result = false;

            Servers.ForEach(delegate(String s)
            {
                if (s == newServer)
                    result = true;
            });
            return result;
        }

        private void refreshComboBox(ComboBox c)
        {
            c.Items.Clear();
            Servers.Sort();

            Servers.ForEach(delegate(string s)
            {
                c.Items.Add(s);
            });
        }
        #endregion


        #region Form Closing
        private void EditAddServersFormClosing(object sender, FormClosingEventArgs e)
        {
            CreateMessage();
        }
        #endregion    
    }
}

