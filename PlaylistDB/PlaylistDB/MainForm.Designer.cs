namespace PlaylistDB
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.DGVPlaylist = new System.Windows.Forms.DataGridView();
            this.PlaylistId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaylistName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtPlaylistBox = new System.Windows.Forms.TextBox();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.lblPlaylist = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPlaylist)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DGVPlaylist);
            this.splitContainer1.Panel2.Controls.Add(this.btnReset);
            this.splitContainer1.Panel2.Controls.Add(this.btnDelete);
            this.splitContainer1.Panel2.Controls.Add(this.txtPlaylistBox);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddNew);
            this.splitContainer1.Panel2.Controls.Add(this.lblPlaylist);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            this.splitContainer1.Text = "splitContainer1";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(250, 450);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // DGVPlaylist
            // 
            this.DGVPlaylist.AllowUserToAddRows = false;
            this.DGVPlaylist.AllowUserToDeleteRows = false;
            this.DGVPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVPlaylist.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPlaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPlaylist.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlaylistId,
            this.PlaylistName,
            this.View});
            this.DGVPlaylist.Location = new System.Drawing.Point(3, 103);
            this.DGVPlaylist.Name = "DGVPlaylist";
            this.DGVPlaylist.RowHeadersVisible = false;
            this.DGVPlaylist.Size = new System.Drawing.Size(542, 346);
            this.DGVPlaylist.TabIndex = 5;
            this.DGVPlaylist.Text = "dataGridView1";
            this.DGVPlaylist.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPlaylist_CellClick);
            this.DGVPlaylist.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPlaylist_CellContentClick);
            // 
            // PlaylistId
            // 
            this.PlaylistId.HeaderText = "ID";
            this.PlaylistId.Name = "PlaylistId";
            this.PlaylistId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // PlaylistName
            // 
            this.PlaylistName.HeaderText = "Playlist Name";
            this.PlaylistName.Name = "PlaylistName";
            this.PlaylistName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // View
            // 
            this.View.HeaderText = "View";
            this.View.Name = "View";
            this.View.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.View.Text = "Details";
            this.View.UseColumnTextForButtonValue = true;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(428, 59);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 22);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(173, 59);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(105, 22);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Playlist";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtPlaylistBox
            // 
            this.txtPlaylistBox.Location = new System.Drawing.Point(116, 19);
            this.txtPlaylistBox.Name = "txtPlaylistBox";
            this.txtPlaylistBox.Size = new System.Drawing.Size(162, 23);
            this.txtPlaylistBox.TabIndex = 2;
            // 
            // btnAddNew
            // 
            this.btnAddNew.Location = new System.Drawing.Point(28, 59);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(106, 23);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Add New Playlist";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.AutoSize = true;
            this.lblPlaylist.Location = new System.Drawing.Point(28, 23);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(82, 15);
            this.lblPlaylist.TabIndex = 0;
            this.lblPlaylist.Text = "Playlist Name:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Main Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPlaylist)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView DGVPlaylist;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TextBox txtPlaylistBox;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label lblPlaylist;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaylistId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaylistName;
        private System.Windows.Forms.DataGridViewButtonColumn View;
    }
}

