using IWshRuntimeLibrary;
using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace ZipSafe
{
    public partial class ZipSafe : Form
    {
        private bool Automatic_Backup;

        public ZipSafe()
        {
            InitializeComponent();

            IntervalHoursComboBox.SelectedIndex = 0;
            Load += ZipSafe_Load; // Attach Load event

            BackupTimer.Interval = Properties.Settings.Default.BackupTimerValue * 3600000; // Convert hours to milliseconds
            Timer.Start();
        }

        #region Form Load and Initialization

        private void ZipSafe_Load(object sender, EventArgs e)
        {
            try
            {
                // Load the last saved image path
                string lastImagePath = Properties.Settings.Default.LastImagePath;
                if (!string.IsNullOrEmpty(lastImagePath) && System.IO.File.Exists(lastImagePath))
                {
                    PictureBox.Image = Image.FromFile(lastImagePath);
                    PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                LoadPaths(); // Load previously saved folder paths

                // Load other settings
                CopyDirectlyCheckBox.Checked = Properties.Settings.Default.CopyFiles;
                MachineNameTextBox.Text = Properties.Settings.Default.MachineName;
                StartupBackupCheckBox.Checked = Properties.Settings.Default.StartupBackupEnabled;
                LoadSettings();

                // Perform startup backup if enabled
                if (StartupBackupCheckBox.Checked)
                {
                    PerformBackup();
                }

                // Configure backup timer based on settings
                if (Properties.Settings.Default.SchedulesCheck)
                {
                    BackupTimer.Start();
                    ScheduledBackupLabel.Text = $"Scheduled task updated: {Properties.Settings.Default.BackupTimerValue} hours";
                }
                else
                {
                    BackupTimer.Stop();
                    ScheduledBackupLabel.Text = "Automatic backup stopped.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during loading: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSettings()
        {
            bool isAutomaticMode = Properties.Settings.Default.SchedulesCheck;
            AutomaticBackup.Text = isAutomaticMode ? "Automatic Mode On" : "Automatic Mode Off";
        }

        private void LoadPaths()
        {
            FilesCheckedListBox.Items.Clear();
            BackupFolderTextBox.Text = Properties.Settings.Default.BackupFolder;

            if (Properties.Settings.Default.FilePaths != null)
            {
                foreach (string path in Properties.Settings.Default.FilePaths)
                {
                    FilesCheckedListBox.Items.Add(path);
                }
            }
        }

        #endregion

        #region Backup Operations

        private void PerformBackup()
        {
            using (LoadingForm loadingForm = new LoadingForm())
            {
                loadingForm.Show();
                loadingForm.UpdateStatus("Backup process starting...", 0);

                string backupFolder = BackupFolderTextBox.Text;
                StringBuilder adeLog = new StringBuilder();

                if (string.IsNullOrEmpty(backupFolder))
                {
                    MessageBox.Show("Please select a valid backup folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadingForm.Close();
                    return;
                }

                try
                {
                    if (!Directory.Exists(backupFolder))
                    {
                        Directory.CreateDirectory(backupFolder);
                    }

                    int totalItems = FilesCheckedListBox.Items.Count;
                    int processedItems = 0;

                    // Perform direct copy or ZIP backup based on user settings
                    if (CopyDirectlyCheckBox.Checked)
                    {
                        PerformDirectCopy(backupFolder, loadingForm, adeLog, totalItems, ref processedItems);
                    }
                    else
                    {
                        PerformZipBackup(backupFolder, loadingForm, adeLog, totalItems, ref processedItems);
                    }

                    // Save backup log
                    string logPath = Path.Combine(backupFolder, $"Backup_{Properties.Settings.Default.MachineName}_{DateTime.Now:yyyyMMdd_HHmmss}.txt");
                    System.IO.File.WriteAllText(logPath, adeLog.ToString());

                    loadingForm.UpdateStatus("Backup completed successfully.", 100);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during backup: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    loadingForm.Close();
                }
            }
        }

        private void PerformDirectCopy(string backupFolder, LoadingForm loadingForm, StringBuilder adeLog, int totalItems, ref int processedItems)
        {
            string timestampedFolder = Path.Combine(backupFolder, $"Backup_{Properties.Settings.Default.MachineName}_{DateTime.Now:yyyyMMdd_HHmmss}");
            Directory.CreateDirectory(timestampedFolder);

            foreach (string path in FilesCheckedListBox.Items)
            {
                if (Directory.Exists(path))
                {
                    string targetDir = Path.Combine(timestampedFolder, Path.GetFileName(path));
                    DirectoryCopy(path, targetDir, true);
                    adeLog.AppendLine($"Directory added: {targetDir}");
                }
                else if (System.IO.File.Exists(path))
                {
                    string targetFile = Path.Combine(timestampedFolder, Path.GetFileName(path));
                    System.IO.File.Copy(path, targetFile, true);
                    adeLog.AppendLine($"File added: {targetFile}");
                }

                processedItems++;
                UpdateLoadingStatus(loadingForm, path, totalItems, processedItems);
            }
        }

        private void PerformZipBackup(string backupFolder, LoadingForm loadingForm, StringBuilder adeLog, int totalItems, ref int processedItems)
        {
            string zipFileName = Path.Combine(backupFolder, $"Backup_{Properties.Settings.Default.MachineName}_{DateTime.Now:yyyyMMdd_HHmmss}.zip");

            using (ZipArchive archive = ZipFile.Open(zipFileName, ZipArchiveMode.Create))
            {
                foreach (string path in FilesCheckedListBox.Items)
                {
                    if (Directory.Exists(path))
                    {
                        foreach (string file in Directory.GetFiles(path, "*", SearchOption.AllDirectories))
                        {
                            string entryName = GetRelativePath(path, file);
                            archive.CreateEntryFromFile(file, entryName);
                            adeLog.AppendLine($"File added to ZIP: {entryName}");
                        }
                    }
                    else if (System.IO.File.Exists(path))
                    {
                        string entryName = Path.GetFileName(path);
                        archive.CreateEntryFromFile(path, entryName);
                        adeLog.AppendLine($"File added to ZIP: {entryName}");
                    }

                    processedItems++;
                    UpdateLoadingStatus(loadingForm, path, totalItems, processedItems);
                }
            }
        }

        private void UpdateLoadingStatus(LoadingForm loadingForm, string path, int totalItems, int processedItems)
        {
            int progress = (int)((processedItems / (float)totalItems) * 100);
            loadingForm.UpdateStatus($"Processing {Path.GetFileName(path)}...", progress);
        }

        #endregion

        #region Helper Methods

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string tempPath = Path.Combine(destDirName, file.Name);
                file.CopyTo(tempPath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string tempPath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        private string GetRelativePath(string basePath, string fullPath)
        {
            Uri baseUri = new Uri(basePath);
            Uri fullUri = new Uri(fullPath);

            if (baseUri.IsBaseOf(fullUri))
            {
                Uri relativeUri = baseUri.MakeRelativeUri(fullUri);
                return Uri.UnescapeDataString(relativeUri.ToString().Replace('/', Path.DirectorySeparatorChar));
            }

            return fullPath;
        }

        private void SaveFilePath(string path)
        {
            if (Properties.Settings.Default.FilePaths == null)
            {
                Properties.Settings.Default.FilePaths = new StringCollection();
            }
            Properties.Settings.Default.FilePaths.Add(path);
            Properties.Settings.Default.Save();
        }

        #endregion

        #region UI Handlers

        private void AddFolderButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderBrowser.SelectedPath;

                    if (!FilesCheckedListBox.Items.Contains(selectedPath))
                    {
                        FilesCheckedListBox.Items.Add(selectedPath);
                        SaveFilePath(selectedPath);
                    }
                    else
                    {
                        MessageBox.Show("This folder has already been added.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void RemoveFolderButton_Click(object sender, EventArgs e)
        {
            bool itemRemoved = false;

            for (int i = FilesCheckedListBox.Items.Count - 1; i >= 0; i--)
            {
                if (FilesCheckedListBox.GetItemChecked(i))
                {
                    string pathToRemove = FilesCheckedListBox.Items[i].ToString();
                    Properties.Settings.Default.FilePaths.Remove(pathToRemove);
                    FilesCheckedListBox.Items.RemoveAt(i);
                    itemRemoved = true;
                }
            }

            Properties.Settings.Default.Save();

            if (itemRemoved)
            {
                MessageBox.Show("Selected folder(s) have been removed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.BackupFolder = BackupFolderTextBox.Text;
            Properties.Settings.Default.MachineName = MachineNameTextBox.Text;
            Properties.Settings.Default.SchedulesCheck = Automatic_Backup;
            Properties.Settings.Default.CopyFiles = CopyDirectlyCheckBox.Checked;
            Properties.Settings.Default.StartupBackupEnabled = StartupBackupCheckBox.Checked;
            Properties.Settings.Default.Save();

            MessageBox.Show("Backup settings have been successfully saved.", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BackupFolderSelectButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    BackupFolderTextBox.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            PerformBackup();
        }

        private void choiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Select an image";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    PictureBox.Image = Image.FromFile(selectedFilePath);
                    PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    Properties.Settings.Default.LastImagePath = selectedFilePath;
                    Properties.Settings.Default.Save();
                    MessageBox.Show("Image successfully loaded and saved.", "Image Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void hideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            notifyIcon.ShowBalloonTip(1000, "ZipSafe", "Application minimized to tray.", ToolTipIcon.Info);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeLabel.Text = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
        }

        private void BackupTimer_Tick(object sender, EventArgs e)
        {
            PerformBackup();
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void EnableButton_Click(object sender, EventArgs e)
        {
            CreateShortcut();
            MessageBox.Show("Shortcut created successfully.", "Shortcut Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisableButton_Click(object sender, EventArgs e)
        {
            DeleteShortcut();
        }
        private void CreateShortcut()
        {
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "ZipSafe.lnk");
            string targetPath = Assembly.GetExecutingAssembly().Location; // Path to the executable

            WshShell shell = new WshShell();
            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
            shortcut.TargetPath = targetPath; // Target executable
            shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath); // Working directory
            shortcut.Description = "Shortcut for ZipSafe application"; // Shortcut description
            shortcut.Save(); // Save the shortcut
        }

        private void DeleteShortcut()
        {
            string shortcutPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "ZipSafe.lnk");

            if (System.IO.File.Exists(shortcutPath))
            {
                System.IO.File.Delete(shortcutPath); // Delete the shortcut
                MessageBox.Show("Shortcut deleted successfully.", "Shortcut Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Shortcut does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (IntervalHoursComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an interval.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int hours = int.Parse(IntervalHoursComboBox.SelectedItem.ToString());

            if (BackupTimer.Enabled)
            {
                MessageBox.Show("A backup process is already running.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BackupTimer.Interval = hours * 3600000;
            BackupTimer.Start();
            Automatic_Backup = true;
            AutomaticBackup.Text = "Automatic Mode On";
            ScheduledBackupLabel.Text = $"Scheduled task set to {hours} hours.";
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            BackupTimer.Stop();
            Automatic_Backup = false;
            AutomaticBackup.Text = "Automatic Mode Off";
            ScheduledBackupLabel.Text = "Automatic backup stopped.";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://selimbirincioglu.bio.link/",
                UseShellExecute = true
            });
        }
        
        private void ZipSafe_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.BackupFolder = BackupFolderTextBox.Text;
            Properties.Settings.Default.SchedulesCheck = Automatic_Backup;
            Properties.Settings.Default.CopyFiles = CopyDirectlyCheckBox.Checked;
            Properties.Settings.Default.StartupBackupEnabled = StartupBackupCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        #endregion
    }
}