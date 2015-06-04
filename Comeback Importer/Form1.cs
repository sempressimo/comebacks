using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Comeback_Importer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void cmbCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(2015) CODEPR. All rights reserved.", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void WriteToOutput(string Message)
        {
            this.txtOutput.Text += "[" + DateTime.Now.ToString() + "] " + Message + Environment.NewLine + Environment.NewLine;

            Application.DoEvents();
        }

        private void cmbOK_Click(object sender, EventArgs e)
        {
            try
            {
                ComebackServiceReference1.Service1Client pService = new ComebackServiceReference1.Service1Client();

                string JustFileName = "Customers.csv";

                string Filename = pService.GetFilesPath(CGlobals.AppKey, 1) + @"\" + JustFileName;

                this.WriteToOutput("Looking for " + Filename + "...");

                string[] FileContentArray;

                if (File.Exists(Filename))
                {
                    this.WriteToOutput(JustFileName + " file found. Starting Import...");

                    using (StreamReader sr = new StreamReader(Filename))
                    {
                        FileContentArray = sr.ReadToEnd().Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                    }

                    if (FileContentArray.Count() > 0)
                    {
                        if (FileContentArray.Count() == 1)
                        {
                            this.WriteToOutput(JustFileName + " contains only 1 line. This can be a format error. Records must be ended with line feed and carriage return (Enter).");

                            return;
                        }

                        this.WriteToOutput(JustFileName + " contains " + FileContentArray.Count().ToString() + " records...");

                        string SecKey = "";
                        string RO_Number = "";
                        string VIN = "";
                        DateTime ComebackDate = new DateTime();
                        string Notes = "";
                        int IsOpen = 0;

                        pService.ImportComeback(SecKey, RO_Number, VIN, ComebackDate, Notes, IsOpen);


                    }
                }
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
