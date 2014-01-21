using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ConfigTool
{
    public partial class ConfigEditorForm : Form
    {
        List<RowData> dataRows;
        List<string> MRUlist = new List<string>();
        string oldValue = "";
        string file;
        string[] records;
        string fileData = "";
        int rowIndex = -1;
        int MRUnumber = 10;

        ServiceController svc1;// = new ServiceController("EnableServer71_Enable_JBOSS_8034");
        ServiceController svc2;// = new ServiceController("EnableServer71_Enable_TOMCAT_8090");

        public ConfigEditorForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            rbJboss.Click += new EventHandler(radioButton1_Click);
            rbSynchronizedEdit.Click += new EventHandler(rbSynchronizedEdit_Click);
            this.DragEnter += new DragEventHandler(ConfigEditorForm_DragEnter);
            this.DragDrop += new DragEventHandler(ConfigEditorForm_DragDrop);
            GetServices();
            CheckServices();
            LoadRecentList(); //load a configuration-like file containing recent list

            foreach (string item in MRUlist)
            {
                //populating menu
                ToolStripMenuItem fileRecent =
                 new ToolStripMenuItem(item, null, RecentFile_click);
                //add the menu to "recent" menu
                recentToolStripMenuItem.DropDownItems.Add(fileRecent);
            }
        }

        void rbSynchronizedEdit_Click(object sender, EventArgs e)
        {
            rbSynchronizedEdit.Checked = !rbSynchronizedEdit.Checked;
        }

        public ConfigEditorForm(string arg)
        {
            InitializeComponent();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            rbJboss.Click += new EventHandler(radioButton1_Click);
            rbSynchronizedEdit.Click += new EventHandler(rbSynchronizedEdit_Click);
            this.DragEnter += new DragEventHandler(ConfigEditorForm_DragEnter);
            this.DragDrop += new DragEventHandler(ConfigEditorForm_DragDrop);
            GetServices();
            CheckServices();
            LoadRecentList(); //load a configuration-like file containing recent list

            foreach (string item in MRUlist)
            {
                //populating menu
                ToolStripMenuItem fileRecent =
                 new ToolStripMenuItem(item, null, RecentFile_click);
                //add the menu to "recent" menu
                recentToolStripMenuItem.DropDownItems.Add(fileRecent);
            }

            file = arg;

            LoadGridView(arg);
        }

        void ConfigEditorForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            //foreach (string file in files) 
            //    Console.WriteLine(file);
            LoadGridView(files[0]);
        }

        void ConfigEditorForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void GetServices()
        {
            ServiceController[] services = ServiceController.GetServices();

            foreach (ServiceController srvc in services)
            {
                if (srvc.DisplayName.Contains("Enable"))
                {
                    if(srvc.DisplayName.Contains("JBOSS"))
                    {
                        svc1 = new ServiceController(srvc.DisplayName);
                    }else if(srvc.DisplayName.Contains("TOMCAT"))
                    {
                        svc2 = new ServiceController(srvc.DisplayName);
                    }
                }
            }
        }

        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (e.ColumnIndex > 0)
                {
                    oldValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()
                                     + "=" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                }
                else
                {
                    oldValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
                                     + "=" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString();
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "java Properties files (*.properties)|*.properties";
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                file = openFileDialog1.FileName;
                try
                {
                    LoadGridView(file);             
                }
                catch (IOException)
                {
                }
            }
        }

        void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string newValue = "";

            if (e.ColumnIndex > 0)
            {
                newValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString()
                                 + "=" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
            else
            {
                newValue = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()
                                 + "=" + dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value.ToString();
            }

           ReplaceInFile(file, oldValue, newValue);
        }

        public  void LoadGridView(string path)
        {
            SaveRecentFile(path);

            this.Text = path;

            if (path.ToLower().Contains("sharedconfig"))
            {
                rbSynchronizedEdit.Visible = true;

                if (path.ToLower().Contains("jboss"))
                {
                    rbSynchronizedEdit.Text = "Edit Tomcat";
                }
                else if (path.ToLower().Contains("tomcat"))
                {
                    rbSynchronizedEdit.Text = "Edit JBoss";
                }
            }
            else
            {
                rbSynchronizedEdit.Visible = false;
            }

            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows.Clear();
            }
            using (StreamReader sr = new StreamReader(path))
            {
                fileData = sr.ReadToEnd();
                sr.Close();
            }

            string[] kvp;
            records = fileData.Split("\r\n".ToCharArray());
            
            foreach (string record in records)
            {
                if ((!Regex.IsMatch(record, "# "))
                    &&((!record.StartsWith("#") && record.Trim().Length > 0)//all active settings/ no empty lines
                    || (record.StartsWith("#") && record.Contains("="))))
                {
                    kvp = record.Split(new char[] { '=' }, 2); 
                    dataGridView1.Rows.Add(kvp[0], kvp[1]);
                }
                
            }

        }

        private void ReplaceInFile(string filePath, string searchText, string replaceText)
        {

            string content;
            content = GetFileContents(filePath);
            content = Regex.Replace(content, searchText, replaceText);
            OverWriteFile(filePath, content);

            if (rbSynchronizedEdit.Checked)
            {
                string[] items = filePath.Split(new char[] {'\\'});

                string firstPart = string.Join("\\", items.Take(3).ToArray());

                if (filePath.ToLower().Contains("jboss"))
                {
                    filePath = Path.Combine(firstPart, 
                                            Path.Combine(ConfigurationManager.AppSettings["TomcatPath"], items[items.Length -1]));
                }
                else if(filePath.ToLower().Contains("tomcat"))
                {
                    filePath = Path.Combine(firstPart, 
                                            Path.Combine(ConfigurationManager.AppSettings["JbossPath"], items[items.Length - 1]));
                }
                OverWriteFile(filePath, content);
            }



            
        }

        private string GetFileContents(string fileFullPath)
        {
            StreamReader reader = new StreamReader(fileFullPath);
            string content = reader.ReadToEnd();
            reader.Close();
            return content;
        }

        private void OverWriteFile(string fileFullPath, string contents)
        {
            StreamWriter writer = new StreamWriter(fileFullPath);
            writer.Write(contents);
            writer.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void generatePassword_Click(object sender, EventArgs e)
        {
            string result = "";
            int response = -1;
            string toEncrypt = tbPasswordToEncrypt.Text;
            string encryptor = "";
            tbEncryptedPassword.Visible = true;

            if (rbJboss.Checked)
            {
                encryptor = ConfigurationManager.AppSettings["EncryptJboss"];
            }
            else
            {
                encryptor = ConfigurationManager.AppSettings["EncryptPassword"];
            } 
            //string encryptor = ConfigurationManager.AppSettings["Jboss"];
            //System.Diagnostics.Process.Start("cmd.exe", "/c " + encryptor + " "+ toEncrypt);
            ProcessStartInfo psi = new ProcessStartInfo(encryptor + " ",toEncrypt);
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            Process proc = new System.Diagnostics.Process();
            proc = System.Diagnostics.Process.Start(psi);
            System.IO.StreamReader myoutput = proc.StandardOutput;
            proc.WaitForExit(2000);

            

            if (proc.HasExited)
            {
                result = myoutput.ReadToEnd();
                response = proc.ExitCode;
            }

            if (rbJboss.Checked)
            {
                tbEncryptedPassword.Text = result.Replace("Encoded password: ", "");
            }
            else
            {
                tbEncryptedPassword.Text = result.Replace("EncryptedString=", "");
            }
            
                
        }

        private void btnRestartSvcs_Click(object sender, EventArgs e)
        {
           if (svc1.Status.Equals(ServiceControllerStatus.Running))
            {
                svc1.Stop();
                svc1.WaitForStatus(ServiceControllerStatus.Stopped);
                rbJBossStatus.Checked = !rbJBossStatus.Checked;
                
            }
            else
            {
                svc1.Start();
                svc1.WaitForStatus(ServiceControllerStatus.Running);
                rbJBossStatus.Checked = !rbJBossStatus.Checked;
                
            }

            System.Threading.Thread.Sleep(3);

            if (svc2.Status.Equals(ServiceControllerStatus.Running))
            {
                svc2.Stop();
                svc2.WaitForStatus(ServiceControllerStatus.Stopped);
                rbTomcatStatus.Checked = !rbTomcatStatus.Checked;
                btnRestartSvcs.Text = "Start Svcs";
            }
            else
            {
                svc2.Start();
                svc2.WaitForStatus(ServiceControllerStatus.Running);
                rbTomcatStatus.Checked = !rbTomcatStatus.Checked;
                btnRestartSvcs.Text = "Stop Svcs";
            }
        }

        private void editTomcatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void recentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RecentFile_click(object sender, EventArgs e)
        {
            file = sender.ToString();
            LoadGridView(sender.ToString());
        }

        private void SaveRecentFile(string path)
        {
            //clear all recent list from menu
            recentToolStripMenuItem.DropDownItems.Clear();
            LoadRecentList(); //load list from file
            if (!(MRUlist.Contains(path))) //prevent duplication on recent list
                MRUlist.Insert(0, path); //insert given path into list
            //keep list number not exceeded the given value
            
            if(MRUlist.Count > MRUnumber)
            {
                MRUlist.RemoveRange(MRUnumber - 1, MRUnumber - MRUlist.Count);
            }

            foreach (string item in MRUlist)
            {
                //create new menu for each item in list
                ToolStripMenuItem fileRecent = 
                        new ToolStripMenuItem(item, null, RecentFile_click);
                //add the menu to "recent" menu
                recentToolStripMenuItem.DropDownItems.Add(fileRecent);
            }
            //writing menu list to file
            //create file called "Recent.txt" located on app folder
            StreamWriter stringToWrite =
                    new StreamWriter(System.Environment.CurrentDirectory + "\\Recent.txt");

            foreach (string item in MRUlist)
            {
                stringToWrite.WriteLine(item); //write list to stream
            }
            stringToWrite.Flush(); //write stream to file
            stringToWrite.Close(); //close the stream and reclaim memory
        }
		
		private void CheckServices()
        {
            rbJBossStatus.Checked = svc1.Status.Equals(ServiceControllerStatus.Running);
            rbTomcatStatus.Checked = svc2.Status.Equals(ServiceControllerStatus.Running);
            if (rbJBossStatus.Checked && rbTomcatStatus.Checked)
                btnRestartSvcs.Text = "Stop Svcs";
        }

        private void LoadRecentList()
        {//try to load file. If file isn't found, do nothing
            MRUlist.Clear();
            try
            {
                //read file stream
                StreamReader listToRead =
              new StreamReader(System.Environment.CurrentDirectory + "\\Recent.txt");
                string line;
                while ((line = listToRead.ReadLine()) != null) //read each line until end of file
                    MRUlist.Insert(0,line); //insert to list
                listToRead.Close(); //close the stream
            }
            catch (Exception) { }
        }

        private void tbSearchText_TextChanged(object sender, EventArgs e)
        {
            string searchValue = tbSearchText.Text;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewColumn col in dataGridView1.Columns)
                    {
                        if (dataGridView1.Rows[row.Index].Cells[col.Index].Value.ToString().Contains(searchValue))
                        {
                            rowIndex = row.Index;
                            dataGridView1.ClearSelection();
                            dataGridView1.Rows[rowIndex].Selected = true;
                            dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex;
                            //dataGridView1.Focus();
                            break;

                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }        
        }

        private void ConfigEditorForm_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }


    }

    public class RowData
    {
        public RowData(int line,string prop,string val)
        {
            this.LineNumber = line;
            this.Property = prop;
            this.Setting = val;
        }

        public int LineNumber { get; set; }
        public string Property { get; set; }
        public string Setting { get; set; }
    }
}
