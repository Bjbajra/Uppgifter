using System;
using System.Windows.Forms;
using Word_Library;

namespace Lab4_WinForm
{
    public partial class SelectWordlist : Form
    {
        public string FileName { get; }
        public SelectWordlist(string fileName)
        {
            InitializeComponent();
            FileName = fileName;
        }
        private void Select_button_Click(object sender, EventArgs e)
        {
            MainGridControl mainGridControl = new MainGridControl();
            mainGridControl.Show();
            var name = "";
            if (listBoxWord.SelectedItem != null)
            {
                name = listBoxWord.SelectedItem.ToString();
            }
        }

        private void Newlist_button_Click(object sender, EventArgs e)
        {
            NewListForm newListForm = new NewListForm();
            newListForm.Show();
            newListForm.StartPosition = FormStartPosition.CenterParent;
            
        }

        private void SelectWordlist_Activated(object sender, EventArgs e)
        {
           listBoxWord.Show();
           listBoxWord.Items.Clear();
           var lists = WordList.GetList();
           foreach (var list in lists)
           {
               if (WordList.LoadList(list) != null && WordList.LoadList(list).Languages.Length > 1)
               {
                   listBoxWord.Items.Add(list);
               }
           }

        }

        private void listBoxWord_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxWord.SelectedItems != null)
            {
                var name = listBoxWord.SelectedItem.ToString();
                var arrayOfLanguage = WordList.LoadList(name).Languages;
                var sortBy = 0;
                Value_label.Text = $"{WordList.LoadList(name).Count()}";
                LanguageTextBox.Clear();
                
                foreach (var lang in arrayOfLanguage)
                {
                    LanguageTextBox.Text += Environment.NewLine + lang;
                }
            }
        }

      
        private void Cancel_button_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
