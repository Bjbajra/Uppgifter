using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MusicDB
{
    public partial class PlaylistTrackControl : UserControl
    {

        private everyloopContext db = new everyloopContext();
        private MainForm mainForm = new MainForm();
        private readonly Playlist _selectedPlaylist = MainForm.SelectedPlaylist;
        private List<Track> trackList;

        public PlaylistTrackControl()
        {
            InitializeComponent();
        }

        private void ViewControl_Load(object sender, EventArgs e)
        {
            //LoadPlaylistTracks1();
            LoadPlaylistTracks();
            //AddPlaylistTracks();
            AddTracksToComboBox();
        }
        private void LoadPlaylistTracks()
        {
            trackList = db.Tracks.ToList();

            var playlistNames = db.Playlists.Where(p=> p == _selectedPlaylist)
                .Include(t => t.PlaylistTracks)
                    .ThenInclude(playlistTrack => playlistTrack.Track)
                        .ThenInclude(track => track.Album)
                            .ThenInclude(album => album.Artist)
                .ToList();

            txtActivePlaylist.Text = _selectedPlaylist.Name;
            txtActivePlaylist.Enabled = false;

            DGVPlaylistTrack.Rows.Clear();

            foreach (Playlist playlist in playlistNames)
            {
                foreach (PlaylistTrack playlistTrack in playlist.PlaylistTracks)
                {
                    int rowIndex = DGVPlaylistTrack.Rows.Add();
                    DGVPlaylistTrack.Rows[rowIndex].Tag = playlistTrack;
                    DGVPlaylistTrack.Rows[rowIndex].Cells["Artist"].Value = playlistTrack.Track.Album.Artist.Name;
                    DGVPlaylistTrack.Rows[rowIndex].Cells["Album"].Value = playlistTrack.Track.Album.Title;
                    DGVPlaylistTrack.Rows[rowIndex].Cells["Song"].Value = playlistTrack.Track.Name;
                    DGVPlaylistTrack.Rows[rowIndex].Cells["Length"].Value = playlistTrack.Track.Milliseconds;
                }
            }
        }
        private void AddPlaylistTracks()
        {
            trackList = db.Tracks.OrderBy(t => t.TrackId).ToList();

            var playlistTracks = db.PlaylistTracks.Where(pt => pt.Playlist.PlaylistId == _selectedPlaylist.PlaylistId)
                .Include(p => p.Playlist)
                .Include(pt => pt.Track)
                .ToList();

            txtActivePlaylist.Text = _selectedPlaylist.Name;
            txtActivePlaylist.Enabled = false;

            DGVPlaylistTrack.Rows.Clear();

            foreach (PlaylistTrack playlistTrack in playlistTracks)
            {
                int rowIndex = DGVPlaylistTrack.Rows.Add();
                DGVPlaylistTrack.Rows[rowIndex].Tag = playlistTrack.Track;

                DGVPlaylistTrack.Rows[rowIndex].Cells["Artist"].Value = playlistTrack.Track.Album.Artist.Name;
                DGVPlaylistTrack.Rows[rowIndex].Cells["Album"].Value = playlistTrack.Track.Album.Title;
                DGVPlaylistTrack.Rows[rowIndex].Cells["Song"].Value = playlistTrack.Track.Name;
                DGVPlaylistTrack.Rows[rowIndex].Cells["Length"].Value = playlistTrack.Track.Milliseconds;
            }
        }

        #region Try
        public void LoadPlaylistTracks1()
        {
            trackList = db.Tracks.OrderBy(t => t.TrackId).ToList();

            DGVPlaylistTrack.Rows.Clear();

            if (_selectedPlaylist != null)
            {
                txtActivePlaylist.Text = _selectedPlaylist.Name;
                txtActivePlaylist.Enabled = false;
                foreach (PlaylistTrack pt in _selectedPlaylist.PlaylistTracks)
                {
                    int rowIndex = DGVPlaylistTrack.Rows.Add();
                    DGVPlaylistTrack.Rows[rowIndex].Tag = pt;
                    DGVPlaylistTrack.Rows[rowIndex].Cells["Song"].Value = pt.Track.Name;
                    DGVPlaylistTrack.Rows[rowIndex].Cells["Length"].Value = pt.Track.Milliseconds;
                }
            }
        }

        #endregion

        private void AddTracksToComboBox()
        {
            comboBoxTracklist.Items.Clear();
            comboBoxTracklist.DisplayMember = "Name";
            comboBoxTracklist.ValueMember = "This";

            foreach (Track track in trackList)
            {
                comboBoxTracklist.Items.Add(track);
            }

            comboBoxTracklist.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            mainForm.Dock = DockStyle.Fill;
        }

        private void btnAddTracks_Click(object sender, EventArgs e)
        {
            if (_selectedPlaylist != null)
            {
                var newPlaylistTrack = new PlaylistTrack()
                {
                    PlaylistId = _selectedPlaylist.PlaylistId,
                    TrackId = comboBoxTracklist.SelectedIndex + 1
                };

                var checkingExistingTracks = db.PlaylistTracks.Where(pt =>
                    pt.PlaylistId == _selectedPlaylist.PlaylistId && pt.TrackId == comboBoxTracklist.SelectedIndex + 1);
                if (checkingExistingTracks.ToArray().Length > 0)
                {
                    MessageBox.Show("Track already exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                db.PlaylistTracks.Add(newPlaylistTrack);
                comboBoxTracklist.SelectedIndex = 0;
                db.SaveChanges();
                //LoadPlaylistTracks1();
                LoadPlaylistTracks();
                //AddPlaylistTracks();
                
            }
        }

        private void btnDeleteTrack_Click_1(object sender, EventArgs e)
        {
            if (_selectedPlaylist != null)
            {
                int rowIndex = DGVPlaylistTrack.CurrentCell.RowIndex;

                if (rowIndex < 0) return;

                if (DGVPlaylistTrack.Rows[rowIndex].Tag is PlaylistTrack playlistTrack)
                {
                    if (MessageBox.Show($"Are you sure want to delete this song {playlistTrack.Track.Name} from playlist {playlistTrack.Playlist.Name} ?",
                        "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        db.PlaylistTracks.Remove(playlistTrack);
                        DGVPlaylistTrack.Rows.RemoveAt(rowIndex);
                        db.SaveChanges();
                        LoadPlaylistTracks();
                        //AddPlaylistTracks();
                        
                        MessageBox.Show($"{playlistTrack.Track.Name} is deleted successfully!", "Info:", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
}



