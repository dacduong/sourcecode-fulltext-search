namespace FTSearch
{
    partial class SearchForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.gvResults = new System.Windows.Forms.DataGridView();
            this.File = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboIndexDB = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageIndex = new System.Windows.Forms.TabPage();
            this.tbFileIndexing = new System.Windows.Forms.TextBox();
            this.btnIndex = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbIndexDBName = new System.Windows.Forms.TextBox();
            this.listViewIndexDB = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseFolderToIndex = new System.Windows.Forms.Button();
            this.tbFolderToIndex = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRootFolder = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPageSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            this.tabPageIndex.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSearch);
            this.tabControl1.Controls.Add(this.tabPageIndex);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(795, 401);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Controls.Add(this.tbRootFolder);
            this.tabPageSearch.Controls.Add(this.label5);
            this.tabPageSearch.Controls.Add(this.gvResults);
            this.tabPageSearch.Controls.Add(this.btnSearch);
            this.tabPageSearch.Controls.Add(this.tbSearch);
            this.tabPageSearch.Controls.Add(this.label4);
            this.tabPageSearch.Controls.Add(this.cboIndexDB);
            this.tabPageSearch.Controls.Add(this.label3);
            this.tabPageSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearch.Size = new System.Drawing.Size(787, 375);
            this.tabPageSearch.TabIndex = 0;
            this.tabPageSearch.Text = "Search";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // gvResults
            // 
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.File,
            this.Score});
            this.gvResults.Location = new System.Drawing.Point(9, 93);
            this.gvResults.Name = "gvResults";
            this.gvResults.Size = new System.Drawing.Size(772, 276);
            this.gvResults.TabIndex = 7;
            // 
            // File
            // 
            this.File.DataPropertyName = "Path";
            this.File.HeaderText = "Path";
            this.File.MinimumWidth = 500;
            this.File.Name = "File";
            this.File.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.File.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.File.Width = 500;
            // 
            // Score
            // 
            this.Score.DataPropertyName = "Score";
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            this.Score.ReadOnly = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(237, 64);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(96, 38);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(216, 20);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSearch_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Search";
            // 
            // cboIndexDB
            // 
            this.cboIndexDB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIndexDB.FormattingEnabled = true;
            this.cboIndexDB.Location = new System.Drawing.Point(96, 7);
            this.cboIndexDB.Name = "cboIndexDB";
            this.cboIndexDB.Size = new System.Drawing.Size(216, 21);
            this.cboIndexDB.TabIndex = 1;
            this.cboIndexDB.SelectedIndexChanged += new System.EventHandler(this.cboIndexDB_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Select IndexDB";
            // 
            // tabPageIndex
            // 
            this.tabPageIndex.Controls.Add(this.tbFileIndexing);
            this.tabPageIndex.Controls.Add(this.btnIndex);
            this.tabPageIndex.Controls.Add(this.label2);
            this.tabPageIndex.Controls.Add(this.tbIndexDBName);
            this.tabPageIndex.Controls.Add(this.listViewIndexDB);
            this.tabPageIndex.Controls.Add(this.label1);
            this.tabPageIndex.Controls.Add(this.btnBrowseFolderToIndex);
            this.tabPageIndex.Controls.Add(this.tbFolderToIndex);
            this.tabPageIndex.Location = new System.Drawing.Point(4, 22);
            this.tabPageIndex.Name = "tabPageIndex";
            this.tabPageIndex.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIndex.Size = new System.Drawing.Size(787, 375);
            this.tabPageIndex.TabIndex = 1;
            this.tabPageIndex.Text = "Index";
            this.tabPageIndex.UseVisualStyleBackColor = true;
            // 
            // tbFileIndexing
            // 
            this.tbFileIndexing.Location = new System.Drawing.Point(9, 118);
            this.tbFileIndexing.Multiline = true;
            this.tbFileIndexing.Name = "tbFileIndexing";
            this.tbFileIndexing.ReadOnly = true;
            this.tbFileIndexing.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbFileIndexing.Size = new System.Drawing.Size(771, 251);
            this.tbFileIndexing.TabIndex = 11;
            // 
            // btnIndex
            // 
            this.btnIndex.Location = new System.Drawing.Point(290, 62);
            this.btnIndex.Name = "btnIndex";
            this.btnIndex.Size = new System.Drawing.Size(75, 23);
            this.btnIndex.TabIndex = 7;
            this.btnIndex.Text = "Index";
            this.btnIndex.UseVisualStyleBackColor = true;
            this.btnIndex.Click += new System.EventHandler(this.btnIndex_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "IndexDB Name*";
            // 
            // tbIndexDBName
            // 
            this.tbIndexDBName.Location = new System.Drawing.Point(89, 36);
            this.tbIndexDBName.Name = "tbIndexDBName";
            this.tbIndexDBName.Size = new System.Drawing.Size(276, 20);
            this.tbIndexDBName.TabIndex = 5;
            // 
            // listViewIndexDB
            // 
            this.listViewIndexDB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewIndexDB.FullRowSelect = true;
            this.listViewIndexDB.Location = new System.Drawing.Point(528, 6);
            this.listViewIndexDB.Name = "listViewIndexDB";
            this.listViewIndexDB.Size = new System.Drawing.Size(253, 105);
            this.listViewIndexDB.TabIndex = 10;
            this.listViewIndexDB.TileSize = new System.Drawing.Size(250, 20);
            this.listViewIndexDB.UseCompatibleStateImageBehavior = false;
            this.listViewIndexDB.View = System.Windows.Forms.View.List;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Folder to Index*";
            // 
            // btnBrowseFolderToIndex
            // 
            this.btnBrowseFolderToIndex.Location = new System.Drawing.Point(371, 7);
            this.btnBrowseFolderToIndex.Name = "btnBrowseFolderToIndex";
            this.btnBrowseFolderToIndex.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseFolderToIndex.TabIndex = 1;
            this.btnBrowseFolderToIndex.Text = "Browse...";
            this.btnBrowseFolderToIndex.UseVisualStyleBackColor = true;
            this.btnBrowseFolderToIndex.Click += new System.EventHandler(this.btnBrowseFolderToIndex_Click);
            // 
            // tbFolderToIndex
            // 
            this.tbFolderToIndex.Location = new System.Drawing.Point(89, 7);
            this.tbFolderToIndex.Name = "tbFolderToIndex";
            this.tbFolderToIndex.Size = new System.Drawing.Size(276, 20);
            this.tbFolderToIndex.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(318, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Root Folder";
            // 
            // tbRootFolder
            // 
            this.tbRootFolder.Location = new System.Drawing.Point(384, 7);
            this.tbRootFolder.Name = "tbRootFolder";
            this.tbRootFolder.Size = new System.Drawing.Size(232, 20);
            this.tbRootFolder.TabIndex = 9;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 426);
            this.Controls.Add(this.tabControl1);
            this.Name = "SearchForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FTSearch";
            this.Load += new System.EventHandler(this.SearchForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSearch.ResumeLayout(false);
            this.tabPageSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).EndInit();
            this.tabPageIndex.ResumeLayout(false);
            this.tabPageIndex.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.TabPage tabPageIndex;
        private System.Windows.Forms.ListView listViewIndexDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowseFolderToIndex;
        private System.Windows.Forms.TextBox tbFolderToIndex;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbIndexDBName;
        private System.Windows.Forms.Button btnIndex;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboIndexDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbFileIndexing;
        private System.Windows.Forms.DataGridView gvResults;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.DataGridViewTextBoxColumn File;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.TextBox tbRootFolder;
        private System.Windows.Forms.Label label5;
    }
}

