using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MusicDB
{
    public partial class MainForm : Form
    {
        private everyloopContext db = new everyloopContext();
        public List<Playlist> playlistNames;
        public static Playlist SelectedPlaylist { get; set; }
        public MainForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            if (db.Database.CanConnect())
            {
                AddToTreeView();
            }
            else Debug.WriteLine("Connection failed!");
        }

        private void AddToTreeView()
        {
            var playlistRootName = "PlayLists";
            var playlistNode = new TreeNode()
            {
                Text = $"{playlistRootName}",
                Tag = "Playlist"
            };
            treeView1.Nodes.Add(playlistNode);

                 playlistNames = db.Playlists
                .Include(t => t.PlaylistTracks)
                .ThenInclude(playlistTrack => playlistTrack.Track)
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
            foreach (Playlist playlist in db.Playlists) //playlistNames)
            {
                int rowIndex = DGVPlaylist.Rows.Add();
                DGVPlaylist.Rows[rowIndex].Cells["PlaylistId"].Value = playlist.PlaylistId;
                DGVPlaylist.Rows[rowIndex].Cells["PlaylistName"].Value = playlist.Name;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVPlaylist.Columns[e.ColumnIndex].Name == "View")
            {
                var pView = new PlaylistTrackControl() { Dock = DockStyle.Fill };
                splitContainer1.Panel2.Controls.Add(pView);
                pView.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (SelectedPlaylist != null)
            {
                int rowIndex = DGVPlaylist.CurrentCell.RowIndex;

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
                    txtPlaylistName.Clear();
                    db.SaveChanges();
                    MessageBox.Show($"{SelectedPlaylist.Name} is deleted successfully!", "Info:", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            
        }

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = DGVPlaylist.Rows[index];
            txtPlaylistName.Text = selectedRow.Cells[1].Value.ToString();
            foreach (Playlist p in db.Playlists) //playlistNames)
            {
                if (selectedRow.Cells[1].Value.ToString() == p.Name)
                {
                    SelectedPlaylist = p;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPlaylistName.Text == "")
            {
                MessageBox.Show("You need to add playlist name!", "Message:", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            var checkExistingPlaylist = db.Playlists.Where(p => p.Name == txtPlaylistName.Text);
            if(checkExistingPlaylist.ToArray().Length > 0)
            {
                MessageBox.Show("Playlist already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newPlaylist = new Playlist
            {
                Name = txtPlaylistName.Text, PlaylistId = db.Playlists.Max(p => p.PlaylistId) + 1
            };
           
            db.Playlists.Add(newPlaylist);
            db.SaveChanges();
            txtPlaylistName.Clear();
            LoadToDataGridView();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtPlaylistName.Clear();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            db.SaveChanges();
            db.Dispose();
        }

    }
}
