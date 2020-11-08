using System;
using System.Linq;
using System.Windows.Forms;
using Word_Library;

namespace Lab4_WinForm
{
    public partial class NewListForm : Form
    {
        public NewListForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            var name = ListtextBox.Text;
            if (name == "")
            {
                MessageBox.Show("You must give the name!", "Error:");
                return;
            }

            var languageList = LanguagetextBox.Lines.ToList();
            var arrayOfLangugae = languageList.Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();

            if (arrayOfLangugae.Length < 2)
            {
                var caption = "Error";
                var message = "You need to add at least 2 langauges.";
                var buttons = MessageBoxButtons.OK;
                DialogResult result;
                result = MessageBox.Show(message, caption, buttons);
            }
            else
            {
                var wordList = new WordList(name, arrayOfLangugae);
                wordList.Save();
                Close();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ListTextBox_TextChanged(object sender, EventArgs e)
        {
            LanguagetextBox.Text = string.Empty;
        }

        private void NewListForm_Load(object sender, EventArgs e)
        {
            LanguagetextBox.Text = $"Language <1>... {Environment.NewLine}Languagen <n>";
        }
    }
}
