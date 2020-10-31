using System;
using System.Windows.Forms;
using Word_Library;

namespace Lab4_WinForm
{
    public partial class PracticeControl : UserControl
    {
        public string ListName { get; }
        private Word PracticeWord { get; set; }
        public PracticeControl(string listName)
        {
            InitializeComponent();
            ListName = listName;
        }

        public PracticeControl()
        {
            InitializeComponent();
        }
       
        public int Score { get; set; }
        public int Attempts { get; set; }
        private Word PracticeMode()
        {
            var name = ListName;
            PracticeWord = WordList.LoadList(name).GetWordToPractice();
            return PracticeWord;
        }
        private void PracticeControl_Load(object sender, EventArgs e)
        {
            PracticeMode();
            var name = ListName;
            var arrayOfLanguage = WordList.LoadList(name).Languages;

            Practicelabel.Text =
                $"Translate the {arrayOfLanguage[PracticeWord.FromLanguage]} word {PracticeWord.Translations[PracticeWord.FromLanguage]} " +
                $"to {arrayOfLanguage[PracticeWord.ToLanguage]} translation";
            Resultlabel.Text = $"{Score} of {Attempts} words were correct.";
        }

        private void EndButton_Click(object sender, EventArgs e)
        {
            PracticeControl practice = new PracticeControl();
            practice.Hide();
            MainGridControl mainGrid = new MainGridControl();
            mainGrid.Show();
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            PracticeMode();
        }

        private void PracticeTextBox_TextChanged(object sender, EventArgs e)
        {
            var name = ListName;
            var arrayOfLanguage = WordList.LoadList(name).Languages;
            var input = PracticetextBox.Text.ToLower();
            PracticetextBox.Text = string.Empty;

            if (input == PracticeWord.Translations[PracticeWord.ToLanguage].ToLower())
            {
                Score++;
                Attempts++;
            }
            else
            {
                DialogResult result = MessageBox.Show("Wrong answer!",
                    $"The correct translation is {PracticeWord.Translations[PracticeWord.ToLanguage].ToLower()}");
                Attempts++;
            }

            PracticeMode();
            Practicelabel.Text =
                $"Translate the {arrayOfLanguage[PracticeWord.FromLanguage]} word {PracticeWord.Translations[PracticeWord.FromLanguage]} " +
                $"to {arrayOfLanguage[PracticeWord.ToLanguage]} translation";
            Resultlabel.Text = $"{Score} of {Attempts} words were correct.";

        }
    }
}
