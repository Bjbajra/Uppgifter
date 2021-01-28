namespace MusicDB
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
            this.lblPlaylist = new System.Windows.Forms.Label();
            this.txtActivePlaylist = new System.Windows.Forms.TextBox();
            this.btnAddTracks = new System.Windows.Forms.Button();
            this.btnDeleteTrack = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblSelectTrack = new System.Windows.Forms.Label();
            this.comboBoxTracklist = new System.Windows.Forms.ComboBox();
            this.Song = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Album = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVPlaylistTrack = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DGVPlaylistTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPlaylist
            // 
            this.lblPlaylist.AutoSize = true;
            this.lblPlaylist.Location = new System.Drawing.Point(14, 15);
            this.lblPlaylist.Name = "lblPlaylist";
            this.lblPlaylist.Size = new System.Drawing.Size(82, 15);
            this.lblPlaylist.TabIndex = 2;
            this.lblPlaylist.Text = "Playlist Name:";
            // 
            // txtActivePlaylist
            // 
            this.txtActivePlaylist.Location = new System.Drawing.Point(108, 12);
            this.txtActivePlaylist.Name = "txtActivePlaylist";
            this.txtActivePlaylist.Size = new System.Drawing.Size(145, 23);
            this.txtActivePlaylist.TabIndex = 3;
            // 
            // btnAddTracks
            // 
            this.btnAddTracks.Location = new System.Drawing.Point(278, 47);
            this.btnAddTracks.Name = "btnAddTracks";
            this.btnAddTracks.Size = new System.Drawing.Size(81, 21);
            this.btnAddTracks.TabIndex = 4;
            this.btnAddTracks.Text = "Add Track";
            this.btnAddTracks.UseVisualStyleBackColor = true;
            this.btnAddTracks.Click += new System.EventHandler(this.btnAddTracks_Click);
            // 
            // btnDeleteTrack
            // 
            this.btnDeleteTrack.Location = new System.Drawing.Point(278, 74);
            this.btnDeleteTrack.Name = "btnDeleteTrack";
            this.btnDeleteTrack.Size = new System.Drawing.Size(81, 21);
            this.btnDeleteTrack.TabIndex = 5;
            this.btnDeleteTrack.Text = "Delete Track";
            this.btnDeleteTrack.UseVisualStyleBackColor = true;
            this.btnDeleteTrack.Click += new System.EventHandler(this.btnDeleteTrack_Click_1);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(428, 72);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(101, 23);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Go back ";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblSelectTrack
            // 
            this.lblSelectTrack.AutoSize = true;
            this.lblSelectTrack.Location = new System.Drawing.Point(14, 50);
            this.lblSelectTrack.Name = "lblSelectTrack";
            this.lblSelectTrack.Size = new System.Drawing.Size(71, 15);
            this.lblSelectTrack.TabIndex = 7;
            this.lblSelectTrack.Text = "Select Track:";
            // 
            // comboBoxTracklist
            // 
            this.comboBoxTracklist.FormattingEnabled = true;
            this.comboBoxTracklist.Location = new System.Drawing.Point(91, 47);
            this.comboBoxTracklist.Name = "comboBoxTracklist";
            this.comboBoxTracklist.Size = new System.Drawing.Size(162, 23);
            this.comboBoxTracklist.TabIndex = 8;
            // 
            // Song
            // 
            this.Song.FillWeight = 45.4017F;
            this.Song.HeaderText = "Songs";
            this.Song.Name = "Song";
            this.Song.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Album
            // 
            this.Album.FillWeight = 30F;
            this.Album.HeaderText = "Album";
            this.Album.Name = "Album";
            this.Album.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Artist
            // 
            this.Artist.FillWeight = 20F;
            this.Artist.HeaderText = "Artist Name";
            this.Artist.Name = "Artist";
            this.Artist.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Length
            // 
            this.Length.FillWeight = 15.38948F;
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
            this.Album,
            this.Artist,
            this.Length});
            this.DGVPlaylistTrack.Location = new System.Drawing.Point(0, 98);
            this.DGVPlaylistTrack.Name = "DGVPlaylistTrack";
            this.DGVPlaylistTrack.RowHeadersVisible = false;
            this.DGVPlaylistTrack.Size = new System.Drawing.Size(538, 365);
            this.DGVPlaylistTrack.TabIndex = 0;
            this.DGVPlaylistTrack.Text = "dataGridView1";
            this.DGVPlaylistTrack.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVPlaylistTrack_CellValueChanged);
            // 
            // PlaylistTrackControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxTracklist);
            this.Controls.Add(this.lblSelectTrack);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDeleteTrack);
            this.Controls.Add(this.btnAddTracks);
            this.Controls.Add(this.txtActivePlaylist);
            this.Controls.Add(this.lblPlaylist);
            this.Controls.Add(this.DGVPlaylistTrack);
            this.Name = "PlaylistTrackControl";
            this.Size = new System.Drawing.Size(538, 463);
            this.Load += new System.EventHandler(this.ViewControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVPlaylistTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblPlaylist;
        private System.Windows.Forms.TextBox txtActivePlaylist;
        private System.Windows.Forms.Button btnAddTracks;
        private System.Windows.Forms.Button btnDeleteTrack;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView PlaylistTrackDGV;
        public System.Windows.Forms.DataGridView DGVPlaylistTrack;
        private System.Windows.Forms.Label lblSelectTrack;
        private System.Windows.Forms.ComboBox comboBoxTracklist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Song;
        private System.Windows.Forms.DataGridViewTextBoxColumn Album;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Length;
    }
}
