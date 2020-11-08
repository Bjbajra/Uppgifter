using System;
using System.Windows.Forms;
using Word_Library;

namespace Lab4_WinForm
{
    public partial class PracticeControl : UserControl
    {
        private string selectedFile = SelectWordList.SelectedFile;
        private Word _practiceWord;
        private WordList _wordList;
        public PracticeControl()
        {
            InitializeComponent();
        }
       
        public int Score { get; set; }
        public int Attempts { get; set; }
        
        private void PracticeControl_Load(object sender, EventArgs e)
        {
            PracticeMode();
        }

        private void EndButton_Click(object sender, EventArgs e)
        { 
            Visible = false;
            MainForm mainForm = new MainForm();
            mainForm.TranslationGridView.BringToFront();
            mainForm.TranslationGridView.Visible = true;
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{(Score * 100 / Attempts)}% of your answers were correct.");
            Attempts = 0;
            Score = 0;
            Resultlabel.Visible = false;
            PracticeMode();
        }
        private void PracticeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var input = PracticetextBox.Text.ToLower();

            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(PracticetextBox.Text))
            {
                e.SuppressKeyPress = true;

                if (input == _practiceWord.Translations[_practiceWord.ToLanguage].ToLower())
                {
                    PracticetextBox.Clear();
                    Score++;
                    Attempts++;
                }
                else
                {
                    PracticetextBox.Clear();
                    DialogResult result = MessageBox.Show("Wrong answer!",
                        $"The correct translation is {_practiceWord.Translations[_practiceWord.ToLanguage].ToLower()}");
                    Attempts++;
                }
                Resultlabel.Text = $"{Score} of {Attempts} words were correct.";
                Resultlabel.Visible = true;
                PracticeMode();
            }
        }
        private void PracticeMode()
        {
            if (WordList.LoadList(selectedFile) != null)
            {
                _wordList = WordList.LoadList(selectedFile);
            }
            
            _practiceWord = _wordList.GetWordToPractice();
            var arrayOfLanguage = _wordList.Languages;

            Practicelabel.Text =
                $"Translate the {arrayOfLanguage[_practiceWord.FromLanguage]} word {_practiceWord.Translations[_practiceWord.FromLanguage]} " +
                $"to {arrayOfLanguage[_practiceWord.ToLanguage]} translation";
            Resultlabel.Text = $"{Score} of {Attempts} words were correct.";
        }
    }
}
