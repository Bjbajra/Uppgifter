using System;
using System.Windows.Forms;
//using Word_Library;
using NewWord_Library;

namespace Lab4_WinForm
{
    public partial class MainForm : Form
    {
        private WordList Lists { get; set; }
        private string selectedFile = SelectWordList.SelectedFile;
        public MainForm()
        {
            InitializeComponent();
        }

        private void setActiveWordListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SelectWordList selectWordList = new SelectWordList())
            {
                selectWordList.SelectHandler += MyListFormSelectedHandler;
                selectWordList.ShowDialog();
                selectWordList.StartPosition = FormStartPosition.CenterParent;
                TranslationGridView.Show();
                editModeToolStripMenuItem.Checked = true;
                practiceModeToolStripMenuItem.Checked = false;
                AddButton.Show();
                RemoveButton.Show();
                PracticeButton.Show();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editModeToolStripMenuItem.Checked = true;
            practiceModeToolStripMenuItem.Checked = false;
            TranslationGridView.Show();
            AddButton.Show();
            RemoveButton.Show();
            PracticeButton.Show();
        }

        private void practiceModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editModeToolStripMenuItem.Checked = false;
            practiceModeToolStripMenuItem.Checked = true;
            PracticeControl practiceControl = new PracticeControl();
            Controls.Add(practiceControl);
            practiceControl.Dock = DockStyle.Fill;
            practiceControl.Show();
            TranslationGridView.Hide();
            AddButton.Hide();
            RemoveButton.Hide();
            PracticeButton.Hide();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            using (AddWordForm addWordForm = new AddWordForm(Lists))
            {
                addWordForm.AddHandler += AddWord_AddHandler;
                addWordForm.ShowDialog();
            }
        }

        private void AddWord_AddHandler(object sender, EventArgs e)
        {
            var sender2 = (AddWordForm)sender;
            var list = sender2.AddedWords.ToArray();
            Lists.Add(list);
            Lists.Save();
            AddToDataGrid();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (TranslationGridView.CurrentCell == null) return;
            Lists.Remove(TranslationGridView.CurrentCell.ColumnIndex,
                TranslationGridView.CurrentCell.Value.ToString());
            MessageBox.Show($"The word {TranslationGridView.CurrentCell.Value.ToString()} is removed.");
            AddToDataGrid();
        }

        private void PracticeButton_Click(object sender, EventArgs e)
        {
            PracticeControl practiceControl = new PracticeControl();
            Controls.Add(practiceControl);
            practiceControl.Dock = DockStyle.Fill;
            practiceControl.Show();
            TranslationGridView.Hide();
            AddButton.Hide();
            RemoveButton.Hide();
            PracticeButton.Hide();
            practiceModeToolStripMenuItem.Checked = true;
            editModeToolStripMenuItem.Checked = false;
        }

        public void AddToDataGrid()
        {
            var arrayOfLanguage = WordList.LoadList(SelectWordList.SelectedFile).Languages;
            var sortBy = 0;
            TranslationGridView.Rows.Clear();
            TranslationGridView.Columns.Clear();

            foreach (var languages in arrayOfLanguage)
            {
                TranslationGridView.Columns.Add("languageColumn", languages.ToUpper());
            }
            TranslationGridView.Rows.Clear();

            WordList.LoadList(SelectWordList.SelectedFile).List(sortBy, x => { TranslationGridView.Rows.Add(x); });
        }
        public void MyListFormSelectedHandler(object sender, EventArgs e)
        {
            var sender2 = (SelectWordList)sender;
            Lists = sender2.ListName;
            AddToDataGrid();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            AddButton.Hide();
            RemoveButton.Hide();
            PracticeButton.Hide();
        }
    }
}
