namespace ErrorLoggerFrontEnd
{
    partial class EditAddServers
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
            this.editAddTabControl = new System.Windows.Forms.TabControl();
            this.addServersPage = new System.Windows.Forms.TabPage();
            this.addButton = new System.Windows.Forms.Button();
            this.pingButton = new System.Windows.Forms.Button();
            this.statusAddMessage = new System.Windows.Forms.Label();
            this.applicationAddTextBox = new System.Windows.Forms.TextBox();
            this.groupAddTextBox = new System.Windows.Forms.TextBox();
            this.nicknameAddTextBox = new System.Windows.Forms.TextBox();
            this.serverNameAddTextBox = new System.Windows.Forms.TextBox();
            this.statusAddLabel = new System.Windows.Forms.Label();
            this.applicationAddLabel = new System.Windows.Forms.Label();
            this.groupAddLabel = new System.Windows.Forms.Label();
            this.nicknameAddLabel = new System.Windows.Forms.Label();
            this.serverNameAddLabel = new System.Windows.Forms.Label();
            this.editServersPage = new System.Windows.Forms.TabPage();
            this.serverEditComboBox = new System.Windows.Forms.ComboBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.statusEditMessage = new System.Windows.Forms.Label();
            this.applicationEditTextBox = new System.Windows.Forms.TextBox();
            this.groupEditTextBox = new System.Windows.Forms.TextBox();
            this.nicknameEditTextBox = new System.Windows.Forms.TextBox();
            this.statusEditLabel = new System.Windows.Forms.Label();
            this.applicationEditLabel = new System.Windows.Forms.Label();
            this.groupEditLabel = new System.Windows.Forms.Label();
            this.nicknameEditLabel = new System.Windows.Forms.Label();
            this.serverEditLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.checkPermissionsPage = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.permissions = new System.Windows.Forms.Label();
            this.permissionsButton = new System.Windows.Forms.Button();
            this.editAddTabControl.SuspendLayout();
            this.addServersPage.SuspendLayout();
            this.editServersPage.SuspendLayout();
            this.checkPermissionsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // editAddTabControl
            // 
            this.editAddTabControl.Controls.Add(this.addServersPage);
            this.editAddTabControl.Controls.Add(this.editServersPage);
            this.editAddTabControl.Controls.Add(this.checkPermissionsPage);
            this.editAddTabControl.Location = new System.Drawing.Point(0, 0);
            this.editAddTabControl.Name = "editAddTabControl";
            this.editAddTabControl.SelectedIndex = 0;
            this.editAddTabControl.Size = new System.Drawing.Size(535, 319);
            this.editAddTabControl.TabIndex = 0;
            // 
            // addServersPage
            // 
            this.addServersPage.Controls.Add(this.addButton);
            this.addServersPage.Controls.Add(this.pingButton);
            this.addServersPage.Controls.Add(this.statusAddMessage);
            this.addServersPage.Controls.Add(this.applicationAddTextBox);
            this.addServersPage.Controls.Add(this.groupAddTextBox);
            this.addServersPage.Controls.Add(this.nicknameAddTextBox);
            this.addServersPage.Controls.Add(this.serverNameAddTextBox);
            this.addServersPage.Controls.Add(this.statusAddLabel);
            this.addServersPage.Controls.Add(this.applicationAddLabel);
            this.addServersPage.Controls.Add(this.groupAddLabel);
            this.addServersPage.Controls.Add(this.nicknameAddLabel);
            this.addServersPage.Controls.Add(this.serverNameAddLabel);
            this.addServersPage.Location = new System.Drawing.Point(4, 22);
            this.addServersPage.Name = "addServersPage";
            this.addServersPage.Padding = new System.Windows.Forms.Padding(3);
            this.addServersPage.Size = new System.Drawing.Size(527, 293);
            this.addServersPage.TabIndex = 0;
            this.addServersPage.Text = "Add Server";
            this.addServersPage.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(255, 237);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 11;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButtonClick);
            // 
            // pingButton
            // 
            this.pingButton.Location = new System.Drawing.Point(155, 237);
            this.pingButton.Name = "pingButton";
            this.pingButton.Size = new System.Drawing.Size(75, 23);
            this.pingButton.TabIndex = 10;
            this.pingButton.Text = "Ping";
            this.pingButton.UseVisualStyleBackColor = true;
            this.pingButton.Click += new System.EventHandler(this.pingButtonClick);
            // 
            // statusAddMessage
            // 
            this.statusAddMessage.AutoSize = true;
            this.statusAddMessage.Location = new System.Drawing.Point(100, 189);
            this.statusAddMessage.Name = "statusAddMessage";
            this.statusAddMessage.Size = new System.Drawing.Size(52, 13);
            this.statusAddMessage.TabIndex = 9;
            this.statusAddMessage.Text = "               ";
            // 
            // applicationAddTextBox
            // 
            this.applicationAddTextBox.Location = new System.Drawing.Point(103, 144);
            this.applicationAddTextBox.Name = "applicationAddTextBox";
            this.applicationAddTextBox.Size = new System.Drawing.Size(227, 20);
            this.applicationAddTextBox.TabIndex = 8;
            // 
            // groupAddTextBox
            // 
            this.groupAddTextBox.Location = new System.Drawing.Point(103, 105);
            this.groupAddTextBox.Name = "groupAddTextBox";
            this.groupAddTextBox.Size = new System.Drawing.Size(227, 20);
            this.groupAddTextBox.TabIndex = 7;
            // 
            // nicknameAddTextBox
            // 
            this.nicknameAddTextBox.Location = new System.Drawing.Point(103, 64);
            this.nicknameAddTextBox.Name = "nicknameAddTextBox";
            this.nicknameAddTextBox.Size = new System.Drawing.Size(227, 20);
            this.nicknameAddTextBox.TabIndex = 6;
            // 
            // serverNameAddTextBox
            // 
            this.serverNameAddTextBox.Location = new System.Drawing.Point(103, 22);
            this.serverNameAddTextBox.Name = "serverNameAddTextBox";
            this.serverNameAddTextBox.Size = new System.Drawing.Size(227, 20);
            this.serverNameAddTextBox.TabIndex = 5;
            this.serverNameAddTextBox.TextChanged += new System.EventHandler(this.serverNameAddTextBoxTextChanged);
            this.serverNameAddTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serverNameAddTextBoxKeyDown);
            // 
            // statusAddLabel
            // 
            this.statusAddLabel.AutoSize = true;
            this.statusAddLabel.Location = new System.Drawing.Point(8, 189);
            this.statusAddLabel.Name = "statusAddLabel";
            this.statusAddLabel.Size = new System.Drawing.Size(40, 13);
            this.statusAddLabel.TabIndex = 4;
            this.statusAddLabel.Text = "Status:";
            // 
            // applicationAddLabel
            // 
            this.applicationAddLabel.AutoSize = true;
            this.applicationAddLabel.Location = new System.Drawing.Point(8, 147);
            this.applicationAddLabel.Name = "applicationAddLabel";
            this.applicationAddLabel.Size = new System.Drawing.Size(59, 13);
            this.applicationAddLabel.TabIndex = 3;
            this.applicationAddLabel.Text = "Application";
            // 
            // groupAddLabel
            // 
            this.groupAddLabel.AutoSize = true;
            this.groupAddLabel.Location = new System.Drawing.Point(8, 108);
            this.groupAddLabel.Name = "groupAddLabel";
            this.groupAddLabel.Size = new System.Drawing.Size(39, 13);
            this.groupAddLabel.TabIndex = 2;
            this.groupAddLabel.Text = "Group:";
            // 
            // nicknameAddLabel
            // 
            this.nicknameAddLabel.AutoSize = true;
            this.nicknameAddLabel.Location = new System.Drawing.Point(8, 67);
            this.nicknameAddLabel.Name = "nicknameAddLabel";
            this.nicknameAddLabel.Size = new System.Drawing.Size(58, 13);
            this.nicknameAddLabel.TabIndex = 1;
            this.nicknameAddLabel.Text = "Nickname:";
            // 
            // serverNameAddLabel
            // 
            this.serverNameAddLabel.AutoSize = true;
            this.serverNameAddLabel.Location = new System.Drawing.Point(8, 25);
            this.serverNameAddLabel.Name = "serverNameAddLabel";
            this.serverNameAddLabel.Size = new System.Drawing.Size(72, 13);
            this.serverNameAddLabel.TabIndex = 0;
            this.serverNameAddLabel.Text = "Server Name:";
            // 
            // editServersPage
            // 
            this.editServersPage.Controls.Add(this.serverEditComboBox);
            this.editServersPage.Controls.Add(this.deleteButton);
            this.editServersPage.Controls.Add(this.applyButton);
            this.editServersPage.Controls.Add(this.statusEditMessage);
            this.editServersPage.Controls.Add(this.applicationEditTextBox);
            this.editServersPage.Controls.Add(this.groupEditTextBox);
            this.editServersPage.Controls.Add(this.nicknameEditTextBox);
            this.editServersPage.Controls.Add(this.statusEditLabel);
            this.editServersPage.Controls.Add(this.applicationEditLabel);
            this.editServersPage.Controls.Add(this.groupEditLabel);
            this.editServersPage.Controls.Add(this.nicknameEditLabel);
            this.editServersPage.Controls.Add(this.serverEditLabel);
            this.editServersPage.Location = new System.Drawing.Point(4, 22);
            this.editServersPage.Name = "editServersPage";
            this.editServersPage.Padding = new System.Windows.Forms.Padding(3);
            this.editServersPage.Size = new System.Drawing.Size(527, 293);
            this.editServersPage.TabIndex = 1;
            this.editServersPage.Text = "Edit Server";
            this.editServersPage.UseVisualStyleBackColor = true;
            // 
            // serverEditComboBox
            // 
            this.serverEditComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.serverEditComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.serverEditComboBox.FormattingEnabled = true;
            this.serverEditComboBox.Location = new System.Drawing.Point(103, 22);
            this.serverEditComboBox.Name = "serverEditComboBox";
            this.serverEditComboBox.Size = new System.Drawing.Size(262, 21);
            this.serverEditComboBox.TabIndex = 23;
            this.serverEditComboBox.TextChanged += new System.EventHandler(this.serverEditComboBoxTextChanged);
            this.serverEditComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.serverEditComboBoxKeyDown);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(155, 237);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 22;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButtonClick);
            // 
            // applyButton
            // 
            this.applyButton.Location = new System.Drawing.Point(255, 237);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 21;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButtonClick);
            // 
            // statusEditMessage
            // 
            this.statusEditMessage.AutoSize = true;
            this.statusEditMessage.Location = new System.Drawing.Point(100, 189);
            this.statusEditMessage.Name = "statusEditMessage";
            this.statusEditMessage.Size = new System.Drawing.Size(55, 13);
            this.statusEditMessage.TabIndex = 19;
            this.statusEditMessage.Text = "                ";
            // 
            // applicationEditTextBox
            // 
            this.applicationEditTextBox.Location = new System.Drawing.Point(103, 144);
            this.applicationEditTextBox.Name = "applicationEditTextBox";
            this.applicationEditTextBox.Size = new System.Drawing.Size(227, 20);
            this.applicationEditTextBox.TabIndex = 18;
            // 
            // groupEditTextBox
            // 
            this.groupEditTextBox.Location = new System.Drawing.Point(103, 105);
            this.groupEditTextBox.Name = "groupEditTextBox";
            this.groupEditTextBox.Size = new System.Drawing.Size(227, 20);
            this.groupEditTextBox.TabIndex = 17;
            // 
            // nicknameEditTextBox
            // 
            this.nicknameEditTextBox.Location = new System.Drawing.Point(103, 64);
            this.nicknameEditTextBox.Name = "nicknameEditTextBox";
            this.nicknameEditTextBox.Size = new System.Drawing.Size(227, 20);
            this.nicknameEditTextBox.TabIndex = 16;
            // 
            // statusEditLabel
            // 
            this.statusEditLabel.AutoSize = true;
            this.statusEditLabel.Location = new System.Drawing.Point(8, 189);
            this.statusEditLabel.Name = "statusEditLabel";
            this.statusEditLabel.Size = new System.Drawing.Size(40, 13);
            this.statusEditLabel.TabIndex = 14;
            this.statusEditLabel.Text = "Status:";
            // 
            // applicationEditLabel
            // 
            this.applicationEditLabel.AutoSize = true;
            this.applicationEditLabel.Location = new System.Drawing.Point(8, 147);
            this.applicationEditLabel.Name = "applicationEditLabel";
            this.applicationEditLabel.Size = new System.Drawing.Size(59, 13);
            this.applicationEditLabel.TabIndex = 13;
            this.applicationEditLabel.Text = "Application";
            // 
            // groupEditLabel
            // 
            this.groupEditLabel.AutoSize = true;
            this.groupEditLabel.Location = new System.Drawing.Point(8, 108);
            this.groupEditLabel.Name = "groupEditLabel";
            this.groupEditLabel.Size = new System.Drawing.Size(39, 13);
            this.groupEditLabel.TabIndex = 12;
            this.groupEditLabel.Text = "Group:";
            // 
            // nicknameEditLabel
            // 
            this.nicknameEditLabel.AutoSize = true;
            this.nicknameEditLabel.Location = new System.Drawing.Point(8, 67);
            this.nicknameEditLabel.Name = "nicknameEditLabel";
            this.nicknameEditLabel.Size = new System.Drawing.Size(58, 13);
            this.nicknameEditLabel.TabIndex = 11;
            this.nicknameEditLabel.Text = "Nickname:";
            // 
            // serverEditLabel
            // 
            this.serverEditLabel.AutoSize = true;
            this.serverEditLabel.Location = new System.Drawing.Point(8, 25);
            this.serverEditLabel.Name = "serverEditLabel";
            this.serverEditLabel.Size = new System.Drawing.Size(72, 13);
            this.serverEditLabel.TabIndex = 10;
            this.serverEditLabel.Text = "Server Name:";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(447, 327);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButtonClick);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(352, 327);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButtonClick);
            // 
            // checkPermissionsPage
            // 
            this.checkPermissionsPage.Controls.Add(this.permissionsButton);
            this.checkPermissionsPage.Controls.Add(this.permissions);
            this.checkPermissionsPage.Controls.Add(this.label4);
            this.checkPermissionsPage.Controls.Add(this.textBox2);
            this.checkPermissionsPage.Controls.Add(this.textBox1);
            this.checkPermissionsPage.Controls.Add(this.label3);
            this.checkPermissionsPage.Controls.Add(this.label2);
            this.checkPermissionsPage.Controls.Add(this.label1);
            this.checkPermissionsPage.Controls.Add(this.comboBox1);
            this.checkPermissionsPage.Location = new System.Drawing.Point(4, 22);
            this.checkPermissionsPage.Name = "checkPermissionsPage";
            this.checkPermissionsPage.Size = new System.Drawing.Size(527, 293);
            this.checkPermissionsPage.TabIndex = 2;
            this.checkPermissionsPage.Text = "Check Permissions";
            this.checkPermissionsPage.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(103, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(262, 21);
            this.comboBox1.TabIndex = 24;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Server Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Username:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "Password:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(103, 63);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(216, 20);
            this.textBox1.TabIndex = 28;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(103, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '•';
            this.textBox2.Size = new System.Drawing.Size(216, 20);
            this.textBox2.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Results:";
            // 
            // permissions
            // 
            this.permissions.AutoSize = true;
            this.permissions.Location = new System.Drawing.Point(100, 141);
            this.permissions.Name = "permissions";
            this.permissions.Size = new System.Drawing.Size(43, 13);
            this.permissions.TabIndex = 31;
            this.permissions.Text = "            ";
            // 
            // permissionsButton
            // 
            this.permissionsButton.Location = new System.Drawing.Point(348, 239);
            this.permissionsButton.Name = "permissionsButton";
            this.permissionsButton.Size = new System.Drawing.Size(75, 23);
            this.permissionsButton.TabIndex = 32;
            this.permissionsButton.Text = "Check";
            this.permissionsButton.UseVisualStyleBackColor = true;
            this.permissionsButton.Click += new System.EventHandler(this.permissionsButton_Click);
            // 
            // EditAddServers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 362);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.editAddTabControl);
            this.Name = "EditAddServers";
            this.Text = "EditAdd_Servers";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditAddServersFormClosing);
            this.editAddTabControl.ResumeLayout(false);
            this.addServersPage.ResumeLayout(false);
            this.addServersPage.PerformLayout();
            this.editServersPage.ResumeLayout(false);
            this.editServersPage.PerformLayout();
            this.checkPermissionsPage.ResumeLayout(false);
            this.checkPermissionsPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl editAddTabControl;
        private System.Windows.Forms.TabPage addServersPage;
        private System.Windows.Forms.TabPage editServersPage;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button pingButton;
        private System.Windows.Forms.Label statusAddMessage;
        private System.Windows.Forms.TextBox applicationAddTextBox;
        private System.Windows.Forms.TextBox groupAddTextBox;
        private System.Windows.Forms.TextBox nicknameAddTextBox;
        private System.Windows.Forms.TextBox serverNameAddTextBox;
        private System.Windows.Forms.Label statusAddLabel;
        private System.Windows.Forms.Label applicationAddLabel;
        private System.Windows.Forms.Label groupAddLabel;
        private System.Windows.Forms.Label nicknameAddLabel;
        private System.Windows.Forms.Label serverNameAddLabel;
        private System.Windows.Forms.ComboBox serverEditComboBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button applyButton;
        private System.Windows.Forms.Label statusEditMessage;
        private System.Windows.Forms.TextBox applicationEditTextBox;
        private System.Windows.Forms.TextBox groupEditTextBox;
        private System.Windows.Forms.TextBox nicknameEditTextBox;
        private System.Windows.Forms.Label statusEditLabel;
        private System.Windows.Forms.Label applicationEditLabel;
        private System.Windows.Forms.Label groupEditLabel;
        private System.Windows.Forms.Label nicknameEditLabel;
        private System.Windows.Forms.Label serverEditLabel;
        private System.Windows.Forms.TabPage checkPermissionsPage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label permissions;
        private System.Windows.Forms.Button permissionsButton;
    }
}