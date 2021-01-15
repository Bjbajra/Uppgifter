using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MusicDB
{
    public partial class ViewControl : UserControl
    {
        private everyloopContext db = new everyloopContext();
        private MainForm mainForm = new MainForm();
        private Playlist selectedPlaylist = MainForm.selectedPlaylist;

        public ViewControl()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ViewControl_Load(object sender, EventArgs e)
        {

            //MainForm mainForm = new MainForm();
            //Controls.Add(mainForm);
            //mainForm.playlistTracks = db.PlaylistTracks.ToList();

            var playlistNames = db.Playlists//.Where(p => p.Name.Equals("TV Shows"))
                .Include(t => t.PlaylistTracks)
                     .ThenInclude(playlistTrack => playlistTrack.Track)
                         .ThenInclude(a => a.Album)
                             .ThenInclude(at => at.Artist)
                 .ToList();

            PlaylistDetailsDGView.Rows.Clear();
            /*var dataColIndex = PlaylistDetailsDGView.Columns["Playlist Name"].Index;
            foreach (DataGridViewRow row in PlaylistDetailsDGView.Rows)
            {
                if (row.Cells[dataColIndex].Value is "Movies")*/
            {
                foreach (Playlist playlist in playlistNames)
                {
                    if (playlist.Name == selectedPlaylist.Name) //mainForm.dataGridView1.CurrentCell.Value.ToString()) //"Music Videos")
                    {
                        textBox1.Text = playlist.Name;
                        foreach (PlaylistTrack pt in playlist.PlaylistTracks)
                        {

                            int rowIndex = PlaylistDetailsDGView.Rows.Add();
                            PlaylistDetailsDGView.Rows[rowIndex].Tag = pt;
                            PlaylistDetailsDGView.Rows[rowIndex].Cells["Artist"].Value = pt.Track.Album.Artist.Name;
                            PlaylistDetailsDGView.Rows[rowIndex].Cells["Album"].Value = pt.Track.Album.Title;
                            PlaylistDetailsDGView.Rows[rowIndex].Cells["Song"].Value = pt.Track.Name;
                            PlaylistDetailsDGView.Rows[rowIndex].Cells["Length"].Value = pt.Track.Milliseconds;
                        }


                    }
                }
            }

            /* foreach (Playlist playlist in playlistNames)
              {
                  if (mainForm.dataGridView1.CurrentCell.Value == playlist.Name)
                  {
                      foreach (PlaylistTrack pt in playlist.PlaylistTracks)
                      {
                          // MessageBox.Show(pt.Track.Name);
                          //PlaylistDetailsDGView.Rows.Add("Artist", pt.Track.Composer);
                          int rowIndex = PlaylistDetailsDGView.Rows.Add();
                          PlaylistDetailsDGView.Rows[rowIndex].Tag = pt;
                          /* var comboBoxCell = PlaylistDetailsDGView.Rows[rowIndex].Cells["Song"] as DataGridViewComboBoxCell;
                           comboBoxCell.ValueType = typeof(PlaylistTrack);
                           comboBoxCell.DisplayMember = "Song";
                           comboBoxCell.ValueMember = "This";
                           foreach (PlaylistTrack ptTrack in mainForm.playlistTracks)
                           {
                               comboBoxCell.Items.Add(ptTrack);
                           }
                          */
            //PlaylistDetailsDGView.Rows[rowIndex].Cells["Artist"].Value = pt.Track.Album.Artist.Name;
            //PlaylistDetailsDGView.Rows[rowIndex].Cells["Album"].Value = pt.Track.Album.Title;
            // PlaylistDetailsDGView.Rows[rowIndex].Cells["Song"].Value = pt.Track.Name;
            //            PlaylistDetailsDGView.Rows[rowIndex].Cells["Length"].Value = pt.Track.Milliseconds;
            //        }

            //    }

            //}

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Hide();
            mainForm.Dock = DockStyle.Fill;
        }
    }
}
