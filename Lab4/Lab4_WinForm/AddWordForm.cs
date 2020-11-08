using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Word_Library;

namespace Lab4_WinForm
{
    public partial class AddWordForm : Form
    {
        private string selected = SelectWordList.SelectedFile;
        public event EventHandler AddHandler;
        private WordList wordList { get; }
        public List<string> AddedWords = new List<string>();

        public AddWordForm(WordList wordList)
        {
            InitializeComponent();
            this.wordList = wordList;
        }
        private void AddWord()
        {
            for (int i = 1; i < WordGridView.Rows.Count; i++)
            {
                if (!String.IsNullOrWhiteSpace(WordGridView.Rows[i].Cells[1].Value.ToString()))
                {
                    AddedWords.Add(WordGridView.Rows[i].Cells["Word"].Value.ToString());
                }
                else
                {
                    AddedWords.Clear();
                    MessageBox.Show("You must add all translation.", "Adding Error:");
                    break;
                }
            }
        }
        private void AddWordButton_Click(object sender, EventArgs e)
        {
            AddWord();
            if (AddedWords.Count == 0) return;
            AddHandler?.Invoke(this, null);
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddWordForm_Load(object sender, EventArgs e)
        {
            AddWordButton.Enabled = false;
            WordGridView.Rows.Add("");
            var arrayOfLanguage = WordList.LoadList(selected).Languages;

            foreach (var language in arrayOfLanguage)
            {
                WordGridView.Rows.Add(language.ToUpper());
            }
        }

        private void WordGridView_CellValueChanged_1(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 1; i < (WordGridView.Rows.Count); i++)
            {
                if (WordGridView.Rows[i].Cells["Word"].Value == null)
                {
                    AddWordButton.Enabled = false;
                    break;
                }
                else if (string.IsNullOrWhiteSpace(WordGridView.Rows[i].Cells["Word"].Value.ToString()))
                {
                    AddWordButton.Enabled = false;
                    break;
                }
                else
                {
                    AddWordButton.Enabled = true;
                }
            }
        }
    }
}
