using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace appNote
{
    public partial class frmMain : Form
    {
        string currentFile = string.Empty;
        
        public frmMain()
        {
            InitializeComponent();
        }

        
        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

       

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Bạn định thoát ư  '", "Thông báo", MessageBoxButtons.OK);
        }
        private void toolStripSave_Click(object sender, EventArgs e)
        {
            if(currentFile == string.Empty)
            {
                toolStripSaveAs_Click(sender, e);
                return;
            }
            using (StreamWriter sw = new StreamWriter(currentFile, false, Encoding.UTF8))
            {
                sw.WriteLine(rtxtInput.Text);
                sw.Close();
                MessageBox.Show("Lưu thành công!");
            }
        }

        private void toolStripOpen_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.Title = "Select file txt";
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    currentFile = openFileDialog.FileName; // 
                    string fileName = Path.GetFileName(currentFile);
                    this.Text = "App Note - " + fileName;

                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        rtxtInput.ResetText();
                        rtxtInput.Text = reader.ReadToEnd();
                    }
                }
            }
        }

        private void toolStripSaveAs_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
            {
                // |All files (*.*)|*.*
                saveFileDialog1.Title = "Save as";
                saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                saveFileDialog1.FileName = "file1.txt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter file = new StreamWriter(saveFileDialog1.FileName.ToString(), false, Encoding.UTF8);
                    file.WriteLine(rtxtInput.Text);
                    currentFile = saveFileDialog1.FileName;
                    string fileName = fileName = Path.GetFileName(currentFile);
                    this.Text = "App Note - " + fileName;
                    file.Close();
                    MessageBox.Show("Lưu thành công!");
                }
            }
        }

        private void newApp_Click(object sender, EventArgs e)
        {
            frmMain frmMain = new frmMain();
            frmMain.Show();
        }
    }
}
