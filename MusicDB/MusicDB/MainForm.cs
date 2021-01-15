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
        private List<Playlist> playlistNames; 
        public List<PlaylistTrack> playlistTracks;
        private Playlist activePlaylist = null;
        public static Playlist selectedPlaylist { get; set; }
        public MainForm()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
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

                var albumRootName = "Albums";
                var albumNode = new TreeNode(albumRootName);
                treeView1.Nodes.Add(albumNode);

                playlistTracks = db.PlaylistTracks.ToList();

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

                /* TODO: Include Albums on Albums */
                /* var albums = db.Albums
                    .Include(t => t.Tracks)
                    .Include(a => a.Artist)
                    .ToList();


                foreach (Album album in albums)
                {
                    TreeNode albumNameNode = new TreeNode($"{album.Title} -({album.Artist.Name})({album.Tracks.Count})");


                    foreach (Track track in album.Tracks)
                    {
                        TreeNode trackNode = new TreeNode()
                        {
                            Text = $"{track.Name}",
                            Tag = track
                        };

                        albumNameNode.Nodes.Add(trackNode);
                    }

                    albumNode.Nodes.Add(albumNameNode);
                }*/


            }
            else Debug.WriteLine("Connection failed!");
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //MessageBox.Show(e.Node.Text);

            if (e.Node.Tag is "Playlist")
            {
                //MessageBox.Show(p.Name);
                dataGridView1.Rows.Clear();
                foreach (Playlist p in db.Playlists)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    dataGridView1.Rows[rowIndex].Cells["PlaylistId"].Value = p.PlaylistId;
                    dataGridView1.Rows[rowIndex].Cells["PlaylistName"].Value = p.Name;
                }
            }

            /*if (e.Node.Tag is Playlist playlist)
            {
                activePlaylist = playlist;
                txtPlaylistName.Text = playlist.Name;
                //selectedPlaylist = activePlaylist.ToString();
            }*/

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
            //var cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];


            /*int rowIndex = dataGridView1.Rows.Add();
            /* if (dataGridView1.Rows[rowIndex].Cells["PlaylistName"].Value = p.Name;)
             if (dataGridView1.Columns[e.ColumnIndex].Name == "Playlist Name") //.Tag is Playlist playlist)
             {
                 activePlaylist.Name = "playlist";
                 txtPlaylistName.Text = activePlaylist.Name;
             }

             /*if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
             {
                 //if (dataGridView1.CurrentCell.Tag is Playlist playlist)
                 {
                     foreach (Playlist p in playlistNames)
                     {
                         //if (dataGridView1.CurrentCell.Tag is Playlist playlist)
                         {

                             if (MessageBox.Show($"Are you sure want to delete this playlist{p.Name}?",
                                 "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                             {
                                 //db.Remove(dataGridView1.CurrentCell.Value.ToString());
                                 //playlistNames.Remove(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.Value.ToString());
                                 //dataGridView1.SelectedRows.Clear();
                                 //db.Remove(playlist);
                                 var playlistToDelete = dataGridView1.CurrentRow;
                                // playlistToDelete.Selected.ToString().Remove(playlistToDelete);
                                 MessageBox.Show("hello");
                             }
                         }
                     }
                 }
             }*/

            if (dataGridView1.Columns[e.ColumnIndex].Name == "View")
            {
                // MessageBox.Show("view");
                var pView = new ViewControl() { Dock = DockStyle.Fill };
                splitContainer1.Panel2.Controls.Add(pView);
                //playlistView.Visible();
                pView.BringToFront();

                /*foreach (Playlist p in playlistNames)
                {
                    if (dataGridView1.CurrentCell.Value == p.Name)
                    {
                        foreach (PlaylistTrack pt in p.PlaylistTracks)
                        {
                            // MessageBox.Show(pt.Track.Name);
                            //PlaylistDetailsDGView.Rows.Add("Artist", pt.Track.Composer);
                            pView.PlaylistDetailsDGView.Rows.Clear();
                            int indexRow = pView.PlaylistDetailsDGView.Rows.Add();
                            pView.PlaylistDetailsDGView.Rows[indexRow].Tag = pt;
                            //pView.PlaylistDetailsDGView.Rows[rowIndex].Cells["Artist"].Value = pt.Track.Album.Artist.Name;
                            //pView.PlaylistDetailsDGView.Rows[rowIndex].Cells["Album"].Value = pt.Track.Album.Title;
                            pView.PlaylistDetailsDGView.Rows[indexRow].Cells["Song"].Value = pt.Track.Name;
                            pView.PlaylistDetailsDGView.Rows[indexRow].Cells["Length"].Value =
                                pt.Track.Milliseconds;
                        }
                    }
                }*/
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach(Playlist playlist in playlistNames)
            //if (dataGridView1.CurrentCell.Tag is Playlist playlist) //(treeView1.SelectedNode.Tag is Playlist playlist)
            {
                
                    if (dataGridView1.CurrentCell.Value.ToString() == playlist.PlaylistId.ToString())
                {
                    if (MessageBox.Show($"Are you sure want to delete this playlist {playlist.Name}?",
                        "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        db.Remove(playlist);
                        //var contentsToDelete = dataGridView1.CurrentCell;
                        MessageBox.Show("Delete!");
                    }

                }
            }


            /* foreach(DataGridViewRow item in this.dataGridView1.SelectedRows) //(Playlist p in playlistNames)
             {
                 //if (dataGridView1.CurrentCell.Tag is Playlist playlist)


                 if (MessageBox.Show($"Are you sure want to delete this playlist?",
                     "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                 {
                     //db.Remove(dataGridView1.CurrentCell.Value.ToString());
                     //playlistNames.Remove(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.Value.ToString());
                     //dataGridView1.SelectedRows.Clear();
                     //db.Remove(playlist);
                     //var playlistToDelete = dataGridView1.CurrentRow;
                     // playlistToDelete.Selected.ToString().Remove(playlistToDelete);
                     MessageBox.Show("hello");
                     dataGridView1.Rows.RemoveAt(item.Index);
                 }
             }*/
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //db.SaveChanges();
            //db.Dispose();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            txtPlaylistName.Text = selectedRow.Cells[1].Value.ToString();
            foreach (Playlist p in playlistNames)
            {
                if (selectedRow.Cells[1].Value.ToString() == p.Name)
                {
                    activePlaylist = p;
                    selectedPlaylist = activePlaylist;
                }
            }
        }
    }
}
