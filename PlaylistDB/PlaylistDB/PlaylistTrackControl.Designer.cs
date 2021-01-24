namespace PlaylistDB
{
    partial class PlaylistTrackControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblActivePlaylist = new System.Windows.Forms.Label();
            this.txtActivePlaylist = new System.Windows.Forms.TextBox();
            this.btnAddTrack = new System.Windows.Forms.Button();
            this.btnDeleteTrack = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.Song = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVPlaylistTrack = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPlaylistTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblActivePlaylist
            // 
            this.lblActivePlaylist.AutoSize = true;
            this.lblActivePlaylist.Location = new System.Drawing.Point(15, 22);
            this.lblActivePlaylist.Name = "lblActivePlaylist";
            this.lblActivePlaylist.Size = new System.Drawing.Size(47, 15);
            this.lblActivePlaylist.TabIndex = 0;
            this.lblActivePlaylist.Text = "Playlist:";
            // 
            // txtActivePlaylist
            // 
            this.txtActivePlaylist.Enabled = false;
            this.txtActivePlaylist.Location = new System.Drawing.Point(86, 19);
            this.txtActivePlaylist.Name = "txtActivePlaylist";
            this.txtActivePlaylist.Size = new System.Drawing.Size(166, 23);
            this.txtActivePlaylist.TabIndex = 2;
            // 
            // btnAddTrack
            // 
            this.btnAddTrack.Location = new System.Drawing.Point(15, 57);
            this.btnAddTrack.Name = "btnAddTrack";
            this.btnAddTrack.Size = new System.Drawing.Size(81, 22);
            this.btnAddTrack.TabIndex = 3;
            this.btnAddTrack.Text = "Add Track";
            this.btnAddTrack.UseVisualStyleBackColor = true;
            this.btnAddTrack.Click += new System.EventHandler(this.btnAddTrack_Click);
            // 
            // btnDeleteTrack
            // 
            this.btnDeleteTrack.Location = new System.Drawing.Point(171, 57);
            this.btnDeleteTrack.Name = "btnDeleteTrack";
            this.btnDeleteTrack.Size = new System.Drawing.Size(81, 22);
            this.btnDeleteTrack.TabIndex = 4;
            this.btnDeleteTrack.Text = "Delete Track";
            this.btnDeleteTrack.UseVisualStyleBackColor = true;
            this.btnDeleteTrack.Click += new System.EventHandler(this.btnDeleteTrack_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(469, 57);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(131, 22);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Go back to playlist";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Song
            // 
            this.Song.HeaderText = "Songs";
            this.Song.Name = "Song";
            this.Song.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Song.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Length
            // 
            this.Length.HeaderText = "Length";
            this.Length.Name = "Length";
            this.Length.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // DGVPlaylistTrack
            // 
            this.DGVPlaylistTrack.AllowUserToAddRows = false;
            this.DGVPlaylistTrack.AllowUserToDeleteRows = false;
            this.DGVPlaylistTrack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVPlaylistTrack.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVPlaylistTrack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVPlaylistTrack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Song,
            this.Length});
            this.DGVPlaylistTrack.Location = new System.Drawing.Point(0, 95);
            this.DGVPlaylistTrack.Name = "DGVPlaylistTrack";
            this.DGVPlaylistTrack.RowHeadersVisible = false;
            this.DGVPlaylistTrack.Size = new System.Drawing.Size(634, 373);
            this.DGVPlaylistTrack.TabIndex = 1;
            this.DGVPlaylistTrack.Text = "dataGridView1";
            this.DGVPlaylistTrack.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPlaylistTrack_CellValueChanged);
            // 
            // PlaylistTrackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteTrack);
            this.Controls.Add(this.btnAddTrack);
            this.Controls.Add(this.txtActivePlaylist);
            this.Controls.Add(this.DGVPlaylistTrack);
            this.Controls.Add(this.lblActivePlaylist);
            this.Name = "PlaylistTrackControl";
            this.Size = new System.Drawing.Size(634, 468);
            this.Load += new System.EventHandler(this.PlaylistTrackControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPlaylistTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblActivePlaylist;
        private System.Windows.Forms.TextBox txtActivePlaylist;
        private System.Windows.Forms.Button btnAddTrack;
        private System.Windows.Forms.Button btnDeleteTrack;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView DGVPlaylistTrack;
        private System.Windows.Forms.DataGridViewComboBoxColumn Song;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
    }
}
