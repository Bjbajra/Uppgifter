using System;
using System.Windows.Forms;
using Word_Library;

namespace Lab4_WinForm
{
    public partial class MainForm : Form
    {
        //public  string Name { get; set; }

        public MainForm(string name)
        {
            InitializeComponent();
            Name = name;
        }
        public MainForm()
        { 
            InitializeComponent();
            MainGridControl mainGrid = new MainGridControl();
            Controls.Add(mainGrid);
            mainGrid.Dock = DockStyle.Fill;
            SelectWordlist selectWordlist = new SelectWordlist(Name);
            selectWordlist.Show();
            selectWordlist.StartPosition = FormStartPosition.CenterParent;
        }

        private void setActiveWordListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectWordlist selectWordlist = new SelectWordlist(Name);
            selectWordlist.Show();
            selectWordlist.StartPosition = FormStartPosition.CenterParent;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editModeToolStripMenuItem.Checked = true;
            practiceModeToolStripMenuItem.Checked = false;
        }

        private void practiceModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editModeToolStripMenuItem.Checked = false;
            practiceModeToolStripMenuItem.Checked = true;
            PracticeControl practiceControl = new PracticeControl();
            Controls.Add(practiceControl);
            practiceControl.Dock = DockStyle.Fill;
            practiceControl.Show();
        }
    }
}
