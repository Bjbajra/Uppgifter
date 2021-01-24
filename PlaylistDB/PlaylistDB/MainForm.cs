using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace PlaylistDB
{
    public partial class MainForm : Form
    {
        public static Playlist SelectedPlaylist { get; set; }
        private everyloopContext db = new everyloopContext();
        private Playlist activePlaylist = null;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (db.Database.CanConnect())
            {
                var playlistRootName = "PlayLists";
                var playlistNode = new TreeNode()
                {
                    Text = $"{playlistRootName}",
                    Tag = "Playlist"
                };
                treeView1.Nodes.Add(playlistNode);

                var playlistNames = db.Playlists
                   .Include(p => p.PlaylistTracks)
                       .ThenInclude(pTracks => pTracks.Track)
                   .ToList();

                foreach (Playlist playlist in playlistNames)
                {
                    TreeNode playNameNode = new TreeNode()
                    {
                        Text = $"{playlist.Name}",
                        Tag = playlist
                    };

                    foreach (PlaylistTrack track in playlist.PlaylistTracks)
                    {
                        TreeNode trackNode = new TreeNode()
                        {
                            Text = $"{track.Track.Name}",
                            Tag = playlist
                        };

                        playNameNode.Nodes.Add(trackNode);
                    }
                    playlistNode.Nodes.Add(playNameNode);

                }
            }
            else Debug.WriteLine("Connection failed!");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is "Playlist")
            {
                LoadToDataGridView();
            }
        }

        private void LoadToDataGridView()
        {
            DGVPlaylist.Rows.Clear();
            foreach (Playlist playlist in db.Playlists)
            {
                int rowIndex = DGVPlaylist.Rows.Add();
                DGVPlaylist.Rows[rowIndex].Cells["PlaylistId"].Value = playlist.PlaylistId;
                DGVPlaylist.Rows[rowIndex].Cells["PlaylistName"].Value = playlist.Name;
            }
        }

        private void DGVPlaylist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVPlaylist.Columns[e.ColumnIndex].Name == "View")
            {
                var playlistTrackControl = new PlaylistTrackControl() { Dock = DockStyle.Fill };
                splitContainer1.Panel2.Controls.Add(playlistTrackControl);
                playlistTrackControl.BringToFront();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (txtPlaylistBox.Text == "")
            {
                MessageBox.Show("You need to add playlist name!");
                return;
            }

            var checkExistingPlaylist = db.Playlists.Where(p => p.Name == txtPlaylistBox.Text);

            if (checkExistingPlaylist.ToArray().Length > 0)
            {
                MessageBox.Show("Playlist already exists!");
                return;
            }

            var newPlaylist = new Playlist
                {Name = txtPlaylistBox.Text, PlaylistId = db.Playlists.Max(p => p.PlaylistId) + 1};

            db.Playlists.Add(newPlaylist);
            db.SaveChanges();
            txtPlaylistBox.Clear();
            LoadToDataGridView();
        }


        private void DGVPlaylist_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = DGVPlaylist.Rows[index];
            txtPlaylistBox.Text = selectedRow.Cells[1].Value.ToString();

            foreach (Playlist playlist in db.Playlists)
            {
                if (selectedRow.Cells[0].Value.ToString() == playlist.PlaylistId.ToString())
                {
                    activePlaylist = playlist;
                    SelectedPlaylist = activePlaylist;
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPlaylistBox.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SelectedPlaylist != null)
            {
                int rowIndex = DGVPlaylist.CurrentCell.RowIndex;
                {
                    if (rowIndex < 0) return;

                    if (MessageBox.Show($"Are you sure want to delete this playlist {SelectedPlaylist.Name}?",
                        "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DGVPlaylist.Rows.RemoveAt(rowIndex);
                        foreach (var playlistTrack in SelectedPlaylist.PlaylistTracks)
                        {
                            db.Remove(playlistTrack);
                        }
                        db.Remove(SelectedPlaylist);
                        txtPlaylistBox.Clear();
                        db.SaveChanges();
                        MessageBox.Show($"Playlist: {SelectedPlaylist.Name} is deleted successfully!");
                    }
                }
            }

        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.SaveChanges();
            db.Dispose();
        }
    }

}
