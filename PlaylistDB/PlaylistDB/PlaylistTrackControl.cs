using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace PlaylistDB
{
    public partial class PlaylistTrackControl : UserControl
    {
        private List<Track> trackList;
        private MainForm mainForm = new MainForm();
        private everyloopContext db = new everyloopContext();
        private Playlist selectedPlaylist = MainForm.SelectedPlaylist;

        public PlaylistTrackControl()
        {
            InitializeComponent();
        }

        private void PlaylistTrackControl_Load(object sender, EventArgs e)
        {
            loadPlaylistTracks();
            //AddPlaylistTracks();
        }

        private void loadPlaylistTracks()
        {
            trackList = db.Tracks.ToList();

            var playlistNames = db.Playlists
               .Include(t => t.PlaylistTracks)
                   .ThenInclude(playlistTrack => playlistTrack.Track)
               .ToList();

            DGVPlaylistTrack.Rows.Clear();

            foreach (Playlist playlist in playlistNames)
            {
                if (playlist.PlaylistId == selectedPlaylist.PlaylistId)
                {
                    txtActivePlaylist.Text = playlist.Name;
                    txtActivePlaylist.Enabled = false;

                    foreach (PlaylistTrack playlistTrack in playlist.PlaylistTracks)
                    {
                        int rowIndex = DGVPlaylistTrack.Rows.Add();
                        DGVPlaylistTrack.Rows[rowIndex].Tag = playlistTrack;

                        var comboBoxCell = DGVPlaylistTrack.Rows[rowIndex].Cells["Song"] as DataGridViewComboBoxCell;
                        comboBoxCell.ValueType = typeof(Track);
                        comboBoxCell.DisplayMember = "Name";
                        comboBoxCell.ValueMember = "This";

                        foreach (Track track in trackList)
                        {
                            comboBoxCell.Items.Add(track);
                        }

                        DGVPlaylistTrack.Rows[rowIndex].Cells["Song"].Value = playlistTrack.Track;
                        DGVPlaylistTrack.Rows[rowIndex].Cells["Length"].Value = playlistTrack.Track.Milliseconds;
                    }

                }

            }

        }

        private void AddPlaylistTracks()
        {
            trackList = db.Tracks.ToList();

            var playlistTracks = db.PlaylistTracks
                .Include(p => p.Playlist)
                .Include(pt => pt.Track)
                .ToList();

            DGVPlaylistTrack.Rows.Clear();

            foreach (PlaylistTrack playlistTrack in playlistTracks)
            {
                if (playlistTrack.PlaylistId == selectedPlaylist.PlaylistId)
                {
                    txtActivePlaylist.Text = playlistTrack.Playlist.Name;
                    txtActivePlaylist.Enabled = false;


                    int rowIndex = DGVPlaylistTrack.Rows.Add();
                    DGVPlaylistTrack.Rows[rowIndex].Tag = playlistTrack.Track;

                    var comboBoxCell = DGVPlaylistTrack.Rows[rowIndex].Cells["Song"] as DataGridViewComboBoxCell;
                    comboBoxCell.ValueType = typeof(Track);
                    comboBoxCell.DisplayMember = "Name";
                    comboBoxCell.ValueMember = "This";

                    foreach (Track track in trackList)
                    {
                        comboBoxCell.Items.Add(track);
                    }

                    DGVPlaylistTrack.Rows[rowIndex].Cells["Song"].Value = playlistTrack.Track;
                    DGVPlaylistTrack.Rows[rowIndex].Cells["Length"].Value = playlistTrack.Track.Milliseconds;

                }
            }
        }

        private void AddToComboBoxCell()
        {
            int rowIndex = DGVPlaylistTrack.Rows.Add();

            var comboBoxCell = DGVPlaylistTrack.Rows[rowIndex].Cells["Song"] as DataGridViewComboBoxCell;
            comboBoxCell.ValueType = typeof(Track);
            comboBoxCell.DisplayMember = "Name";
            comboBoxCell.ValueMember = "This";

            foreach (Track track in trackList)
            {
                comboBoxCell.Items.Add(track);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Visible = false;
            mainForm.Dock = DockStyle.Fill;
        }

        private void DGVPlaylistTrack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var cell = DGVPlaylistTrack.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell is DataGridViewComboBoxCell comboBoxCell)
            {
                var track = comboBoxCell.Value as Track;

                DGVPlaylistTrack.Rows[e.RowIndex].Cells["Length"].Value = track.Milliseconds;
                var playlistTrack = DGVPlaylistTrack.Rows[e.RowIndex].Tag as PlaylistTrack;
                playlistTrack.Track = track;
                playlistTrack.Track.Milliseconds = track.Milliseconds;
            }
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            if (selectedPlaylist != null)
            {
                //if (DGVPlaylistTrack.Rows[0].Tag is Track songTrack) // index out of range exception.
                //{
                //if (selectedPlaylist.PlaylistTracks.Any(t => t.TrackId == songTrack.TrackId)) return;

                var playlistTracks = new PlaylistTrack()
                {
                    PlaylistId = selectedPlaylist.PlaylistId //, TrackId = songTrack.TrackId, Playlist = selectedPlaylist, Track = songTrack
                };
                selectedPlaylist.PlaylistTracks.Add(playlistTracks);

                int rowIndex = DGVPlaylistTrack.Rows.Add();
                DGVPlaylistTrack.Rows[rowIndex].Tag = playlistTracks;

                var comboBoxCell = DGVPlaylistTrack.Rows[rowIndex].Cells["Song"] as DataGridViewComboBoxCell;
                comboBoxCell.ValueType = typeof(Track);
                comboBoxCell.DisplayMember = "Name";
                comboBoxCell.ValueMember = "This";

                foreach (Track track in trackList)
                {
                    comboBoxCell.Items.Add(track);
                }

                comboBoxCell.Value = trackList[0];

                db.SaveChanges();
                
            }
        }

        private void btnDeleteTrack_Click(object sender, EventArgs e)
        {
            var cell = DGVPlaylistTrack.Rows[0].Cells["Song"];

            if (cell is DataGridViewComboBoxCell comboBoxCell)
            {
                var track = comboBoxCell.Value as PlaylistTrack; //here track is null.
                //if(track == selectedPlaylist.PlaylistTracks)
                if (MessageBox.Show($"Are you sure want to delete this playlist {track.Track.Name}?",
                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DGVPlaylistTrack.Rows.RemoveAt(cell.RowIndex);
                    // db.Remove(playlistTrack);

                    MessageBox.Show($" Deleted Successfully!");
                }
            }


           /* if (DGVPlaylistTrack.SelectedRows[0].Index < 0) return; // index out of range exception!
            
            //if (DGVPlaylistTrack.SelectedRows[0].Tag is PlaylistTrack playlistTrack)
            {

                if (MessageBox.Show($"Are you sure want to delete this playlist {playlistTrack.Track.Name}?",
                    "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    DGVPlaylistTrack.Rows.RemoveAt(DGVPlaylistTrack.SelectedRows[0].Index);
                    // db.Remove(playlistTrack);

                    MessageBox.Show($" Deleted Successfully!");
                }

            }*/
        }

    }
}
