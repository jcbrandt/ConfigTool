using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConfigTool
{
    public partial class Form1 : Form
    {
        List<RowData> dataRows;
        string oldValue = "";
        string file;
        string[] records;
        string fileData = "";
        int rowIndex = -1;



        public Form1()
        {
            InitializeComponent();
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(dataGridView1_CellValueChanged);
            radioButton1.Click += new EventHandler(radioButton1_Click);

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

           //ReplaceInFile(file, oldValue, newValue);
        }

        public  void LoadGridView(string path)
        {
            if (dataGridView1.RowCount > 0)
            {
                dataGridView1.Rows.Clear();
            }
            using (StreamReader sr = new StreamReader(path))
            {
                fileData = sr.ReadToEnd().Replace("\r", "");
                sr.Close();
            }

            string[] kvp;
            records = fileData.Split("\n".ToCharArray());
            
            foreach (string record in records)
            {
                if ((!record.StartsWith("#") && record.Trim().Length > 0)
                    || (record.StartsWith("#") && record.Contains("=")))
                {
                    if (!Regex.IsMatch(record, "# "))
                    {
                        kvp = record.Split("=".ToCharArray());
                        dataGridView1.Rows.Add(kvp[0], kvp[1]);
                    }
                }
                
            }

        }

        static public void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            StreamReader reader = new StreamReader(filePath);
            string content = reader.ReadToEnd();
            reader.Close();

            content = Regex.Replace(content, searchText, replaceText);

            StreamWriter writer = new StreamWriter(filePath);
            writer.Write(content);
            writer.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            string searchValue = textBox1.Text;

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
                            dataGridView1.Focus();
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

        private void generatePassword_Click(object sender, EventArgs e)
        {
            string result = "";
            int response = -1;
            string toEncrypt = textBox2.Text;
            string encryptor = "";
            if (radioButton1.Checked)
            {
                encryptor = ConfigurationManager.AppSettings["Jboss"];
            }
            else
            {
                encryptor = ConfigurationManager.AppSettings["Epim"];
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
            if (radioButton1.Checked)
            {
                textBox3.Text = result.Replace("Encoded password: ", "");
            }
            else
            {
                textBox3.Text = result.Replace("EncryptedString=", "");
            }
            
            textBox3.Visible = true;
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
