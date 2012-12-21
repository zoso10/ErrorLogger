namespace ErrorLoggerFrontEnd
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkPermissionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keyboardShortcutsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mbFreeTextBox = new System.Windows.Forms.TextBox();
            this.percentFreeTextBox = new System.Windows.Forms.TextBox();
            this.mbFreeRadioButton = new System.Windows.Forms.RadioButton();
            this.percentFreeRadioButton = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.systemCheckBox = new System.Windows.Forms.CheckBox();
            this.securityCheckBox = new System.Windows.Forms.CheckBox();
            this.applicationCheckBox = new System.Windows.Forms.CheckBox();
            this.logsLabel = new System.Windows.Forms.Label();
            this.customMessageTextBox = new System.Windows.Forms.TextBox();
            this.customMessageLabel = new System.Windows.Forms.Label();
            this.serversComboBox = new System.Windows.Forms.ComboBox();
            this.serverLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.recipientsListView = new System.Windows.Forms.ListView();
            this.recipientsLabel = new System.Windows.Forms.Label();
            this.removeUserButton = new System.Windows.Forms.Button();
            this.addUserButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.applyButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.newUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItemClick);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItemClick);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addServerToolStripMenuItem,
            this.editServerToolStripMenuItem,
            this.checkPermissionsToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addServerToolStripMenuItem
            // 
            this.addServerToolStripMenuItem.Name = "addServerToolStripMenuItem";
            this.addServerToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.addServerToolStripMenuItem.Text = "Add Server                   Ctrl+A";
            this.addServerToolStripMenuItem.Click += new System.EventHandler(this.addServerToolStripMenuItemClick);
            // 
            // editServerToolStripMenuItem
            // 
            this.editServerToolStripMenuItem.Name = "editServerToolStripMenuItem";
            this.editServerToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.editServerToolStripMenuItem.Text = "Edit Server                    Ctrl+E";
            this.editServerToolStripMenuItem.Click += new System.EventHandler(this.editServerToolStripMenuItemClick);
            // 
            // checkPermissionsToolStripMenuItem
            // 
            this.checkPermissionsToolStripMenuItem.Name = "checkPermissionsToolStripMenuItem";
            this.checkPermissionsToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.checkPermissionsToolStripMenuItem.Text = "Check Permissions      Ctrl+P";
            this.checkPermissionsToolStripMenuItem.Click += new System.EventHandler(this.checkPermissionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keyboardShortcutsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // keyboardShortcutsToolStripMenuItem
            // 
            this.keyboardShortcutsToolStripMenuItem.Name = "keyboardShortcutsToolStripMenuItem";
            this.keyboardShortcutsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.keyboardShortcutsToolStripMenuItem.Text = "Keyboard Shortcuts";
            this.keyboardShortcutsToolStripMenuItem.Click += new System.EventHandler(this.keyboardShortcutsToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mbFreeTextBox);
            this.groupBox1.Controls.Add(this.percentFreeTextBox);
            this.groupBox1.Controls.Add(this.mbFreeRadioButton);
            this.groupBox1.Controls.Add(this.percentFreeRadioButton);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.systemCheckBox);
            this.groupBox1.Controls.Add(this.securityCheckBox);
            this.groupBox1.Controls.Add(this.applicationCheckBox);
            this.groupBox1.Controls.Add(this.logsLabel);
            this.groupBox1.Controls.Add(this.customMessageTextBox);
            this.groupBox1.Controls.Add(this.customMessageLabel);
            this.groupBox1.Controls.Add(this.serversComboBox);
            this.groupBox1.Controls.Add(this.serverLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 453);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // mbFreeTextBox
            // 
            this.mbFreeTextBox.Location = new System.Drawing.Point(142, 406);
            this.mbFreeTextBox.Name = "mbFreeTextBox";
            this.mbFreeTextBox.Size = new System.Drawing.Size(128, 20);
            this.mbFreeTextBox.TabIndex = 14;
            // 
            // percentFreeTextBox
            // 
            this.percentFreeTextBox.Location = new System.Drawing.Point(142, 373);
            this.percentFreeTextBox.Name = "percentFreeTextBox";
            this.percentFreeTextBox.Size = new System.Drawing.Size(128, 20);
            this.percentFreeTextBox.TabIndex = 13;
            // 
            // mbFreeRadioButton
            // 
            this.mbFreeRadioButton.AutoSize = true;
            this.mbFreeRadioButton.Location = new System.Drawing.Point(39, 407);
            this.mbFreeRadioButton.Name = "mbFreeRadioButton";
            this.mbFreeRadioButton.Size = new System.Drawing.Size(65, 17);
            this.mbFreeRadioButton.TabIndex = 12;
            this.mbFreeRadioButton.Text = "MB Free";
            this.mbFreeRadioButton.UseVisualStyleBackColor = true;
            // 
            // percentFreeRadioButton
            // 
            this.percentFreeRadioButton.AutoSize = true;
            this.percentFreeRadioButton.Checked = true;
            this.percentFreeRadioButton.Location = new System.Drawing.Point(39, 374);
            this.percentFreeRadioButton.Name = "percentFreeRadioButton";
            this.percentFreeRadioButton.Size = new System.Drawing.Size(86, 17);
            this.percentFreeRadioButton.TabIndex = 11;
            this.percentFreeRadioButton.TabStop = true;
            this.percentFreeRadioButton.Text = "Percent Free";
            this.percentFreeRadioButton.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.checkBox1.Location = new System.Drawing.Point(20, 337);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Monitor HD Free Space";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // systemCheckBox
            // 
            this.systemCheckBox.AutoSize = true;
            this.systemCheckBox.Location = new System.Drawing.Point(257, 98);
            this.systemCheckBox.Name = "systemCheckBox";
            this.systemCheckBox.Size = new System.Drawing.Size(60, 17);
            this.systemCheckBox.TabIndex = 8;
            this.systemCheckBox.Text = "System";
            this.systemCheckBox.UseVisualStyleBackColor = true;
            // 
            // securityCheckBox
            // 
            this.securityCheckBox.AutoSize = true;
            this.securityCheckBox.Location = new System.Drawing.Point(142, 98);
            this.securityCheckBox.Name = "securityCheckBox";
            this.securityCheckBox.Size = new System.Drawing.Size(64, 17);
            this.securityCheckBox.TabIndex = 6;
            this.securityCheckBox.Text = "Security";
            this.securityCheckBox.UseVisualStyleBackColor = true;
            // 
            // applicationCheckBox
            // 
            this.applicationCheckBox.AutoSize = true;
            this.applicationCheckBox.Location = new System.Drawing.Point(20, 98);
            this.applicationCheckBox.Name = "applicationCheckBox";
            this.applicationCheckBox.Size = new System.Drawing.Size(78, 17);
            this.applicationCheckBox.TabIndex = 5;
            this.applicationCheckBox.Text = "Application";
            this.applicationCheckBox.UseVisualStyleBackColor = true;
            // 
            // logsLabel
            // 
            this.logsLabel.AutoSize = true;
            this.logsLabel.Location = new System.Drawing.Point(17, 73);
            this.logsLabel.Name = "logsLabel";
            this.logsLabel.Size = new System.Drawing.Size(33, 13);
            this.logsLabel.TabIndex = 4;
            this.logsLabel.Text = "Logs:";
            // 
            // customMessageTextBox
            // 
            this.customMessageTextBox.Location = new System.Drawing.Point(20, 156);
            this.customMessageTextBox.Multiline = true;
            this.customMessageTextBox.Name = "customMessageTextBox";
            this.customMessageTextBox.Size = new System.Drawing.Size(297, 140);
            this.customMessageTextBox.TabIndex = 3;
            // 
            // customMessageLabel
            // 
            this.customMessageLabel.AutoSize = true;
            this.customMessageLabel.Location = new System.Drawing.Point(17, 140);
            this.customMessageLabel.Name = "customMessageLabel";
            this.customMessageLabel.Size = new System.Drawing.Size(137, 13);
            this.customMessageLabel.TabIndex = 2;
            this.customMessageLabel.Text = "Custom Message (optional):";
            // 
            // serversComboBox
            // 
            this.serversComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.serversComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.serversComboBox.FormattingEnabled = true;
            this.serversComboBox.Location = new System.Drawing.Point(20, 32);
            this.serversComboBox.Name = "serversComboBox";
            this.serversComboBox.Size = new System.Drawing.Size(300, 21);
            this.serversComboBox.TabIndex = 1;
            this.serversComboBox.SelectedIndexChanged += new System.EventHandler(this.serversComboBoxSelectedIndexChanged);
            // 
            // serverLabel
            // 
            this.serverLabel.AutoSize = true;
            this.serverLabel.Location = new System.Drawing.Point(17, 16);
            this.serverLabel.Name = "serverLabel";
            this.serverLabel.Size = new System.Drawing.Size(41, 13);
            this.serverLabel.TabIndex = 0;
            this.serverLabel.Text = "Server:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.recipientsListView);
            this.groupBox2.Controls.Add(this.recipientsLabel);
            this.groupBox2.Controls.Add(this.removeUserButton);
            this.groupBox2.Controls.Add(this.addUserButton);
            this.groupBox2.Controls.Add(this.usernameTextBox);
            this.groupBox2.Controls.Add(this.usernameLabel);
            this.groupBox2.Location = new System.Drawing.Point(369, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 424);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            // 
            // recipientsListView
            // 
            this.recipientsListView.Location = new System.Drawing.Point(20, 125);
            this.recipientsListView.MultiSelect = false;
            this.recipientsListView.Name = "recipientsListView";
            this.recipientsListView.Size = new System.Drawing.Size(265, 283);
            this.recipientsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.recipientsListView.TabIndex = 10;
            this.recipientsListView.UseCompatibleStateImageBehavior = false;
            this.recipientsListView.View = System.Windows.Forms.View.List;
            this.recipientsListView.SelectedIndexChanged += new System.EventHandler(this.recipientsListViewSelectedIndexChanged);
            // 
            // recipientsLabel
            // 
            this.recipientsLabel.AutoSize = true;
            this.recipientsLabel.Location = new System.Drawing.Point(17, 108);
            this.recipientsLabel.Name = "recipientsLabel";
            this.recipientsLabel.Size = new System.Drawing.Size(60, 13);
            this.recipientsLabel.TabIndex = 4;
            this.recipientsLabel.Text = "Recipients:";
            // 
            // removeUserButton
            // 
            this.removeUserButton.Location = new System.Drawing.Point(188, 69);
            this.removeUserButton.Name = "removeUserButton";
            this.removeUserButton.Size = new System.Drawing.Size(82, 23);
            this.removeUserButton.TabIndex = 3;
            this.removeUserButton.Text = "Remove User";
            this.removeUserButton.UseVisualStyleBackColor = true;
            this.removeUserButton.Click += new System.EventHandler(this.removeUserButtonClick);
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(20, 69);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(75, 23);
            this.addUserButton.TabIndex = 2;
            this.addUserButton.Text = "Add User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Click += new System.EventHandler(this.addUserButtonClick);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(20, 33);
            this.usernameTextBox.MaxLength = 150;
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(250, 20);
            this.usernameTextBox.TabIndex = 1;
            this.usernameTextBox.TextChanged += new System.EventHandler(this.usernameTextBoxTextChanged);
            this.usernameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usernameTextBoxKeyDown);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(17, 16);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(58, 13);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Username:";
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(597, 457);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 5;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButtonClick);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(490, 457);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButtonClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusMessage,
            this.toolStripStatusLabel2,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 490);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(684, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // statusMessage
            // 
            this.statusMessage.Name = "statusMessage";
            this.statusMessage.Size = new System.Drawing.Size(70, 17);
            this.statusMessage.Text = "                     ";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(468, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.BackgroundImage")));
            this.toolStripSplitButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newUserToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(89, 20);
            this.toolStripSplitButton1.Text = "Impersonate";
            this.toolStripSplitButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            this.toolStripSplitButton1.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripSplitButton1_DropDownItemClicked);
            // 
            // newUserToolStripMenuItem
            // 
            this.newUserToolStripMenuItem.Name = "newUserToolStripMenuItem";
            this.newUserToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.newUserToolStripMenuItem.Text = "Change User";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 512);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "ErrorLogger Control Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editServerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox customMessageTextBox;
        private System.Windows.Forms.Label customMessageLabel;
        private System.Windows.Forms.ComboBox serversComboBox;
        private System.Windows.Forms.Label serverLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label recipientsLabel;
        private System.Windows.Forms.Button removeUserButton;
        private System.Windows.Forms.Button addUserButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.ListView recipientsListView;
        private System.Windows.Forms.CheckBox systemCheckBox;
        private System.Windows.Forms.CheckBox securityCheckBox;
        private System.Windows.Forms.CheckBox applicationCheckBox;
        private System.Windows.Forms.Label logsLabel;
        private System.Windows.Forms.ToolStripMenuItem keyboardShortcutsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusMessage;
        private System.Windows.Forms.ToolStripMenuItem checkPermissionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem newUserToolStripMenuItem;
        private System.Windows.Forms.RadioButton mbFreeRadioButton;
        private System.Windows.Forms.RadioButton percentFreeRadioButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox mbFreeTextBox;
        private System.Windows.Forms.TextBox percentFreeTextBox;
    }
}

