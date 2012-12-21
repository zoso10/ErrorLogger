using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormTests
{
    public partial class TestForm : Form
    {
        private bool isImpersonating;

        public TestForm()
        {
            InitializeComponent();
            isImpersonating = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Moved the code to the status bar button
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            isImpersonating = !isImpersonating;
            toolStripSplitButton1.BackColor = isImpersonating ? Color.LightGreen : Color.IndianRed;
            toolStripStatusLabel2.Text = isImpersonating.ToString();
        }

        private void pDMServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton1.Text = "PDMService";
        }

        private void srvFolderAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripSplitButton1.Text = "srvFolderAdmin";
        }
    }
}
