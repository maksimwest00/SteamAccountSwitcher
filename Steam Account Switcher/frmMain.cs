using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using System.Diagnostics;
using System.Security.Cryptography;

// Steam Account Switcher Developed by UMIQLO
// Version v1.5
// Date : 160813

namespace Steam_Account_Switcher
{
    public partial class frmMain : Form
    {
        private string path;
        private string getPath()
        {
            return path;
        }
        private void setPath(string path)
        {
            this.path = path;
        }
        int count = 0;
        string user = "沒有", pw = "沒有", id = "沒有";
        bool pathCorrect;
        public frmMain()
        {
            InitializeComponent();
            this.Icon = Steam_Account_Switcher.Properties.Resources.SAS;
            notifyIcon1.Icon = Steam_Account_Switcher.Properties.Resources.SAS;
            LoadingXml();
            if (System.IO.File.Exists("account.xml"))
            {
                ReadAccount();
            }
            count = lstAccount.Items.Count;
            id = count.ToString();

        }
        private void btnSaveToList_Click(object sender, EventArgs e)
        {
            AddAccount();
        }

        private void LoadingXml()
        {
            string FileName = "setting.xml";
            if (System.IO.File.Exists(FileName))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(FileName);
                XmlNode child = doc.SelectSingleNode("/setting/path");
                if (child != null)
                {
                    XmlNodeReader nr = new XmlNodeReader(child);
                    while (nr.Read())
                        if (nr.Value != "")
                        {
                            setPath(nr.Value);
                            CheckPath();
                            txtPath.Text = getPath();
                        }
                }
            }
            else
            {
                //Default Path
                CreatePathData("setting.xml", "C:\\Program Files (x86)\\Steam");
                LoadingXml();
            }
        }

