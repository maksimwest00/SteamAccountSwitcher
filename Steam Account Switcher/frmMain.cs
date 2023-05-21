using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

// Steam Account Switcher Developed by UMIQLO remake by maxwest
// Version v1.5
// Date : 160813

namespace Steam_Account_Switcher
{
    public partial class frmMain : Form
    {
        #region Services 
        public IFileService FileService { get; set; }
        public IDialogService DialogService { get; set; }
        #endregion

        #region Collection Accs
        private ObservableCollection<Account> AccountsCollection;
        #endregion

        #region Properties
        private string _path;
        public string Path
        {
            get 
            { 
                return this._path; 
            }
            set 
            { 
                this._path = value; 
            }
        }
        public bool pathCorrect;
        #endregion

        #region Resources
        public string AccountFilePath { get; } = "accounts.json";
        public string SettingsFilePath { get; } = "settings.json";
        public System.Drawing.Icon AppIcon { get; } = Properties.Resources.SAS;
        #endregion

        #region Constructor
        public frmMain()
        {
            InitializeComponent();

            this.DialogService = new DefaultDialogService();
            this.FileService = new JsonFileService();

            this.Icon = this.AppIcon;
            this.NotifyIcon.Icon = this.AppIcon;

            this.LoadingJsonSettings();

            this.AccountsCollection = new ObservableCollection<Account>();
            this.AccountsCollection.CollectionChanged += AccountsCollection_CollectionChanged;

            if (File.Exists(this.AccountFilePath))
            {
                ReadAccountsJson();
            }
        }

        private void AccountsCollection_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            this.lstAccounts.DataSource = null;
            this.lstAccounts.DataSource = this.AccountsCollection;
            this.lstAccounts.DisplayMember = "username";
            this.lstAccounts.Refresh();
        }

        private void ReadAccountsJson()
        {
            string FileName = this.AccountFilePath;
            if (File.Exists(FileName))
            {
                this.lstAccounts.Enabled = true;
                List<Account> AccountsJson = this.FileService.Read<List<Account>>(FileName);
                AccountsCollection_Clear();
                foreach (var acc in AccountsJson)
                {
                    this.AccountsCollection.Add(acc);
                }
                ClearTextBoxes();
                this.ToolStripStatusLabel.Text = string.Empty;
            }
            else
            {
                this.lstAccounts.Enabled = false;
            }
        }
        private void AccountsCollection_Clear()
        {
            this.AccountsCollection.Clear();
        }
        #endregion

        #region Start Programm
        private void LoadingJsonSettings()
        {
            string FileName = this.SettingsFilePath;
            if (File.Exists(FileName))
            {
                SettingsJson SettingsJson = this.FileService.Read<SettingsJson>(FileName);
                if (!string.IsNullOrEmpty(SettingsJson.settings.path))
                {
                    this.Path = SettingsJson.settings.path;
                    CheckPath();
                    this.txtPath.Text = this.Path;
                }
            }
            else
            {
                CreatePathData(this.SettingsFilePath, "C:\\Program Files (x86)\\Steam");
                LoadingJsonSettings();
            }
        }
        #endregion

        #region Settings
        private void CheckPath()
        {
            if (File.Exists(this.Path + @"\steam.exe") && File.Exists(this.Path + @"\Steam.dll"))
            {
                this.pathCorrect = true;
            }
            else
            {
                this.DialogService.ShowMessage("Steam Path Incorrect");
                this.pathCorrect = false;
            }
        }
        #endregion

        #region Account Action
        private void AddAccountToCollection()
        {
            this.AccountsCollection.Add(new Account
            {
                username = this.txtUserName.Text,
                password = this.txtPassword.Text
            });
        }
        private void AddAccount()
        {
            if (this.txtUserName.Text != "" && this.txtPassword.Text != "")
            {
                if (!File.Exists(this.AccountFilePath))
                {
                    AddAccountToCollection();
                    SaveAddedAccount();
                }
                else
                {
                    bool chk;
                    chk = CheckAccount(this.txtUserName.Text);
                    if (chk == false)
                    {
                        return;
                    }
                    AddAccountToCollection();
                    SaveAddedAccount();
                }
            }
            else
            {
                this.DialogService.ShowMessage("Please field in the Username and Password");
            }
        }

