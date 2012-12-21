using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ErrorLoggerFrontEnd
{
    public partial class ImpersonateDialog : Form
    {
        public string username { get; set; }
        public string password { get; set; }

        public ImpersonateDialog()
        {
            InitializeComponent();
            username = String.Empty;
            password = String.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // OK Button
            username = usernameTextBox.Text;
            password = passwordTextBox.Text;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Cancel Button
            this.Close();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Again, I hate using the mouse to push buttons
            if (e.KeyCode == Keys.Return)
                button1.PerformClick();
        }
    }
}

