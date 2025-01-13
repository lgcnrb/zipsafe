namespace ZipSafe
{
    partial class ZipSafe
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZipSafe));
            this.BackupFolderTextBox = new System.Windows.Forms.TextBox();
            this.BackupFolderSelectButtton = new System.Windows.Forms.Button();
            this.AddFolderButton = new System.Windows.Forms.Button();
            this.RemoveFolderButton = new System.Windows.Forms.Button();
            this.BackupButton = new System.Windows.Forms.Button();
            this.IntervalHoursComboBox = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TimeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.BackupProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.choiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveButton = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.BackupTimer = new System.Windows.Forms.Timer(this.components);
            this.FilesCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ScheduledBackupLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.EnableButton = new System.Windows.Forms.Button();
            this.DisableButton = new System.Windows.Forms.Button();
            this.AutomaticBackup = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButon = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.CopyDirectlyCheckBox = new System.Windows.Forms.CheckBox();
            this.StartupBackupCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MachineNameTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // BackupFolderTextBox
            // 
            this.BackupFolderTextBox.Enabled = false;
            this.BackupFolderTextBox.Location = new System.Drawing.Point(6, 19);
            this.BackupFolderTextBox.Name = "BackupFolderTextBox";
            this.BackupFolderTextBox.ReadOnly = true;
            this.BackupFolderTextBox.Size = new System.Drawing.Size(203, 20);
            this.BackupFolderTextBox.TabIndex = 1;
            // 
            // BackupFolderSelectButtton
            // 
            this.BackupFolderSelectButtton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupFolderSelectButtton.Location = new System.Drawing.Point(215, 19);
            this.BackupFolderSelectButtton.Name = "BackupFolderSelectButtton";
            this.BackupFolderSelectButtton.Size = new System.Drawing.Size(75, 23);
            this.BackupFolderSelectButtton.TabIndex = 2;
            this.BackupFolderSelectButtton.Text = "...";
            this.BackupFolderSelectButtton.UseVisualStyleBackColor = true;
            this.BackupFolderSelectButtton.Click += new System.EventHandler(this.BackupFolderSelectButton_Click);
            // 
            // AddFolderButton
            // 
            this.AddFolderButton.Location = new System.Drawing.Point(296, 265);
            this.AddFolderButton.Name = "AddFolderButton";
            this.AddFolderButton.Size = new System.Drawing.Size(75, 23);
            this.AddFolderButton.TabIndex = 5;
            this.AddFolderButton.Text = "Add Folder";
            this.AddFolderButton.UseVisualStyleBackColor = true;
            this.AddFolderButton.Click += new System.EventHandler(this.AddFolderButton_Click);
            // 
            // RemoveFolderButton
            // 
            this.RemoveFolderButton.Location = new System.Drawing.Point(6, 265);
            this.RemoveFolderButton.Name = "RemoveFolderButton";
            this.RemoveFolderButton.Size = new System.Drawing.Size(75, 23);
            this.RemoveFolderButton.TabIndex = 6;
            this.RemoveFolderButton.Text = "Remove";
            this.RemoveFolderButton.UseVisualStyleBackColor = true;
            this.RemoveFolderButton.Click += new System.EventHandler(this.RemoveFolderButton_Click);
            // 
            // BackupButton
            // 
            this.BackupButton.Location = new System.Drawing.Point(296, 19);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.Size = new System.Drawing.Size(75, 23);
            this.BackupButton.TabIndex = 8;
            this.BackupButton.Text = "Backup";
            this.BackupButton.UseVisualStyleBackColor = true;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // IntervalHoursComboBox
            // 
            this.IntervalHoursComboBox.AllowDrop = true;
            this.IntervalHoursComboBox.FormattingEnabled = true;
            this.IntervalHoursComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.IntervalHoursComboBox.Location = new System.Drawing.Point(7, 19);
            this.IntervalHoursComboBox.Name = "IntervalHoursComboBox";
            this.IntervalHoursComboBox.Size = new System.Drawing.Size(202, 21);
            this.IntervalHoursComboBox.TabIndex = 14;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimeLabel,
            this.toolStripStatusLabel2,
            this.BackupProgressBar,
            this.toolStripSplitButton1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 445);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TimeLabel
            // 
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(635, 17);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // BackupProgressBar
            // 
            this.BackupProgressBar.Name = "BackupProgressBar";
            this.BackupProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDown = this.contextMenuStrip1;
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 20);
            this.toolStripSplitButton1.Text = "Theme";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choiceToolStripMenuItem,
            this.hideToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.OwnerItem = this.toolStripSplitButton1;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(87, 48);
            // 
            // choiceToolStripMenuItem
            // 
            this.choiceToolStripMenuItem.Name = "choiceToolStripMenuItem";
            this.choiceToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.choiceToolStripMenuItem.Text = "Choice";
            this.choiceToolStripMenuItem.Click += new System.EventHandler(this.choiceToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(503, 99);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 18;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // BackupTimer
            // 
            this.BackupTimer.Tick += new System.EventHandler(this.BackupTimer_Tick);
            // 
            // FilesCheckedListBox
            // 
            this.FilesCheckedListBox.FormattingEnabled = true;
            this.FilesCheckedListBox.HorizontalScrollbar = true;
            this.FilesCheckedListBox.Location = new System.Drawing.Point(6, 45);
            this.FilesCheckedListBox.Name = "FilesCheckedListBox";
            this.FilesCheckedListBox.Size = new System.Drawing.Size(365, 214);
            this.FilesCheckedListBox.TabIndex = 3;
            // 
            // ScheduledBackupLabel
            // 
            this.ScheduledBackupLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ScheduledBackupLabel.Location = new System.Drawing.Point(3, 145);
            this.ScheduledBackupLabel.Name = "ScheduledBackupLabel";
            this.ScheduledBackupLabel.Size = new System.Drawing.Size(371, 79);
            this.ScheduledBackupLabel.TabIndex = 19;
            this.ScheduledBackupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "The application runs in the background.";
            this.notifyIcon.BalloonTipTitle = "Information";
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "ZipSafe";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // EnableButton
            // 
            this.EnableButton.Location = new System.Drawing.Point(390, 32);
            this.EnableButton.Name = "EnableButton";
            this.EnableButton.Size = new System.Drawing.Size(75, 23);
            this.EnableButton.TabIndex = 23;
            this.EnableButton.Text = "Start Enable";
            this.EnableButton.UseVisualStyleBackColor = true;
            this.EnableButton.Click += new System.EventHandler(this.EnableButton_Click);
            // 
            // DisableButton
            // 
            this.DisableButton.Location = new System.Drawing.Point(471, 32);
            this.DisableButton.Name = "DisableButton";
            this.DisableButton.Size = new System.Drawing.Size(75, 23);
            this.DisableButton.TabIndex = 24;
            this.DisableButton.Text = "Start Disable";
            this.DisableButton.UseVisualStyleBackColor = true;
            this.DisableButton.Click += new System.EventHandler(this.DisableButton_Click);
            // 
            // AutomaticBackup
            // 
            this.AutomaticBackup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.AutomaticBackup.Location = new System.Drawing.Point(3, 224);
            this.AutomaticBackup.Name = "AutomaticBackup";
            this.AutomaticBackup.Size = new System.Drawing.Size(371, 67);
            this.AutomaticBackup.TabIndex = 26;
            this.AutomaticBackup.Text = "AutomaticBackup";
            this.AutomaticBackup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(215, 17);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 27;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButon
            // 
            this.StopButon.Location = new System.Drawing.Point(296, 17);
            this.StopButon.Name = "StopButon";
            this.StopButon.Size = new System.Drawing.Size(75, 23);
            this.StopButon.TabIndex = 28;
            this.StopButon.Text = "Stop";
            this.StopButon.UseVisualStyleBackColor = true;
            this.StopButon.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Cascadia Code SemiBold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkColor = System.Drawing.SystemColors.HotTrack;
            this.linkLabel1.Location = new System.Drawing.Point(6, 95);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(434, 32);
            this.linkLabel1.TabIndex = 29;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Developed by Selim Birincioğlu";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CopyDirectlyCheckBox
            // 
            this.CopyDirectlyCheckBox.AutoSize = true;
            this.CopyDirectlyCheckBox.Location = new System.Drawing.Point(9, 61);
            this.CopyDirectlyCheckBox.Name = "CopyDirectlyCheckBox";
            this.CopyDirectlyCheckBox.Size = new System.Drawing.Size(169, 17);
            this.CopyDirectlyCheckBox.TabIndex = 30;
            this.CopyDirectlyCheckBox.Text = "Copy Files Directly (Do not zip)";
            this.CopyDirectlyCheckBox.UseVisualStyleBackColor = true;
            // 
            // StartupBackupCheckBox
            // 
            this.StartupBackupCheckBox.AutoSize = true;
            this.StartupBackupCheckBox.Location = new System.Drawing.Point(390, 61);
            this.StartupBackupCheckBox.Name = "StartupBackupCheckBox";
            this.StartupBackupCheckBox.Size = new System.Drawing.Size(100, 17);
            this.StartupBackupCheckBox.TabIndex = 31;
            this.StartupBackupCheckBox.Text = "Startup Backup";
            this.StartupBackupCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BackupFolderTextBox);
            this.groupBox1.Controls.Add(this.BackupFolderSelectButtton);
            this.groupBox1.Controls.Add(this.FilesCheckedListBox);
            this.groupBox1.Controls.Add(this.RemoveFolderButton);
            this.groupBox1.Controls.Add(this.AddFolderButton);
            this.groupBox1.Controls.Add(this.BackupButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 294);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Backup:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.StartButton);
            this.groupBox2.Controls.Add(this.IntervalHoursComboBox);
            this.groupBox2.Controls.Add(this.StopButon);
            this.groupBox2.Controls.Add(this.ScheduledBackupLabel);
            this.groupBox2.Controls.Add(this.AutomaticBackup);
            this.groupBox2.Location = new System.Drawing.Point(395, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 294);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scheduler and Frequency:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PictureBox);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.MachineNameTextBox);
            this.groupBox3.Controls.Add(this.StartupBackupCheckBox);
            this.groupBox3.Controls.Add(this.CopyDirectlyCheckBox);
            this.groupBox3.Controls.Add(this.SaveButton);
            this.groupBox3.Controls.Add(this.DisableButton);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.EnableButton);
            this.groupBox3.Location = new System.Drawing.Point(12, 312);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(760, 130);
            this.groupBox3.TabIndex = 34;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Settings:";
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(598, 16);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(156, 106);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 34;
            this.PictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Machine Name:";
            // 
            // MachineNameTextBox
            // 
            this.MachineNameTextBox.Location = new System.Drawing.Point(6, 34);
            this.MachineNameTextBox.Name = "MachineNameTextBox";
            this.MachineNameTextBox.Size = new System.Drawing.Size(365, 20);
            this.MachineNameTextBox.TabIndex = 32;
            // 
            // ZipSafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 467);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZipSafe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZipSafe";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZipSafe_FormClosing);
            this.Load += new System.EventHandler(this.ZipSafe_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox BackupFolderTextBox;
        private System.Windows.Forms.Button BackupFolderSelectButtton;
        private System.Windows.Forms.Button AddFolderButton;
        private System.Windows.Forms.Button RemoveFolderButton;
        private System.Windows.Forms.Button BackupButton;
        private System.Windows.Forms.ComboBox IntervalHoursComboBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel TimeLabel;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripProgressBar BackupProgressBar;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Timer BackupTimer;
        private System.Windows.Forms.CheckedListBox FilesCheckedListBox;
        private System.Windows.Forms.Label ScheduledBackupLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button DisableButton;
        private System.Windows.Forms.Button EnableButton;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label AutomaticBackup;
        private System.Windows.Forms.Button StopButon;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox CopyDirectlyCheckBox;
        private System.Windows.Forms.CheckBox StartupBackupCheckBox;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox MachineNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.ToolStripMenuItem choiceToolStripMenuItem;
    }
}