        private void SaveAddedAccount()
        {
            SaveData();
            this.DialogService.ShowMessage("You added " + this.txtUserName.Text);
            this.ToolStripStatusLabel.Text = "You added " + this.txtUserName.Text;
            ClearTextBoxes();
        }

        private void ClearTextBoxes()
        {
            this.txtUserName.Text = string.Empty;
            this.txtPassword.Text = string.Empty;
        }

        private void SaveData()
        {
            this.FileService.Save(this.AccountFilePath, this.AccountsCollection);
        }
        #endregion

        #region Buttons Actions
        private void btnSaveToList_Click(object sender, EventArgs e)
        {
            AddAccount();
        }
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = this.folderBrowserDialog.SelectedPath;
                this.Path = this.folderBrowserDialog.SelectedPath;
                CheckPath();
                CreatePathData(this.SettingsFilePath, "C:\\Program Files (x86)\\Steam");
            }
        }
        #endregion

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }
        private void aboutBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogService.ShowMessage("This Tool is Developed By UMIQLO and Remaked by maxwest !!");
        }
        private void CreatePathData(string Filename, string path)
        {
            SettingsJson settingsJson = new SettingsJson()
            {
                settings = new Settings()
                {
                    path = path is null ? this.Path : path,
                }
            };
            this.FileService.Save(Filename, settingsJson);
        }
        private bool CheckAccount(string selectUsername)
        {
            bool check = true;
            foreach (Account acc in this.AccountsCollection)
            {
                if (acc.username == selectUsername)
                {
                    this.DialogService.ShowMessage("Account is saved to the list");
                    check = false;
                    break;
                }
            }
            return check;
        }
        private void LstAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lstAccounts.SelectedItem != null)
            {
                Account acc = (Account)this.lstAccounts.SelectedItem;
                this.ToolStripStatusLabel.Text = "You are selected " + acc.username;
            }
        }
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            ReadAccountsJson();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = this.DialogService.ShowMessage("Do you want to remove it?", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.AccountsCollection.Remove((Account)this.lstAccounts.SelectedItem);
                SaveData();
                ReadAccountsJson();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (this.pathCorrect == true)
            {
                if (this.lstAccounts.SelectedItem != null)
                {
                    Account acc = (Account)this.lstAccounts.SelectedItem;
                    DialogResult dialogResult = this.DialogService.ShowMessage("Are you want to login?\n\nAccount：" + acc.username, "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ForceClose();
                        Process.Start(this.Path + @"\steam.exe", "-login " + acc.username + " " + acc.password);
                        HideMainForm();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    this.DialogService.ShowMessage("Select an Account");
                }

            }
            else if (pathCorrect == false)
            {
                this.DialogService.ShowMessage("Path Incorrect");
            }
        }
        private void ForceClose()
        {
            Process[] processes = Process.GetProcessesByName("Steam");
            foreach (var process in processes)
            {
                process.Kill();
            }
        }
        private void BtnForceClose_Click(object sender, EventArgs e)
        {
            ForceClose();
        }

        #region MainForm Actions
        private void ShowMainForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }
        private void HideMainForm()
        {
            this.Hide();
        }
        private void ExitMainForm()
        {
            if (this.DialogService.ShowMessage("Close Steam Account Switcher？", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.NotifyIcon.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }
        #endregion

        #region NotifyMenu Actions
        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }
        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMainForm();
        }
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DialogService.ShowMessage("This Tools is Developed By UMIQLO and remake by maxwest !!");
        }
        #endregion

        #region NotifyIcon Actions
        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
                HideMainForm();
            }
            else if (this.WindowState == FormWindowState.Minimized)
            {
                ShowMainForm();
            }
        }
        private void NotifyIcon_Click(object sender, EventArgs e)
        {
            HideMainForm();
        }
        #endregion
    }
}