        private void CheckPath()
        {
            if (System.IO.File.Exists(getPath() + @"\steam.exe") && System.IO.File.Exists(getPath() + @"\Steam.dll"))
            {
                pathCorrect = true;
            }
            else
            {
                MessageBox.Show("Steam Path Incorrect");
                pathCorrect = false;
            }
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
                setPath(folderBrowserDialog1.SelectedPath);
                CheckPath();
                CreatePathData("setting.xml", getPath());
            }
        }

        private void exitXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }

        private void aboutBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Tool is Developed By UMIQLO");
        }

        private void CreatePathData(string Filename, string path)
        {
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            //3.創建子節點setting
            XmlElement node = doc.CreateElement("setting");

            //4.創建節點path
            XmlElement steamPath = doc.CreateElement("path");
            if (path != null)
            {
                steamPath.InnerText = path;
            }
            else
            {
                steamPath.InnerText = getPath();
            }
            


            //5.將創建的節點，添加到二級節點setting中
            node.AppendChild(steamPath);

            //6.將二級節點添加到根節點中去
            doc.AppendChild(node);

            StreamWriter outStream = System.IO.File.CreateText(Filename);

            doc.Save(outStream);
            outStream.Close();
        }

        private void AddAccount()
        {
            count++;
            if (txtUserName.Text != "" && txtPassword.Text != "")
            {
                if (!System.IO.File.Exists("account.xml"))
                {
                    XmlDocument doc = new XmlDocument();
                    XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
                    doc.AppendChild(docNode);
                    //建立根節點
                    XmlElement steam = doc.CreateElement("steam");
                    doc.AppendChild(steam);
                    //建立子節點
                    XmlElement account = doc.CreateElement("account");
                    account.SetAttribute("id", count.ToString());//設定屬性

                    //加入至steam節點底下
                    steam.AppendChild(account);

                    XmlElement username = doc.CreateElement("username");
                    username.InnerText = (txtUserName.Text);
                    XmlElement password = doc.CreateElement("password");
                    password.InnerText = (txtPassword.Text);
                    //加入至members節點底下
                    account.AppendChild(username);
                    account.AppendChild(password);
                    doc.Save("account.xml");
                    MessageBox.Show("You added " + txtUserName.Text);
                    toolStripStatusLabel1.Text = "You added " + txtUserName.Text;
                }
                else
                {
                    bool chk;
                    chk = CheckAccount(txtUserName.Text);
                    if (chk == false)
                    {
                        return;
                    }
                    XmlDocument doc = new XmlDocument();
                    doc.Load("account.xml");
                    XmlNode node = doc.SelectSingleNode("steam");//選擇節點
                    if (node == null)
                        return;

                    XmlElement account = doc.CreateElement("account");
                    account.SetAttribute("id", count.ToString());//設定屬性
                    node.AppendChild(account);

                    XmlElement username = doc.CreateElement("username");
                    username.InnerText = (txtUserName.Text);
                    XmlElement password = doc.CreateElement("password");
                    password.InnerText = (txtPassword.Text);
                    //加入至members節點底下
                    account.AppendChild(username);
                    account.AppendChild(password);

                    doc.Save("account.xml");
                    MessageBox.Show("You added " + txtUserName.Text);
                    toolStripStatusLabel1.Text = "You added " + txtUserName.Text;
                }
            }
            else
            {
                MessageBox.Show("Please field in the Username and Password");
            }
            ReadAccount();
        }

        private void ReadAccount()
        {
            string FileName = "account.xml";
            if (System.IO.File.Exists(FileName))
            {
                lstAccount.Enabled = true;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);

                lstAccount.Items.Clear();
                for (int i = 0; i <= xmlDoc.SelectSingleNode("steam").ChildNodes.Count - 1; i++)
                {
                    string user, pw, id;

                    user = xmlDoc.SelectNodes("//username")[i].InnerText;
                    lstAccount.Items.Add(user);

                    pw = xmlDoc.SelectNodes("//password")[i].InnerText;

                    id = xmlDoc.SelectNodes("//account/@id")[i].Value;
                    count = Convert.ToInt32(id);
                }
                txtUserName.Text = "";
                txtPassword.Text = "";
                toolStripStatusLabel1.Text = "";
            }
            else
            {
                lstAccount.Enabled = false;
            }
                        
        }

        private bool CheckAccount(string selectUsername)
        {
            bool re = true;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("account.xml");

            for (int i = 0; i <= xmlDoc.SelectSingleNode("steam").ChildNodes.Count - 1; i++)
            {
                user = xmlDoc.SelectNodes("//username")[i].InnerText;
                pw = xmlDoc.SelectNodes("//password")[i].InnerText;
                id = xmlDoc.SelectNodes("//account/@id")[i].Value;
                if (user == selectUsername)
                {
                    MessageBox.Show("Account is saved to the list");
                    re = false;
                    break;
                }
            }
            return re;
        }

        private void lstAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = lstAccount.SelectedItem.ToString();
            //txtUserName.Text = selected; 測試用
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("account.xml");

            for (int i = 0; i <= xmlDoc.SelectSingleNode("steam").ChildNodes.Count - 1; i++)
            {
                user = xmlDoc.SelectNodes("//username")[i].InnerText;
                pw = xmlDoc.SelectNodes("//password")[i].InnerText;
                id = xmlDoc.SelectNodes("//account/@id")[i].Value;
                if (user == selected)
                {
                    toolStripStatusLabel1.Text = "You are selected " + selected;
                    return;
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ReadAccount();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (user != "沒有" && pw != "沒有" && id != "沒有")
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to remove it?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("account.xml");

                    XmlNodeList nodes = doc.SelectNodes("//account[@id='" + id + "']");
                    for (int i = nodes.Count - 1; i >= 0; i--)
                    {
                        nodes[i].ParentNode.RemoveChild(nodes[i]);
                    }

                    doc.Save("account.xml");
                    ReadAccount();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (pathCorrect == true)
            {
                if (user != "沒有" && pw != "沒有" && id != "沒有")
                {
                    DialogResult dialogResult = MessageBox.Show("Are you want to login?\n\nAccount：" + user, "Warning", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        ForceClose();
                        Process.Start(getPath() + @"\steam.exe", "-login " + user + " " + pw);
                        HideMainForm();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Select an Account");
                }

            }
            else if (pathCorrect == false)
            {
                MessageBox.Show("Path Incorrect");
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

        private void btnForceClose_Click(object sender, EventArgs e)
        {
            ForceClose();
        }

        private void ExitMainForm()
        {
            if (MessageBox.Show("Close Steam Account Switcher？", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                this.notifyIcon1.Visible = false;
                this.Close();
                this.Dispose();
                Application.Exit();
            }
        }

        private void HideMainForm()
        {
            this.Hide();
        }

        private void ShowMainForm()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
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

        private void frmMain_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                HideMainForm();
            }
        }

        private void RestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void HideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HideMainForm();
        }

        private void ExitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ExitMainForm();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Tools is Developed By UMIQLO");
        }

        private void notifyIcon1_DoubleClick_1(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            HideMainForm();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }
    }
}
