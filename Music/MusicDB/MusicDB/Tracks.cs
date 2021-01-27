using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MusicDB
{
    public partial class TracksForm : Form
    {
        private everyloopContext db;
        private Playlist Playlist;
        public List<Track> trackList = new List<Track>();

        public TracksForm()
        {
            InitializeComponent();
        }

        public TracksForm(Playlist playlist, everyloopContext db)
        {
            Playlist = playlist;
            this.db = db;
        }

        private void Tracks_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            var trackList = db.Tracks
                .ToList();

            checkedListBoxTracks.Items.Clear();
            foreach (Track track in trackList)
            {
                checkedListBoxTracks.Items.Add(track.Name);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //if (checkedListBoxTracks.CheckedItems is Track track)
            {
                trackList = db.Tracks.ToList();

                var newPlaylistTrack = new PlaylistTrack()
                {
                    PlaylistId = Playlist.PlaylistId,
                    TrackId = checkedListBoxTracks.SelectedIndex
                };

                var result = db.PlaylistTracks.Where(pt =>
                    pt.PlaylistId == Playlist.PlaylistId && pt.TrackId == checkedListBoxTracks.SelectedIndex);
                if (result.ToArray().Length > 0)
                {
                    MessageBox.Show("Track already exists!");
                    return;
                }

                db.PlaylistTracks.Add(newPlaylistTrack);
                db.SaveChanges();
            }


        }

        public void LoadTracks()
        {
            /*if (checkedListBoxTracks.CheckedItems != null)
            {
                viewControl.PlaylistDetailsDGView.Rows.Clear();
                foreach (var track in checkedListBoxTracks.CheckedItems)
                {
                    int rowIndex = viewControl.PlaylistDetailsDGView.Rows.Add();
                    viewControl.PlaylistDetailsDGView.Rows[rowIndex].Cells["Song"].Value = track;
                }

                Db.SaveChanges();
            }*/
        }



        private void checkedListBoxTracks_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < checkedListBoxTracks.Items.Count; i++)
            {
                if (checkedListBoxTracks.SelectedItem == null)
                {
                    btnAdd.Enabled = false;
                    break;
                }

                btnAdd.Enabled = true;
            }
        }
    }
}
