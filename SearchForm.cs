using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FTSearch
{
    public partial class SearchForm : Form
    {
        public const string INDEXDB_FOLDER = "IndexDB";

        public SearchForm()
        {
            InitializeComponent();
        }

        private void btnBrowseFolderToIndex_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            string pathSelected = folderBrowserDialog1.SelectedPath;
            tbFolderToIndex.Text = pathSelected;
            tbIndexDBName.Text = Path.GetFileName(pathSelected);
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            UpdateIndexDBView();
        }

        private void UpdateIndexDBView()
        {
            try
            {
                IList<string> listIndexDB = new List<string>();

                if (!Directory.Exists(INDEXDB_FOLDER))
                    Directory.CreateDirectory(INDEXDB_FOLDER);
                DirectoryInfo dir = new DirectoryInfo(INDEXDB_FOLDER);
                DirectoryInfo[] subDirs = dir.GetDirectories();
                foreach (DirectoryInfo subDir in subDirs)
                    listIndexDB.Add(subDir.Name);

                cboIndexDB.Items.Clear();
                listViewIndexDB.Items.Clear();
                foreach (string file in listIndexDB)
                {
                    cboIndexDB.Items.Add(file);
                    listViewIndexDB.Items.Add(file);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private void btnIndex_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbFolderToIndex.Text.Trim()) || string.IsNullOrEmpty(tbIndexDBName.Text.Trim()))
            {
                MessageBox.Show("Please enter required fields", "Warning");
                return;
            }
            Helper.TBFileIndexing = tbFileIndexing;
            Helper.Index(tbFolderToIndex.Text, tbIndexDBName.Text.Trim());
            MessageBox.Show("Index completed!!!");
            UpdateIndexDBView();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string term = tbSearch.Text.Trim();
            if (term.Length <= 2)
            {
                MessageBox.Show("Search term must be greater than 2 characters","Warning");
                return;
            }

            gvResults.DataSource = Helper.SearchInDB(tbSearch.Text, cboIndexDB.Text, tbRootFolder.Text);
            //UpdateIndexDBView();
        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void cboIndexDB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDB = cboIndexDB.Text;
            string configPath = INDEXDB_FOLDER + "\\" + selectedDB + "\\config.txt";
            if (System.IO.File.Exists(configPath))
            {
                string[] lines = System.IO.File.ReadAllLines(configPath);
                tbRootFolder.Text = lines.Length > 0 ? lines[0] : string.Empty;
            }
        }
    }
}
