namespace Steam_Account_Switcher
{
    partial class frmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lstAccounts = new System.Windows.Forms.ListBox();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.btnSaveToList = new System.Windows.Forms.Button();
            this.groupBox_AddAccount = new System.Windows.Forms.GroupBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.groupBox_SteamPath = new System.Windows.Forms.GroupBox();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.AboutBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DevelopByUMIQLOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemakeByMaxwestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.ToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnForceClose = new System.Windows.Forms.Button();
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_AddAccount.SuspendLayout();
            this.groupBox_SteamPath.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.ContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUserName
            // 
            resources.ApplyResources(this.txtUserName, "txtUserName");
            this.txtUserName.Name = "txtUserName";
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.Name = "txtPassword";
            // 
            // lstAccounts
            // 
            this.lstAccounts.FormattingEnabled = true;
            resources.ApplyResources(this.lstAccounts, "lstAccounts");
            this.lstAccounts.Name = "lstAccounts";
            this.lstAccounts.SelectedIndexChanged += new System.EventHandler(this.LstAccount_SelectedIndexChanged);
            this.lstAccounts.DoubleClick += new System.EventHandler(this.BtnLogin_Click);
            // 
            // lbUserName
            // 
            resources.ApplyResources(this.lbUserName, "lbUserName");
            this.lbUserName.Name = "lbUserName";
            // 
            // lbPassword
            // 
            resources.ApplyResources(this.lbPassword, "lbPassword");
            this.lbPassword.Name = "lbPassword";
            // 
            // btnSaveToList
            // 
            resources.ApplyResources(this.btnSaveToList, "btnSaveToList");
            this.btnSaveToList.Name = "btnSaveToList";
            this.btnSaveToList.UseVisualStyleBackColor = true;
            this.btnSaveToList.Click += new System.EventHandler(this.btnSaveToList_Click);
            // 
            // groupBox_AddAccount
            // 
            this.groupBox_AddAccount.Controls.Add(this.lbUserName);
            this.groupBox_AddAccount.Controls.Add(this.btnSaveToList);
            this.groupBox_AddAccount.Controls.Add(this.lbPassword);
            this.groupBox_AddAccount.Controls.Add(this.txtUserName);
            this.groupBox_AddAccount.Controls.Add(this.txtPassword);
            resources.ApplyResources(this.groupBox_AddAccount, "groupBox_AddAccount");
            this.groupBox_AddAccount.Name = "groupBox_AddAccount";
            this.groupBox_AddAccount.TabStop = false;
            // 
            // btnLogin
            // 
            resources.ApplyResources(this.btnLogin, "btnLogin");
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // btnSelectPath
            // 
            resources.ApplyResources(this.btnSelectPath, "btnSelectPath");
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtPath
            // 
            resources.ApplyResources(this.txtPath, "txtPath");
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            // 
            // groupBox_SteamPath
            // 
            this.groupBox_SteamPath.Controls.Add(this.txtPath);
            this.groupBox_SteamPath.Controls.Add(this.btnSelectPath);
            resources.ApplyResources(this.groupBox_SteamPath, "groupBox_SteamPath");
            this.groupBox_SteamPath.Name = "groupBox_SteamPath";
            this.groupBox_SteamPath.TabStop = false;
            // 
            // MenuStrip
            // 
            this.MenuStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            resources.ApplyResources(this.MenuStrip, "MenuStrip");
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutBToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.MenuStrip.Name = "MenuStrip";
            // 
            // AboutBToolStripMenuItem
            // 
            this.AboutBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DevelopByUMIQLOToolStripMenuItem,
            this.RemakeByMaxwestToolStripMenuItem});
            this.AboutBToolStripMenuItem.Name = "AboutBToolStripMenuItem";
            resources.ApplyResources(this.AboutBToolStripMenuItem, "AboutBToolStripMenuItem");
            this.AboutBToolStripMenuItem.Click += new System.EventHandler(this.aboutBToolStripMenuItem_Click);
            // 
            // DevelopByUMIQLOToolStripMenuItem
            // 
            this.DevelopByUMIQLOToolStripMenuItem.Name = "DevelopByUMIQLOToolStripMenuItem";
            resources.ApplyResources(this.DevelopByUMIQLOToolStripMenuItem, "DevelopByUMIQLOToolStripMenuItem");
            // 
            // RemakeByMaxwestToolStripMenuItem
            // 
            this.RemakeByMaxwestToolStripMenuItem.Name = "RemakeByMaxwestToolStripMenuItem";
            resources.ApplyResources(this.RemakeByMaxwestToolStripMenuItem, "RemakeByMaxwestToolStripMenuItem");
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            resources.ApplyResources(this.ExitToolStripMenuItem, "ExitToolStripMenuItem");
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.exitXToolStripMenuItem_Click);
            // 
            // RefreshButton
            // 
            resources.ApplyResources(this.RefreshButton, "RefreshButton");
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripStatusLabel});
            resources.ApplyResources(this.StatusStrip, "StatusStrip");
            this.StatusStrip.Name = "StatusStrip";
            // 
            // ToolStripStatusLabel
            // 
            this.ToolStripStatusLabel.Name = "ToolStripStatusLabel";
            resources.ApplyResources(this.ToolStripStatusLabel, "ToolStripStatusLabel");
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnForceClose
            // 
            resources.ApplyResources(this.btnForceClose, "btnForceClose");
            this.btnForceClose.Name = "btnForceClose";
            this.btnForceClose.UseVisualStyleBackColor = true;
            this.btnForceClose.Click += new System.EventHandler(this.BtnForceClose_Click);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.ContextMenuStrip = this.ContextMenuStrip;
            resources.ApplyResources(this.NotifyIcon, "NotifyIcon");
            this.NotifyIcon.Click += new System.EventHandler(this.NotifyIcon_Click);
            this.NotifyIcon.DoubleClick += new System.EventHandler(this.NotifyIcon_DoubleClick);
            // 
            // ContextMenuStrip
            // 
            this.ContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem,
            this.AboutToolStripMenuItem,
            this.RestoreToolStripMenuItem,
            this.HideToolStripMenuItem,
            this.ExitXToolStripMenuItem});
            this.ContextMenuStrip.Name = "contextMenuStrip1";
            resources.ApplyResources(this.ContextMenuStrip, "ContextMenuStrip");
            // 
            // ToolStripMenuItem
            // 
            this.ToolStripMenuItem.Name = "ToolStripMenuItem";
            resources.ApplyResources(this.ToolStripMenuItem, "ToolStripMenuItem");
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            resources.ApplyResources(this.AboutToolStripMenuItem, "AboutToolStripMenuItem");
            this.AboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItem_Click);
            // 
            // RestoreToolStripMenuItem
            // 
            this.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem";
            resources.ApplyResources(this.RestoreToolStripMenuItem, "RestoreToolStripMenuItem");
            this.RestoreToolStripMenuItem.Click += new System.EventHandler(this.RestoreToolStripMenuItem_Click);
            // 
            // HideToolStripMenuItem
            // 
            this.HideToolStripMenuItem.Name = "HideToolStripMenuItem";
            resources.ApplyResources(this.HideToolStripMenuItem, "HideToolStripMenuItem");
            this.HideToolStripMenuItem.Click += new System.EventHandler(this.HideToolStripMenuItem_Click);
            // 
            // ExitXToolStripMenuItem
            // 
            this.ExitXToolStripMenuItem.Name = "ExitXToolStripMenuItem";
            resources.ApplyResources(this.ExitXToolStripMenuItem, "ExitXToolStripMenuItem");
            this.ExitXToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            resources.ApplyResources(this, "$this");
            this.Controls.Add(this.btnForceClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.groupBox_SteamPath);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.groupBox_AddAccount);
            this.Controls.Add(this.lstAccounts);
            this.Controls.Add(this.MenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.MenuStrip;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.groupBox_AddAccount.ResumeLayout(false);
            this.groupBox_AddAccount.PerformLayout();
            this.groupBox_SteamPath.ResumeLayout(false);
            this.groupBox_SteamPath.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.ContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ListBox lstAccounts;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Button btnSaveToList;
        private System.Windows.Forms.GroupBox groupBox_AddAccount;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.GroupBox groupBox_SteamPath;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AboutBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnForceClose;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem RestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem HideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DevelopByUMIQLOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemakeByMaxwestToolStripMenuItem;
    }
}

