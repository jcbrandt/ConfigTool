namespace ConfigTool
{
    partial class ConfigEditorForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.recentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbSearchText = new System.Windows.Forms.TextBox();
            this.btnGeneratePassword = new System.Windows.Forms.Button();
            this.tbPasswordToEncrypt = new System.Windows.Forms.TextBox();
            this.tbEncryptedPassword = new System.Windows.Forms.TextBox();
            this.rbJboss = new System.Windows.Forms.RadioButton();
            this.btnRestartSvcs = new System.Windows.Forms.Button();
            this.rbJBossStatus = new System.Windows.Forms.RadioButton();
            this.rbTomcatStatus = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gbGenPass = new System.Windows.Forms.GroupBox();
            this.gbServices = new System.Windows.Forms.GroupBox();
            this.rbSynchronizedEdit = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.gbGenPass.SuspendLayout();
            this.gbServices.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dataGridView1.Location = new System.Drawing.Point(59, 198);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1437, 427);
            this.dataGridView1.TabIndex = 0;
            // 
            // Property
            // 
            this.Property.HeaderText = "Property";
            this.Property.Name = "Property";
            this.Property.Width = 87;
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.Width = 69;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1677, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripSeparator1,
            this.recentToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.saveToolStripMenuItem.Text = "Exit";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(120, 6);
            // 
            // recentToolStripMenuItem
            // 
            this.recentToolStripMenuItem.Name = "recentToolStripMenuItem";
            this.recentToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.recentToolStripMenuItem.Text = "Recent";
            // 
            // tbSearchText
            // 
            this.tbSearchText.Location = new System.Drawing.Point(197, 31);
            this.tbSearchText.Margin = new System.Windows.Forms.Padding(4);
            this.tbSearchText.Name = "tbSearchText";
            this.tbSearchText.Size = new System.Drawing.Size(324, 22);
            this.tbSearchText.TabIndex = 3;
            this.tbSearchText.TextChanged += new System.EventHandler(this.tbSearchText_TextChanged);
            // 
            // btnGeneratePassword
            // 
            this.btnGeneratePassword.Location = new System.Drawing.Point(7, 26);
            this.btnGeneratePassword.Margin = new System.Windows.Forms.Padding(4);
            this.btnGeneratePassword.Name = "btnGeneratePassword";
            this.btnGeneratePassword.Size = new System.Drawing.Size(178, 28);
            this.btnGeneratePassword.TabIndex = 4;
            this.btnGeneratePassword.Text = "GenEncryptedPassword";
            this.btnGeneratePassword.UseVisualStyleBackColor = true;
            this.btnGeneratePassword.Click += new System.EventHandler(this.generatePassword_Click);
            // 
            // tbPasswordToEncrypt
            // 
            this.tbPasswordToEncrypt.Location = new System.Drawing.Point(210, 28);
            this.tbPasswordToEncrypt.Margin = new System.Windows.Forms.Padding(4);
            this.tbPasswordToEncrypt.Name = "tbPasswordToEncrypt";
            this.tbPasswordToEncrypt.Size = new System.Drawing.Size(301, 22);
            this.tbPasswordToEncrypt.TabIndex = 5;
            // 
            // tbEncryptedPassword
            // 
            this.tbEncryptedPassword.Location = new System.Drawing.Point(210, 62);
            this.tbEncryptedPassword.Margin = new System.Windows.Forms.Padding(4);
            this.tbEncryptedPassword.Name = "tbEncryptedPassword";
            this.tbEncryptedPassword.ReadOnly = true;
            this.tbEncryptedPassword.Size = new System.Drawing.Size(301, 22);
            this.tbEncryptedPassword.TabIndex = 6;
            this.tbEncryptedPassword.Visible = false;
            // 
            // rbJboss
            // 
            this.rbJboss.AutoCheck = false;
            this.rbJboss.AutoSize = true;
            this.rbJboss.Location = new System.Drawing.Point(7, 64);
            this.rbJboss.Margin = new System.Windows.Forms.Padding(4);
            this.rbJboss.Name = "rbJboss";
            this.rbJboss.Size = new System.Drawing.Size(66, 21);
            this.rbJboss.TabIndex = 7;
            this.rbJboss.TabStop = true;
            this.rbJboss.Text = "Jboss";
            this.rbJboss.UseVisualStyleBackColor = true;
            // 
            // btnRestartSvcs
            // 
            this.btnRestartSvcs.Location = new System.Drawing.Point(6, 26);
            this.btnRestartSvcs.Name = "btnRestartSvcs";
            this.btnRestartSvcs.Size = new System.Drawing.Size(97, 28);
            this.btnRestartSvcs.TabIndex = 8;
            this.btnRestartSvcs.Text = "Stop";
            this.btnRestartSvcs.UseVisualStyleBackColor = true;
            this.btnRestartSvcs.Click += new System.EventHandler(this.btnRestartSvcs_Click);
            // 
            // rbJBossStatus
            // 
            this.rbJBossStatus.AutoCheck = false;
            this.rbJBossStatus.AutoSize = true;
            this.rbJBossStatus.BackColor = System.Drawing.SystemColors.Control;
            this.rbJBossStatus.ForeColor = System.Drawing.Color.Black;
            this.rbJBossStatus.Location = new System.Drawing.Point(144, 29);
            this.rbJBossStatus.Name = "rbJBossStatus";
            this.rbJBossStatus.Size = new System.Drawing.Size(98, 21);
            this.rbJBossStatus.TabIndex = 9;
            this.rbJBossStatus.TabStop = true;
            this.rbJBossStatus.Text = "Jboss Srvc";
            this.rbJBossStatus.UseVisualStyleBackColor = false;
            // 
            // rbTomcatStatus
            // 
            this.rbTomcatStatus.AutoCheck = false;
            this.rbTomcatStatus.AutoSize = true;
            this.rbTomcatStatus.Location = new System.Drawing.Point(144, 56);
            this.rbTomcatStatus.Name = "rbTomcatStatus";
            this.rbTomcatStatus.Size = new System.Drawing.Size(108, 21);
            this.rbTomcatStatus.TabIndex = 10;
            this.rbTomcatStatus.TabStop = true;
            this.rbTomcatStatus.Text = "Tomcat Srvc";
            this.rbTomcatStatus.UseMnemonic = false;
            this.rbTomcatStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Enter Search Text";
            // 
            // gbGenPass
            // 
            this.gbGenPass.Controls.Add(this.tbEncryptedPassword);
            this.gbGenPass.Controls.Add(this.btnGeneratePassword);
            this.gbGenPass.Controls.Add(this.tbPasswordToEncrypt);
            this.gbGenPass.Controls.Add(this.rbJboss);
            this.gbGenPass.Location = new System.Drawing.Point(844, 31);
            this.gbGenPass.Name = "gbGenPass";
            this.gbGenPass.Size = new System.Drawing.Size(707, 100);
            this.gbGenPass.TabIndex = 12;
            this.gbGenPass.TabStop = false;
            this.gbGenPass.Text = "Generate Passwords";
            // 
            // gbServices
            // 
            this.gbServices.Controls.Add(this.btnRestartSvcs);
            this.gbServices.Controls.Add(this.rbJBossStatus);
            this.gbServices.Controls.Add(this.rbTomcatStatus);
            this.gbServices.Location = new System.Drawing.Point(548, 31);
            this.gbServices.Name = "gbServices";
            this.gbServices.Size = new System.Drawing.Size(276, 100);
            this.gbServices.TabIndex = 13;
            this.gbServices.TabStop = false;
            this.gbServices.Text = "Start/Stop Serivces";
            // 
            // rbSynchronizedEdit
            // 
            this.rbSynchronizedEdit.AutoCheck = false;
            this.rbSynchronizedEdit.AutoSize = true;
            this.rbSynchronizedEdit.Location = new System.Drawing.Point(59, 69);
            this.rbSynchronizedEdit.Name = "rbSynchronizedEdit";
            this.rbSynchronizedEdit.Size = new System.Drawing.Size(17, 16);
            this.rbSynchronizedEdit.TabIndex = 14;
            this.rbSynchronizedEdit.TabStop = true;
            this.rbSynchronizedEdit.UseVisualStyleBackColor = true;
            this.rbSynchronizedEdit.Visible = false;
            // 
            // ConfigEditorForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 644);
            this.Controls.Add(this.rbSynchronizedEdit);
            this.Controls.Add(this.gbServices);
            this.Controls.Add(this.gbGenPass);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSearchText);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ConfigEditorForm";
            this.Text = "Config Editor";
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.ConfigEditorForm_DragOver);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.gbGenPass.ResumeLayout(false);
            this.gbGenPass.PerformLayout();
            this.gbServices.ResumeLayout(false);
            this.gbServices.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void radioButton1_Click(object sender, System.EventArgs e)
        {
            rbJboss.Checked = !rbJboss.Checked;
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Property;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TextBox tbSearchText;
        private System.Windows.Forms.Button btnGeneratePassword;
        private System.Windows.Forms.TextBox tbPasswordToEncrypt;
        private System.Windows.Forms.TextBox tbEncryptedPassword;
        private System.Windows.Forms.RadioButton rbJboss;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem recentToolStripMenuItem;
        private System.Windows.Forms.Button btnRestartSvcs;
        private System.Windows.Forms.RadioButton rbJBossStatus;
        private System.Windows.Forms.RadioButton rbTomcatStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbGenPass;
        private System.Windows.Forms.GroupBox gbServices;
        private System.Windows.Forms.RadioButton rbSynchronizedEdit;
    }
}

