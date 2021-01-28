using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MusicDB
{
    public partial class PlaylistTrackControl : UserControl
    {
        private readonly everyloopContext _dbContext; 
        private readonly MainForm _mainForm = new MainForm();
        private List<Track> _trackList;
        private readonly Playlist _selectedPlaylist;

        public PlaylistTrackControl(Playlist playlist, everyloopContext dbContext)
        {
            InitializeComponent();
            _dbContext = dbContext; 
            _selectedPlaylist = playlist;
        }

        private void ViewControl_Load(object sender, EventArgs e)
        {
            LoadPlaylistTracks();
            AddTracksToComboBox();
        }

        public void LoadPlaylistTracks()
        {
            _trackList = _dbContext.Tracks.OrderBy(t => t.TrackId).ToList();

            var playlist = _dbContext.Playlists.Where(p => p == _selectedPlaylist)
                .Include(t => t.PlaylistTracks)
                    .ThenInclude(playlistTrack => playlistTrack.Track)
                        .ThenInclude(track => track.Album)
                            .ThenInclude(album => album.Artist)
                .SingleOrDefault();

            if (DGVPlaylistTrack.Rows.Count > 0)
            {
                btnDeleteTrack.Enabled = true;
            }
            btnDeleteTrack.Enabled = false;
            txtActivePlaylist.Text = _selectedPlaylist.Name;
            txtActivePlaylist.Enabled = false;

            DGVPlaylistTrack.Rows.Clear();

            foreach (PlaylistTrack playlistTrack in playlist.PlaylistTracks)
            {
                int rowIndex = DGVPlaylistTrack.Rows.Add();
                DGVPlaylistTrack.Rows[rowIndex].Tag = playlistTrack;

                DGVPlaylistTrack.Rows[rowIndex].Cells["Song"].Value = playlistTrack.Track.Name;
                DGVPlaylistTrack.Rows[rowIndex].Cells["Album"].Value = playlistTrack.Track.Album.Title;
                DGVPlaylistTrack.Rows[rowIndex].Cells["Artist"].Value = playlistTrack.Track.Album.Artist.Name;
                DGVPlaylistTrack.Rows[rowIndex].Cells["Length"].Value = playlistTrack.Track.Milliseconds;
            }
        }

        private void AddTracksToComboBox()
        {
            comboBoxTracklist.Items.Clear();
            comboBoxTracklist.DisplayMember = "Name";
            comboBoxTracklist.ValueMember = "This";

            foreach (Track track in _trackList)
            {
                comboBoxTracklist.Items.Add(track);
            }

            comboBoxTracklist.SelectedIndex = 0;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            _mainForm.Dock = DockStyle.Fill;
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

                var checkingExistingTracks = _dbContext.PlaylistTracks.Where(pt =>
                    pt.PlaylistId == _selectedPlaylist.PlaylistId && pt.TrackId == comboBoxTracklist.SelectedIndex + 1);

                if (checkingExistingTracks.ToArray().Length > 0)
                {
                    MessageBox.Show("Track already exists!", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _dbContext.PlaylistTracks.Add(newPlaylistTrack);
                comboBoxTracklist.SelectedIndex = 0;
                _dbContext.SaveChanges();
                LoadPlaylistTracks();
            }
        }

        private void btnDeleteTrack_Click_1(object sender, EventArgs e)
        {
            if (txtActivePlaylist.Text == "") MessageBox.Show("Please select a song!");

            if (_selectedPlaylist != null && DGVPlaylistTrack.CurrentCell != null)
            {
                int rowIndex = DGVPlaylistTrack.CurrentCell.RowIndex;

                if (DGVPlaylistTrack.Rows[rowIndex].Tag is PlaylistTrack playlistTrack)
                {
                    if (MessageBox.Show($"Are you sure want to delete this song {playlistTrack.Track.Name} from playlist {playlistTrack.Playlist.Name} ?",
                        "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _dbContext.PlaylistTracks.Remove(playlistTrack);
                        DGVPlaylistTrack.Rows.RemoveAt(rowIndex);
                        _dbContext.SaveChanges();
                        LoadPlaylistTracks();

                        MessageBox.Show($"{playlistTrack.Track.Name} was deleted successfully!", "Info:", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void DGVPlaylistTrack_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (DGVPlaylistTrack.Rows.Count == 0)
            {
                btnDeleteTrack.Enabled = false;
            }

            btnDeleteTrack.Enabled = true;
        }
    }
}



