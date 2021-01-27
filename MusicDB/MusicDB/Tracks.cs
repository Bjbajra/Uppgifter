using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MusicDB
{
    public partial class TracksForm : Form
    {
        private everyloopContext db = new everyloopContext();
        private Playlist selectedPlaylist = MainForm.SelectedPlaylist;
        private PlaylistTrackControl viewControl = new PlaylistTrackControl();
        private MainForm main = new MainForm();
        public List<Track>trackList = new List<Track>();

        public TracksForm()
        {
            InitializeComponent();
        }

        /*public TracksForm(Playlist SelectedPlaylist, everyloopContext db)
        {
            this.SelectedPlaylist = SelectedPlaylist;
            this.db = db;
        }*/

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
            if (selectedPlaylist != null)
            {
                trackList = db.Tracks.ToList();

                var newPlaylistTrack = new PlaylistTrack()
                {
                    PlaylistId = selectedPlaylist.PlaylistId,
                    TrackId = checkedListBoxTracks.SelectedIndex
                };

                var result = db.PlaylistTracks.Where(pt =>
                    pt.PlaylistId == selectedPlaylist.PlaylistId && pt.TrackId == checkedListBoxTracks.SelectedIndex);
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
            /*if (checkedListBoxTracks.CheckedItems is Track track)
            {
                if(SelectedPlaylist.PlaylistTracks.Any(pt => pt.TrackId == track.TrackId)) return;
                var newPlaylistTrack = new PlaylistTrack()
                {
                    PlaylistId = SelectedPlaylist.PlaylistId, TrackId = track.TrackId, Playlist = SelectedPlaylist,
                    Track = track
                };
                SelectedPlaylist?.PlaylistTracks.Add(newPlaylistTrack);
                viewControl.PlaylistDetailsDGView.Rows.Add(track.Name);
            }


            /*ViewControl viewControl = new ViewControl() {Dock = DockStyle.Fill};
            //main.splitContainer1.Panel2.Controls.Add(viewControl);
            Controls.Add(viewControl);
            viewControl.BringToFront();           

            if (checkedListBoxTracks.CheckedItems != null)
            {
                viewControl.PlaylistDetailsDGView.Rows.Clear();
                foreach (var track in checkedListBoxTracks.CheckedItems)
                {
                    int rowIndex = viewControl.PlaylistDetailsDGView.Rows.Add();
                    viewControl.PlaylistDetailsDGView.Rows[rowIndex].Cells["Song"].Value = track;
                }

                db.SaveChanges();
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
