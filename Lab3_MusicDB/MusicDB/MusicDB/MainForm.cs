using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MusicDB
{
    public partial class MainForm : Form
    {
        public everyloopContext Db = new everyloopContext();
        private Playlist _selectedPlaylist;

        public MainForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Db.Database.CanConnect())
            {
                AddToTreeView();
            }
            else Debug.WriteLine("Connection failed!");
        }

        public void AddToTreeView()
        {
            treeView1.Nodes.Clear();

            var playlistNames = Db.Playlists
                .Include(t => t.PlaylistTracks)
                .ThenInclude(playlistTrack => playlistTrack.Track)
                .ToList();

            var playlistRootName = "PlayLists";

            var playlistNode = new TreeNode()
            {
                Text = $"{playlistRootName}",
                Tag = "Playlist"
            };
            treeView1.Nodes.Add(playlistNode);

            foreach (Playlist playlist in playlistNames)
            {
                TreeNode playNameNode = new TreeNode()
                {
                    Text = $"{playlist.Name}",
                    Tag = playlist
                };
                playlistNode.Nodes.Add(playNameNode);
            }
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
            foreach (Playlist playlist in Db.Playlists)
            {
                int rowIndex = DGVPlaylist.Rows.Add();
                DGVPlaylist.Rows[rowIndex].Tag = playlist;

                DGVPlaylist.Rows[rowIndex].Cells["PlaylistId"].Value = playlist.PlaylistId;
                DGVPlaylist.Rows[rowIndex].Cells["PlaylistName"].Value = playlist.Name;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVPlaylist.Columns[e.ColumnIndex].Name == "View")
            {
                if (_selectedPlaylist != null)
                { 
                    var playlistTrackControl = new PlaylistTrackControl(_selectedPlaylist, Db);
                    
                    playlistTrackControl.Dock = DockStyle.Fill;
                    splitContainer1.Panel2.Controls.Add(playlistTrackControl);
                    playlistTrackControl.BringToFront();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtPlaylistName.Text == "")
            {
                MessageBox.Show("Please select playlist first!", "Message:", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (_selectedPlaylist != null)
            {
                int rowIndex = DGVPlaylist.CurrentCell.RowIndex;

                if (DGVPlaylist.Rows[rowIndex].Tag is Playlist playlist)
                {
                    if (MessageBox.Show($"Are you sure want to delete this playlist {playlist.Name}?",
                        "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DGVPlaylist.Rows.RemoveAt(rowIndex);

                        if (playlist.PlaylistTracks != null)
                        {
                            foreach (var playlistTrack in playlist.PlaylistTracks)
                            {
                                Db.Remove(playlistTrack);
                            }
                        }

                        Db.Playlists?.Remove(playlist);
                        Db.SaveChanges();
                        AddToTreeView();
                        txtPlaylistName.Clear();
                        MessageBox.Show($"{playlist.Name} was deleted successfully!", "Info:",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = DGVPlaylist.Rows[index];
            txtPlaylistName.Text = selectedRow.Cells[1].Value.ToString();
            foreach (Playlist playlist in Db.Playlists)
            {
                if (selectedRow.Cells[1].Value.ToString() == playlist.Name)
                {
                    _selectedPlaylist = playlist;
                }
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (txtPlaylistName.Text == "")
            {
                MessageBox.Show("You need to add playlist name!", "Message:", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            var checkExistingPlaylist = Db.Playlists.Where(p => p.Name == txtPlaylistName.Text);
            if (checkExistingPlaylist.ToArray().Length > 0)
            {
                MessageBox.Show("Playlist already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newPlaylist = new Playlist
            {
                Name = txtPlaylistName.Text,
                PlaylistId = Db.Playlists.Max(p => p.PlaylistId) + 1
            };

            Db.Playlists.Add(newPlaylist);
            Db.SaveChanges();
            AddToTreeView();
            txtPlaylistName.Clear();
            LoadToDataGridView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPlaylistName.Clear();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Db.SaveChanges();
            Db.Dispose();
        }
    }
}
